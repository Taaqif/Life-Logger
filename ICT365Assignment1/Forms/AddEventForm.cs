﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICT365Assignment1
{
    public partial class AddEventForm : Form
    {
        public string LocationText { get { return locationLabel.Text; } set { locationLabel.Text = value; } }

        public double Latitude { get => latitude; set => latitude = value; }
        public double Longitude { get => longitude; set => longitude = value; }
        private string customDateFormat = "yyyy-MM-ddTHH:mm:ss";
        private double latitude;
        private double longitude;

        MapHelper mh = MapHelper.Instance();
        EventsHelper eh = EventsHelper.Instance();
        EventFactory.EventType selectedText;
        FlowLayoutPanel container = new FlowLayoutPanel
        {
            FlowDirection = FlowDirection.TopDown,
            Dock = DockStyle.Fill
        };
        public AddEventForm()
        {
            InitializeComponent();
        }

        private void AddEventForm_Load(object sender, EventArgs e)
        {
            LocationText = "Lat: " + latitude + " Long: " + longitude;
            var dateContainer = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight

            };
            //dateContainer.Width = mainGroupBox.Width - 10;
            dateContainer.AutoSize = true;

            Label dateLabel = new Label();
            dateLabel.TextAlign = ContentAlignment.MiddleLeft;
            dateLabel.Text = "Date and Time: ";
            DateTimePicker date = new DateTimePicker();
            date.Name = "datePicker";
            //date.Width = mainGroupBox.Width - 10;
            date.Format = DateTimePickerFormat.Custom;
            date.CustomFormat = customDateFormat;

            dateContainer.Controls.Add(dateLabel);
            dateContainer.Controls.Add(date);
            mainControlPanel.Controls.Add(dateContainer);

            mainControlPanel.Controls.Add(container);
        }
        
        private void radioSwitchTwitter(object sender, System.EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                selectedText = EventFactory.EventType.Twitter;
            container.Controls.Clear();
           
            

            

            Label textLabel = new Label();
            textLabel.Text = "Text: ";

            RichTextBox inputBox = new RichTextBox();
            inputBox.Width = mainGroupBox.Width - 10;
            inputBox.Name = "text";
           


            container.Controls.Add(textLabel);
            container.Controls.Add(inputBox);
        }
        private void radioSwitchFacebook(object sender, System.EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                selectedText = EventFactory.EventType.Facebook;

            container.Controls.Clear();
            

            Label textLabel = new Label();
            textLabel.Text = "Text: ";

            RichTextBox inputBox = new RichTextBox();
            inputBox.Width = mainGroupBox.Width - 10;
            inputBox.Name = "text";


            container.Controls.Add(textLabel);
            container.Controls.Add(inputBox);
        }
        private void radioSwitchVideo(object sender, System.EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                selectedText = EventFactory.EventType.Video;
            container.Controls.Clear();
            
            Button b = new Button();
            b.Text = "Open Video";
            b.Click += new EventHandler(OpenVideo);
            Label textLabel = new Label();
            textLabel.Text = "Selected Video: ";
            textLabel.AutoSize = true;
            textLabel.Name = "videoLabel";




            container.Controls.Add(b);
            container.Controls.Add(textLabel);

        }
        private void radioSwitchPhoto(object sender, System.EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                selectedText = EventFactory.EventType.Photo;

            container.Controls.Clear();
            

            Button b = new Button();
            b.Text = "Open Image";
            b.Click += new EventHandler(OpenImage);
            Label textLabel = new Label();
            textLabel.Text = "Selected Image: ";
            textLabel.Name = "imageLabel";
            textLabel.AutoSize = true;
            


            container.Controls.Add(b);
            container.Controls.Add(textLabel);
        }
        private void radioSwitchTracklog(object sender, System.EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                selectedText = EventFactory.EventType.TrackLog;

            container.Controls.Clear();
            Label infoLabel = new Label();
            infoLabel.Text = "Note: tracklog events will be inserted at the first point on the GPX track";
            infoLabel.AutoSize = true;
            Button b = new Button();
            b.Text = "Open Tracklog";
            b.Click += new EventHandler(OpenTracklog);
            Label textLabel = new Label();
            textLabel.Text = "Selected Tracklog: ";
            textLabel.Name = "tracklogLabel";
            textLabel.AutoSize = true;


            container.Controls.Add(infoLabel);
            container.Controls.Add(b);
            container.Controls.Add(textLabel);
        }
        private void OpenImage(object sender, System.EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    mainGroupBox.Controls.Find("imageLabel", true).Single().Text = dlg.FileName;

                }
            }
        }
        private void OpenVideo(object sender, System.EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Video";
                dlg.Filter = "Video Files (*.mp4;*.avi;*.mkv,*.mpeg)|*.MP4;*.AVI;*.MKV;*.MPEG";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    mainGroupBox.Controls.Find("videoLabel", true).Single().Text = dlg.FileName;

                }
            }
        }
        private void OpenTracklog(object sender, System.EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Tracklog";
                dlg.Filter = "Video Files (*.gpx)|*.GPX";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    mainGroupBox.Controls.Find("tracklogLabel", true).Single().Text = dlg.FileName;

                }
            }
        }
        
        public void addEventButton_Click(object sender, EventArgs e)
        {
            Event t;
            try
            {
                t = EventFactory.CreateEvent(selectedText);
                switch (selectedText)
                {
                    case EventFactory.EventType.Twitter: 
                        t.CustomProperties["Text"] = mainGroupBox.Controls.Find("text", true).Single().Text;
                        t.Location = new Coordinates(latitude, longitude);
                        break;
                    case EventFactory.EventType.Facebook:

                        t.CustomProperties["Text"] = mainGroupBox.Controls.Find("text", true).Single().Text;
                        t.Location = new Coordinates(latitude, longitude);
                        break;
                    case EventFactory.EventType.Photo:

                        t.CustomProperties["Filepath"] = mainGroupBox.Controls.Find("imageLabel", true).Single().Text;
                        t.Location = new Coordinates(latitude, longitude);
                        break;
                    case EventFactory.EventType.Video:

                        t.CustomProperties["Filepath"] = mainGroupBox.Controls.Find("videoLabel", true).Single().Text;
                        t.Location = new Coordinates(latitude, longitude);
                        break;
                    case EventFactory.EventType.TrackLog:

                        t.CustomProperties["Filepath"] = mainGroupBox.Controls.Find("tracklogLabel", true).Single().Text;
                        t.Location = XMLTracklogLoader.GetStartCordinatesOfTrack(t.CustomProperties["Filepath"].ToString());
                        break;
                    default:
                        return;

                }

                    
                
                t.Datetimestamp = DateTime.ParseExact(mainGroupBox.Controls.Find("datePicker", true).Single().Text, customDateFormat, CultureInfo.InvariantCulture);
                eh.AddEvent(t);
                this.DialogResult = DialogResult.OK;
            }
            catch (ArgumentException)
            {
                MessageBox.Show("An error occured while creating event. Check if the fields are correct");
            }
            
            

            //mh.AddMarker()
        }
    }
}
