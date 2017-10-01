using System;
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
        //allow for details to be set up
        public Coordinates Coordinate { get => coordinate; set => coordinate = value; }
        //to parse the date
        private string customDateFormat = "yyyy-MM-ddTHH:mm:ss";
        private Coordinates coordinate;

        MapHelper mapHelper = MapHelper.Instance();
        EventsHelper eventHelper = EventsHelper.Instance();

        //selected eventtype
        EventFactory.EventType selectedEventType;

        //global container 
        FlowLayoutPanel container = new FlowLayoutPanel
        {
            FlowDirection = FlowDirection.TopDown,
            Dock = DockStyle.Fill
        };
        //setup for singleton
        private static AddEventForm aForm;

        public static AddEventForm Instance()
        {
            if (aForm == null)
            {
                aForm = new AddEventForm();
            }
            return aForm;
        }
        private AddEventForm()
        {
            InitializeComponent();
            //just needs to be set up once

            var dateContainer = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight

            };
            dateContainer.AutoSize = true;

            Label dateLabel = new Label();
            dateLabel.TextAlign = ContentAlignment.MiddleLeft;
            dateLabel.Text = "Date and Time: ";

            DateTimePicker date = new DateTimePicker();
            date.Name = "datePicker";
            date.Format = DateTimePickerFormat.Custom;
            date.CustomFormat = customDateFormat;

            dateContainer.Controls.Add(dateLabel);
            dateContainer.Controls.Add(date);
            mainControlPanel.Controls.Add(dateContainer);

            mainControlPanel.Controls.Add(container);
        }

        private void AddEventForm_Load(object sender, EventArgs e)
        {
            LocationText = Coordinate.ToString();
            DateTime now = DateTime.Now;
            mainGroupBox.Controls.Find("datePicker",true).Single().Text = now.ToString();
        }
        
        private void radioSwitchTwitter(object sender, System.EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                selectedEventType = EventFactory.EventType.Twitter;

            container.Controls.Clear();

            //create a form specific to the event
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
                selectedEventType = EventFactory.EventType.Facebook;

            container.Controls.Clear();

            //create a form specific to the event
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
                selectedEventType = EventFactory.EventType.Video;
            container.Controls.Clear();
            
            Button b = new Button();
            b.Text = "Open Video";
            b.Click += new EventHandler(OpenVideo);

            //create a form specific to the event
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
                selectedEventType = EventFactory.EventType.Photo;

            container.Controls.Clear();

            //create a form specific to the event
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
                selectedEventType = EventFactory.EventType.TrackLog;

            container.Controls.Clear();
            //create a form specific to the event
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
        //open image dialog
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
        //open video dialog
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
        //open gpx file dialog
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
        
        //add event
        public void addEventButton_Click(object sender, EventArgs e)
        {
            Event tempEvent;
            //perhaps a better way to do this??
            try
            {
                tempEvent = EventFactory.CreateEvent(selectedEventType);
                switch (selectedEventType)
                {
                    case EventFactory.EventType.Twitter: 
                        tempEvent.CustomProperties["Text"] = mainGroupBox.Controls.Find("text", true).Single().Text;
                        mainGroupBox.Controls.Find("text", true).Single().Text = "";
                        tempEvent.Location = Coordinate;
                        break;
                    case EventFactory.EventType.Facebook:

                        tempEvent.CustomProperties["Text"] = mainGroupBox.Controls.Find("text", true).Single().Text;
                        tempEvent.Location = Coordinate;
                        mainGroupBox.Controls.Find("text", true).Single().Text = "";
                        break;
                    case EventFactory.EventType.Photo:

                        tempEvent.CustomProperties["Filepath"] = mainGroupBox.Controls.Find("imageLabel", true).Single().Text;
                        mainGroupBox.Controls.Find("imageLabel", true).Single().Text = "";
                        tempEvent.Location = Coordinate;
                        break;
                    case EventFactory.EventType.Video:

                        tempEvent.CustomProperties["Filepath"] = mainGroupBox.Controls.Find("videoLabel", true).Single().Text;
                        mainGroupBox.Controls.Find("videoLabel", true).Single().Text = "";
                        tempEvent.Location = Coordinate;
                        break;
                    case EventFactory.EventType.TrackLog:

                        tempEvent.CustomProperties["Filepath"] = mainGroupBox.Controls.Find("tracklogLabel", true).Single().Text;
                        mainGroupBox.Controls.Find("tracklogLabel", true).Single().Text = "";
                        tempEvent.Location = XMLTracklogLoader.GetStartCordinatesOfTrack(tempEvent.CustomProperties["Filepath"].ToString());
                        break;
                    default:
                        return;

                }     
                
                tempEvent.Datetimestamp = DateTime.ParseExact(mainGroupBox.Controls.Find("datePicker", true).Single().Text, customDateFormat, CultureInfo.InvariantCulture);
                eventHelper.AddEvent(tempEvent);
                this.DialogResult = DialogResult.OK;
            }
            catch (ExecutionEngineException)
            {
                MessageBox.Show("An error occured while creating event. Check if the fields are correct");
            }            
        }
    }
}
