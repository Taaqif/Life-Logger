using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace ICT365Assignment1
{
    public partial class MainForm : Form
    {
        //setup the helpers
        MapHelper mapHelper = MapHelper.Instance();
        EventsHelper eventHelper = EventsHelper.Instance();

        private static int MOUSE_X_COORDINATES, MOUSE_Y_COORDINATES;
        private static string DEFAULT_LOCATION = "Perth, WA";

        private bool link;
        private bool unlink;

        private HashSet<Event> eventLinks = new HashSet<Event>();

        public MainForm()
        {
            InitializeComponent();
            //try loading the file, if not, ask the user to open one
            try
            {
                loadData("lle.xml");
            }
            catch (FileNotFoundException)
            {
                openToolStripMenuItem_Click(this, new EventArgs());
            }
            
        }

        public void loadData(string file)
        {
            
            //load the events 
            eventHelper.loadFromXML(file);
            //assign a controller
            mapHelper.AssignMapControl(mapCtrl);
            //configure map
            mapHelper.ConfigMap();
            //set map to default location
            mapHelper.SetMapCenterLocation(DEFAULT_LOCATION);
            //render the events
            eventHelper.renderEvents();
        }

        
        private void MainForm_Load(object sender, EventArgs e)
        {   

        }

        private void mapCtrl_MouseClick(object sender, MouseEventArgs e)
        {
            //capture the mouse cordinates when the user right clicks
            //and sow the context menu
            if (e.Button == System.Windows.Forms.MouseButtons.Right && !link)
            {
                MOUSE_X_COORDINATES = e.X;
                MOUSE_Y_COORDINATES = e.Y;
                
                mapContextMenu.Show(mapCtrl, e.Location);
                
            }
            
        }

        //prevent the user with a dialog to open
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open LifeLog";
                dlg.Filter = "Life logging files (*.xml)|*.XML";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    loadData(dlg.FileName);
                }
            }
        }

        //executes when the user clicks on a marker 
        private void gmap_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            //make sure the marker being clikced is an event
            //and the mouse clikc is left 
            if(e.Button == MouseButtons.Left && item.Tag is Event)
            {
                if (link)
                {
                    AddLink((Event)item.Tag);
                }
                else if (unlink)
                {
                    RemoveLink((Event)item.Tag);
                }
                else
                {
                    EventDetailsForm f = EventDetailsForm.Instance();
                    f.Details = ((Event)item.Tag).CreatePanel();
                    f.StartPosition = FormStartPosition.CenterParent;
                    f.ShowDialog();
                }
                
            }            
        }
        //removes the two events, call twice to remove
        private void RemoveLink(Event e)
        {
            if (eventLinks.Count < 2)
            {
                eventLinks.Add(e);

            }
            if (eventLinks.Count == 2)
            {
                if (eventHelper.UnLinkEvents(eventLinks.ElementAt(0), eventLinks.ElementAt(1)))
                {
                    MessageBox.Show("Events unlinked");
                }
                else
                {
                    MessageBox.Show("Error unlinking events");
                }
                StopLinking();
            }
        }

        //adds the links, call twice to add
        private void AddLink(Event e)
        {
            if(eventLinks.Count < 2)
            {
                eventLinks.Add(e);
                
            }
            if (eventLinks.Count == 2)
            {  
                if(eventHelper.LinkEvents(eventLinks.ElementAt(0), eventLinks.ElementAt(1)))
                {
                    MessageBox.Show("Events linked");
                }
                else
                {
                    MessageBox.Show("Error linking events");
                }
                StopLinking();
            }
        }
        private void StopLinking()
        {
            //reset the linking options
            eventLinks = new HashSet<Event>();
            link = false;
            unlink = false;
            ToolboxEventFlowLayout.Controls.Clear();
        }
        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //get coordinates from the mouse position 
            Coordinates coordinates = new Coordinates(mapCtrl.FromLocalToLatLng(MOUSE_X_COORDINATES, MOUSE_Y_COORDINATES).Lat, mapCtrl.FromLocalToLatLng(MOUSE_X_COORDINATES, MOUSE_Y_COORDINATES).Lng);

            ToolboxEventFlowLayout.Controls.Clear();

            //add a clear button to the form
            Button clearButton = new Button();
            clearButton.Text = "Clear Selection";
            clearButton.Click += new EventHandler(ClearSelection);
            ToolboxEventFlowLayout.Controls.Add(clearButton);
            
            //clear the matchlines overlay
            mapHelper.Clear("matchlines");

            //setup for results view
            int numResults = 0;
            int radius = 0;
            int defaultRadius = 2;
            try
            {
                radius = Int32.Parse(radiusInput.Text);
                //make sure its not negative
                if (radius < 0)
                {
                    radius = defaultRadius;
                }
            }
            //default to 2 if the radius is not a correct value
            catch (FormatException)
            {
                radius = defaultRadius;
            }
            catch (OverflowException)
            {
                radius = defaultRadius;
            }
            
            //get the surrounding events and draw aline to each event
            foreach ( Event ev in eventHelper.GetSurroundingEvents(coordinates, radius))
            {
                numResults++;
                
                mapHelper.DrawLine("matchlines", ev.Location, coordinates, Color.Red);
                ToolboxEventFlowLayout.Controls.Add(ev.CreatePanel());

            }
            //assume there will be results
            Label resultNr = new Label();
            resultNr.Text = numResults + " results Found. Sorted by closest event";
            ToolboxEventFlowLayout.Controls.Add(resultNr);
            //if no results
            if (numResults == 0)
            {
                resultNr = new Label();
                resultNr.Text = "No Results Found. Search a different area";
            }
            mapHelper.DrawCircle("circle", coordinates, radius, 50);
        }

        private void ClearSelection(object sender, EventArgs e)
        {
            ToolboxEventFlowLayout.Controls.Clear();
            mapHelper.Clear("circle");
            mapHelper.Clear("matchlines");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkEventsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //clear the toolbox 
            ToolboxEventFlowLayout.Controls.Clear();

            Label linkingInfo = new Label();
            linkingInfo.AutoSize = true;
            linkingInfo.Text = "Click on two events to link them";
            //start linking
            link = true;

            Button clearButton = new Button();
            clearButton.Text = "Clear Selection";
            clearButton.Click += new EventHandler(ClearLinksSelection);

            ToolboxEventFlowLayout.Controls.Add(clearButton);
            ToolboxEventFlowLayout.Controls.Add(linkingInfo);
        }

        private void ClearLinksSelection(object sender, EventArgs e)
        {
            StopLinking();
        }

        private void radiusInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow digits and a decimal point
            if (!char.IsControl(e.KeyChar) 
                && !char.IsDigit(e.KeyChar) 
                && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }


        private void removeLinksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //clear the toolbox 
            ToolboxEventFlowLayout.Controls.Clear();

            Label linkingInfo = new Label();
            linkingInfo.AutoSize = true;
            linkingInfo.Text = "Click on two events to unlink them";
            //start unlinking
            unlink = true;
            Button clearButton = new Button();
            clearButton.Text = "Clear Selection";
            clearButton.Click += new EventHandler(ClearLinksSelection);

            ToolboxEventFlowLayout.Controls.Add(clearButton);
            ToolboxEventFlowLayout.Controls.Add(linkingInfo);
        }

        private void goToButton_Click(object sender, EventArgs e)
        {
            //center the map based on the textbox provided, 
            //if invalid, default to the default location
            if (!mapHelper.SetMapCenterLocation(locationTextBox.Text))
            {
                mapHelper.SetMapCenterLocation(DEFAULT_LOCATION);
                MessageBox.Show("Could not set location, defaulting to " + DEFAULT_LOCATION);
            }
        }

        private void locationTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            //if the enter key is pressed
            //execute the function
            //prevent the keypress to disable annoying sound 
            if (e.KeyCode == Keys.Enter)
            {
                goToButton_Click(this, e);
                e.SuppressKeyPress = true;
            }
        }

        private void mapCtrl_MouseMove(object sender, MouseEventArgs e)
        {
            //keep updating the label with the coordinats of the mouse
            double longitude = mapCtrl.FromLocalToLatLng(e.X, e.Y).Lng;
            double latitude = mapCtrl.FromLocalToLatLng(e.X, e.Y).Lat;
            mapCoordinatesLabel.Text = latitude + " " + longitude;
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //get the corrdinates 
            PointLatLng point = mapCtrl.FromLocalToLatLng(MOUSE_X_COORDINATES, MOUSE_Y_COORDINATES);
            Coordinates coordinates = new Coordinates(point.Lat, point.Lng);
            
            //get an instance of the form and set the required details 
            AddEventForm f = AddEventForm.Instance();
            f.Coordinate = coordinates;

            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog(this);
             
        }
    }
}
