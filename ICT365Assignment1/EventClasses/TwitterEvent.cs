using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ICT365Assignment1
{
    public class TwitterEvent : Event
    {
        //private string text;
        //public string Text { get => text; set => text = value; }
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
            dateText.Text = this.Datetimestamp.ToString();
            container.Controls.Add(eventType);
            container.Controls.Add(locationText);
            container.Controls.Add(dateText);
            container.Controls.Add(infoText);

            return container;
        }

        public override bool isValid()
        {
            if(this.Text.Trim().Length <= 0)
            {
                return false;
            }
            return true;
        }

        public override void Render()
        {
            string iconPath;
            iconPath = "twitter.png";
            MapHelper mh = MapHelper.Instance();
            mh.AddMarker("twitter", new Bitmap(iconPath), this.Location, this.Text, this);

        }

        public override XElement ToXElement(XNamespace ns)
        {
            XElement eventElement = new XElement(ns + "tweet",
                        new XElement(ns + "text", this.CustomProperties["Text"]),
                        new XElement(ns + "location",
                            new XElement(ns + "lat", this.Location.Latitude),
                            new XElement(ns + "long", this.Location.Longitude)),
                        new XElement(ns + "datetimestamp", this.Datetimestamp));
            return eventElement;
        }
    }
}