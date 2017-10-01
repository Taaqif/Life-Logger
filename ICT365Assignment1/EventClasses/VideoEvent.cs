using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ICT365Assignment1
{
    public class VideoEvent : Event
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
            Stream thumbJpegStream = new MemoryStream();
            var ffMpeg = new NReco.VideoConverter.FFMpegConverter();
            ffMpeg.GetVideoThumbnail(this.Filepath, thumbJpegStream, 5);
            Bitmap orig = new Bitmap(thumbJpegStream);

            container.AutoSize = true;

            Label eventType = new Label();
            
            eventType.Text = this.ID + " Video Event";
            eventType.AutoSize = true;
            eventType.Font = new Font(eventType.Font.Name, 15, FontStyle.Bold);

            Label locationText = new Label();
            locationText.AutoSize = true;

            locationText.Text = this.Location.ToString();

            Label dateText = new Label();
            dateText.AutoSize = true;
            dateText.Text = "Date: " + this.Datetimestamp.ToString();

            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = orig;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.Height = 200;
            Label filepathText = new Label();
            filepathText.AutoSize = true;

            filepathText.Text = this.Filepath;

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
            container.Controls.Add(pictureBox);
            container.Controls.Add(filepathText);
            container.Controls.Add(linkHeading);
            container.Controls.Add(linkLabel);

            return container;
        }
        public override bool IsValid()
        {
            if (this.Filepath.Trim().Length <= 0)
            {
                return false;
            }
            return true;
        }
        public override void Render()
        {
            Bitmap thumb = null;
            int size = 52;
            try
            {
                Stream thumbJpegStream = new MemoryStream();
                var ffMpeg = new NReco.VideoConverter.FFMpegConverter();
                ffMpeg.GetVideoThumbnail(this.Filepath, thumbJpegStream, 1);
                thumb = new Bitmap(thumbJpegStream);
            }
            catch(ArgumentException)
            {
               thumb = new Bitmap(Properties.Resources.error);
            }
            
            MapHelper mh = MapHelper.Instance();
            mh.AddMarker("video", new Bitmap(thumb, size, size), this.Location, "Date: " + this.Datetimestamp.ToString() + "\nVideo", this);

        }

        public override XElement ToXElement(XNamespace lle)
        {
            XElement eventElement = new XElement(lle + "video",
                       new XElement(lle + "filepath", this.CustomProperties["Filepath"]),
                       new XElement(lle + "location",
                           new XElement(lle + "lat", this.Location.Latitude),
                           new XElement(lle + "long", this.Location.Longitude)),
                       new XElement(lle + "datetimestamp", this.Datetimestamp));
            return eventElement;
        }
    }
}