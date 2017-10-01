using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ICT365Assignment1
{
    public class TwitterEvent : Event
    {
        public string Text
        {
            get { return (string)CustomProperties["Text"]; }
            set { CustomProperties["Text"] = value; }
        }

        public override Panel CreatePanel()
        {
            var container = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.TopDown

            };
            container.AutoSize = true;

            Label eventType = new Label();
            eventType.Text = this.ID + " Tweet";
            eventType.AutoSize = true;
            eventType.Font = new Font(eventType.Font.Name, 15, FontStyle.Bold);

            Label locationText = new Label();
            locationText.AutoSize = true;
            
            locationText.Text = this.Location.ToString();

            Label infoText = new Label();
            infoText.Text = this.Text;
            Label dateText = new Label();
            dateText.AutoSize = true;
            dateText.Text = "Date: " + this.Datetimestamp.ToString();

            Label linkHeading = new Label();
            linkHeading.Text = "\nLinks to event: ";
            linkHeading.Font = new Font(linkHeading.Font, FontStyle.Bold);
            linkHeading.AutoSize = true;
            Label linkLabel = new Label();
            linkLabel.AutoSize = true;
            StringBuilder linkString = new StringBuilder();

            foreach (string link in this.Links)
            {
                linkString.AppendLine(link);
            }
            linkLabel.Text = linkString.ToString();
            container.Controls.Add(eventType);
            container.Controls.Add(locationText);
            container.Controls.Add(dateText);
            container.Controls.Add(infoText);
            container.Controls.Add(linkHeading);
            container.Controls.Add(linkLabel);

            return container;
        }

        public override bool IsValid()
        {
            if(this.Text.Trim().Length <= 0)
            {
                return false;
            }
            return true;
        }

        public override void Render()
        {
            
            MapHelper mh = MapHelper.Instance();
            mh.AddMarker("twitter", new Bitmap(Properties.Resources.twitter), this.Location, "Date: " + this.Datetimestamp.ToString() + "\n" + this.Text, this);

        }

        public override XElement ToXElement(XNamespace lle)
        {
            XElement eventElement = new XElement(lle + "tweet",
                        new XElement(lle + "text", this.CustomProperties["Text"]),
                        new XElement(lle + "location",
                            new XElement(lle + "lat", this.Location.Latitude),
                            new XElement(lle + "long", this.Location.Longitude)),
                        new XElement(lle + "datetimestamp", this.Datetimestamp));
            return eventElement;
        }
    } 
}