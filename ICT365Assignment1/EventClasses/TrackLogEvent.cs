using GMap.NET;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ICT365Assignment1
{
    public class TrackLogEvent : Event
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
            eventType.Text = this.ID + " Tracklog Event";
            eventType.AutoSize = true;
            eventType.Font = new Font(eventType.Font.Name, 15, FontStyle.Bold);
            Label locationText = new Label();
            locationText.AutoSize = true;

            

            MapHelper mh = MapHelper.Instance();
            
            locationText.Text = "Start Location: " + XMLTracklogLoader.GetStartCordinatesOfTrack(this.Filepath);
            
            locationText.Text += "\nEnd Location: " + XMLTracklogLoader.GetEndCordinatesOfTrack(this.Filepath);

            Label trackName = new Label();
            trackName.AutoSize = true;
            trackName.Text = "TrackName: " + XMLTracklogLoader.GetTrackName(this.Filepath);
            List<XMLTracklogLoader.WayPoints> waypoints = XMLTracklogLoader.GetWaypoints(this.Filepath);
            Label waypointHeading = new Label();
            waypointHeading.Text = "\nWaypoints";
            waypointHeading.AutoSize = true;
            Label waypointLabel = new Label();
            waypointLabel.AutoSize = true;
            foreach (var point in waypoints)
            {
                waypointLabel.Text += point.Name+ " " + point.Coordinates + "\n" ; 
            }
            
            Label dateText = new Label();
            dateText.AutoSize = true;
            dateText.Text = "Date: " + this.Datetimestamp.ToString();

            Label linkHeading = new Label();
            linkHeading.Text = "\nLinks to event: ";
            linkHeading.AutoSize = true;
            Label linkLabel = new Label();
            linkLabel.AutoSize = true;
            foreach(string link in this.Links)
            {
                linkLabel.Text += link + "\n";
            }
            
            container.Controls.Add(eventType);
            container.Controls.Add(locationText);
            container.Controls.Add(dateText);
            container.Controls.Add(trackName);
            container.Controls.Add(waypointHeading);
            container.Controls.Add(waypointLabel);
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
        public override void Render()
        {
            List<XMLTracklogLoader.Track> tracks = XMLTracklogLoader.GetTracks(this.Filepath);
            MapHelper mh = MapHelper.Instance();

            List<PointLatLng> points = new List<PointLatLng>();
            string name = null;
            foreach (var track in tracks)
            {
                foreach (var point in track.Segments)
                {
                    points.Add(new PointLatLng(point.Coordinates.Latitude, point.Coordinates.Longitude));
                    mh.AddMarker("tracklogPoints", new Bitmap(20,20), point.Coordinates, "Date: " + point.Date +"\n" + "elevation: " + point.Elevation, this);
                }
                name = track.Name;
                mh.AddRoute("tracklog", points);
            }
            
            //used to resize the bitmap
            Bitmap start = new Bitmap(Properties.Resources.start);
            Bitmap end = new Bitmap(Properties.Resources.end);
            int size = 20;

            mh.AddMarker("tracklog", new Bitmap(end, size, size), new Coordinates(points[0].Lat, points[0].Lng), "Track start\n" + name, this);
            mh.AddMarker("tracklog", new Bitmap(start, size,size), new Coordinates(points[points.Count - 1].Lat, points[points.Count - 1].Lng), "Track end\n" + name, this);
            List<XMLTracklogLoader.WayPoints> waypoints = XMLTracklogLoader.GetWaypoints(this.Filepath);
            List<PointLatLng> waypoint = new List<PointLatLng>();

            Bitmap wpimage = new Bitmap(Properties.Resources.waypoint);
            foreach (var point in waypoints)
            {
                
                mh.AddMarker("waypoints", new Bitmap(wpimage,size,size), point.Coordinates, "Track " + name + " Waypoint\n" + point.Name, this);
            }

        }

        public override XElement ToXElement(XNamespace lle)
        {
            XElement eventElement = new XElement(lle + "tracklog",
                       new XElement(lle + "filepath", this.CustomProperties["Filepath"]),
                       new XElement(lle + "location",
                            new XElement(lle + "lat", this.Location.Latitude),
                            new XElement(lle + "long", this.Location.Longitude)),
                       new XElement(lle + "datetimestamp", this.Datetimestamp));
            return eventElement;
        }
    }
}