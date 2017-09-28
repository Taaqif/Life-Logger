using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ICT365Assignment1
{
    public class PhotoEvent : Event
    {

        public string Filepath
        {
            get { return (string)CustomProperties["Filepath"]; }
            set { CustomProperties["Filepath"] = value; }
        }

        public override Panel CreatePanel()
        {
            var container = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.TopDown

            };
            container.AutoSize = true;

            Label eventType = new Label();
            eventType.Text = this.ID + " Photo Event";
            eventType.AutoSize = true;
            eventType.Font = new Font(eventType.Font.Name, 15, FontStyle.Bold);
            Label locationText = new Label();
            locationText.AutoSize = true;
            
            locationText.Text = this.Location.ToString();

            PictureBox pb = new PictureBox();
            pb.ImageLocation = this.Filepath;
            pb.Height = 200;
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.Dock = DockStyle.Fill;
            Label filepathText = new Label();
            filepathText.AutoSize = true;

            filepathText.Text = this.Filepath;
            Label dateText = new Label();
            dateText.AutoSize = true;
            dateText.Text = "Date: " + this.Datetimestamp.ToString();

            Label linkHeading = new Label();
            linkHeading.Text = "\nLiks to event:";
            linkHeading.AutoSize = true;
            Label linkLabel = new Label();
            linkLabel.AutoSize = true;
            foreach (string link in this.Links)
            {
                linkLabel.Text += link + "\n";
            }
            container.Controls.Add(eventType);
            container.Controls.Add(locationText);
            container.Controls.Add(dateText);
            container.Controls.Add(pb);
            container.Controls.Add(filepathText);
            container.Controls.Add(linkHeading);
            container.Controls.Add(linkLabel);

            return container;
        }
        public override bool isValid()
        {
            if (this.Filepath.Trim().Length <= 0)
            {
                return false;
            }
            return true;
        }
        

        private void OpenFolder_Click(object sender, EventArgs e)
        {
            //if (Directory.Exists(folderPath))
            //{
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
            {
                FileName = this.Filepath,
                UseShellExecute = true,
                Verb = "open"
            });
            //}
            //else
            //{
            //    MessageBox.Show(string.Format("{0} Directory does not exist!", folderPath));
            //}
        }
        public override void Render()
        {
            MapHelper mh = MapHelper.Instance();
            string iconPath;
            iconPath = this.Filepath;
            int size = 52;
            Bitmap thumb = null;
            try
            {
                thumb = new Bitmap(iconPath);
            }
            catch (ArgumentException e)
            {
                //Have error image here 
                
                thumb = new Bitmap(Properties.Resources.error);
            }
            
            mh.AddMarker("photo", new Bitmap(thumb, size, size), this.Location, "Photo", this);

        }

        public override XElement ToXElement(XNamespace ns)
        {
            XElement eventElement = new XElement(ns + "photo",
                        new XElement(ns + "filepath", this.CustomProperties["Filepath"]),
                        new XElement(ns + "location",
                            new XElement(ns + "lat", this.Location.Latitude),
                            new XElement(ns + "long", this.Location.Longitude)),
                        new XElement(ns + "datetimestamp", this.Datetimestamp));
            return eventElement;
        }
    }
}