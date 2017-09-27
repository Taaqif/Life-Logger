using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ICT365Assignment1
{
    public class VideoEvent : Event
    {

        public string Filepath
        {
            get { return (string)CustomProperties["Filepath"]; }
            set {if (value.Trim().Length > 0)
                {
                    CustomProperties["Text"] = value;
                }
                else
                {
                    throw new ArgumentException("String cannot be empty");
                }}
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
            dateText.Text = this.Datetimestamp.ToString();

            PictureBox pb = new PictureBox();
            pb.Image = orig;
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.Dock = DockStyle.Fill;
            pb.Height = 200;
            Label filepathText = new Label();
            filepathText.AutoSize = true;

            filepathText.Text = this.Filepath;
            container.Controls.Add(eventType);
            container.Controls.Add(locationText);
            container.Controls.Add(dateText);
            container.Controls.Add(pb);
            container.Controls.Add(filepathText);

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
            catch(Exception)
            {
                thumb = new Bitmap("error.png");
            }
            
            MapHelper mh = MapHelper.Instance();
            mh.AddMarker("video", new Bitmap(thumb, size, size), this.Location, "Video", this);

        }

        public override XElement ToXElement(XNamespace ns)
        {
            XElement eventElement = new XElement(ns + "video",
                       new XElement(ns + "filepath", this.CustomProperties["Filepath"]),
                       new XElement(ns + "location",
                           new XElement(ns + "lat", this.Location.Latitude),
                           new XElement(ns + "long", this.Location.Longitude)),
                       new XElement(ns + "datetimestamp", this.Datetimestamp));
            return eventElement;
        }
    }
}