﻿using System;
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
        GMapOverlay markers = new GMapOverlay("markers");
        MapHelper mh;
        EventsHelper eh;
        int globalX, globalY;
        XNamespace ns = XNamespace.Get("http://www.xyz.org/lifelogevents");
        Dictionary<String, Event> EventDictionary = new Dictionary<string, Event>();
        private bool linking;
        private List<Event> eventLinks = new List<Event>(); 
        public MainForm()
        {
            InitializeComponent();
            loadData("lle.xml");
        }

        public void loadData(string file)
        {
            mh = MapHelper.Instance();
            eh = EventsHelper.Instance();
            eh.loadFromXML(file);
            mh.AssignMapControl(mapCtrl);
            mh.ConfigMap();
            eh.renderEvents();
        }

        
        private void MainForm_Load(object sender, EventArgs e)
        {
            
            

        }

        private void mapCtrl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right && !linking)
            {
                globalX = e.X;
                globalY = e.Y;
                
                mapContextMenu.Show(mapCtrl, e.Location);
            }
            
        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

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

        private void MainForm_Shown(object sender, EventArgs e)
        {

        }
        private void gmap_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            if(e.Button == System.Windows.Forms.MouseButtons.Left && item.Tag is Event)
            {
                if (linking)
                {
                    AddLink((Event)item.Tag);
                }
                else
                {
                    EventDetailsForm f = EventDetailsForm.Instance();
                    f.Details = ((Event)item.Tag).CreatePanel();
                    f.StartPosition = FormStartPosition.CenterParent;
                    //EventDetailsForm f = new EventDetailsForm()
                    //{
                    //    Details = ((Event)item.Tag).CreatePanel(),
                    //    StartPosition = FormStartPosition.CenterParent
                    //};
                    f.ShowDialog();
                }
                
            }
            
            //Console.WriteLine(String.Format("Marker {0} was clicked.", item.Tag));
        }

        private void AddLink(Event e)
        {
            if(eventLinks.Count < 2)
            {
                eventLinks.Add(e);
            }
            if (eventLinks.Count == 2)
            {
                linking = false;
                
                eh.LinkEvents(eventLinks[0], eventLinks[1]);
                eventLinks = new List<Event>();
            }
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Coordinates coordinates = new Coordinates(mapCtrl.FromLocalToLatLng(globalX, globalY).Lat, mapCtrl.FromLocalToLatLng(globalX, globalY).Lng);
            ToolboxEventFlowLayout.Controls.Clear();
            Button clearButton = new Button();
            clearButton.Text = "Clear Selection";
            clearButton.Click += new EventHandler(ClearSelection);
            ToolboxEventFlowLayout.Controls.Add(clearButton);
            mh.Clear("matchlines");
            int numResults = 0;
            int radius = 0;
            try
            {
                radius = Int32.Parse(radiusInput.Text);
            }catch (FormatException)
            {
                radius = 2;
            }
            
            foreach ( Event ev in eh.GetSurroundingEvents(coordinates, radius))
            {
                numResults++;
                mh.DrawLine("matchlines", ev.Location, coordinates, Color.Red);


                ToolboxEventFlowLayout.Controls.Add(ev.CreatePanel());

            }
            if(numResults == 0)
            {
                Label resultNr = new Label();
                resultNr.Text = "No Results Found. Search a different area";
                ToolboxEventFlowLayout.Controls.Add(resultNr);
            }
            mh.DrawCircle(coordinates, radius, 50);
        }

        private void ClearSelection(object sender, EventArgs e)
        {
            ToolboxEventFlowLayout.Controls.Clear();
            mh.ClearCircle();
            mh.Clear("matchlines");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkEventsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolboxEventFlowLayout.Controls.Clear();
            Label linkingInfo = new Label();
            linkingInfo.AutoSize = true;
            linkingInfo.Text = "Click on two events to link them";
            linking = true;
            ToolboxEventFlowLayout.Controls.Add(linkingInfo);
        }

        private void radiusInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void radiusInput_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double X = mapCtrl.FromLocalToLatLng(globalX, globalY).Lng;
            double Y = mapCtrl.FromLocalToLatLng(globalX, globalY).Lat;

            AddEventForm f = new AddEventForm()
            {
                Latitude = Y,
                Longitude = X,

                StartPosition = FormStartPosition.CenterParent
            };
            f.ShowDialog(this);
             
        }
    }
}
