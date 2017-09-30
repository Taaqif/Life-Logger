﻿using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ICT365Assignment1
{
    public class FacebookEvent : Event
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
            eventType.Text = this.ID + " Facebook Event";
            eventType.AutoSize = true;
            eventType.Font = new Font(eventType.Font.Name, 15, FontStyle.Bold);
            Label locationText = new Label();
            locationText.AutoSize = true;
           
            locationText.Text = this.Location.ToString();
            Label dateText = new Label();
            dateText.AutoSize = true;
            dateText.Text = "Date: " + this.Datetimestamp.ToString();

            Label infoText = new Label();
            infoText.Text = this.Text;
            Label linkHeading = new Label();
            linkHeading.Text = "\nLinks to event:";
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
            container.Controls.Add(infoText);
            container.Controls.Add(linkHeading);
            container.Controls.Add(linkLabel);

            return container;
        }
        public override bool isValid()
        {
            if (this.Text.Trim().Length <= 0)
            {
                return false;
            }
            return true;
        }
        public override void Render()
        {
            MapHelper mapHelper = MapHelper.Instance();
            
           
            string tooltip = this.Text;
            mapHelper.AddMarker("facebook", new Bitmap(Properties.Resources.facebook), this.Location, tooltip, this);
        }

        

        public override XElement ToXElement(XNamespace lle)
        {
            XElement eventElement = new XElement(lle + "facebook-status-update",
                        new XElement(lle + "text", this.CustomProperties["Text"]),
                        new XElement(lle + "location",
                            new XElement(lle + "lat", this.Location.Latitude),
                            new XElement(lle + "long", this.Location.Longitude)),
                        new XElement(lle + "datetimestamp", this.Datetimestamp));
            return eventElement;
        }
    }
}