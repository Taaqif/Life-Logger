using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ICT365Assignment1
{
    class XMLTracklogLoader
    {
        public struct WayPoints
        {
            Coordinates location;
            double elevation;
            string name;
            DateTime date;

            public Coordinates Coordinates { get => location; set => location = value; }
            public double Elevation { get => elevation; set => elevation = value; }
            public string Name { get => name; set => name = value; }
            public DateTime Date { get => date; set => date = value; }
        }
        public struct Track
        {
            public Track(string name)
            {
                this.name = name;
                points = new List<TrackPoint>();
            }  
            public struct TrackPoint
            {
                Coordinates coordinates;
                double elevation;
                DateTime date;

                public Coordinates Coordinates { get => coordinates; set => coordinates = value; }
                public double Elevation { get => elevation; set => elevation = value; }
                public DateTime Date { get => date; set => date = value; }
            }
            
            List<TrackPoint> points;
            string name;

            public string Name { get => name; set => name = value; }
            public List<TrackPoint> Segments { get => points; set => points = value; }
        }
            
        private static XDocument Load(string file)
        {
            XDocument doc = XDocument.Load(file);
            return doc;
        }

           
        private static XNamespace GetNameSpace()
        {
            XNamespace ns = XNamespace.Get("http://www.topografix.com/GPX/1/1");
            return ns;
        }

            
        public static List<WayPoints> GetWaypoints(string file)
        {
            XDocument doc = Load(file);
            XNamespace ns = GetNameSpace();
            List<WayPoints> wayPointList = new List<WayPoints>();
            var waypoints = from waypoint in doc.Descendants(ns + "wpt")
                            select new
                            {
                                Latitude = waypoint.Attribute("lat").Value,
                                Longitude = waypoint.Attribute("lon").Value,
                                Elevation = waypoint.Element(ns + "ele") != null ?
                                    waypoint.Element(ns + "ele").Value : null,
                                Name = waypoint.Element(ns + "name") != null ?
                                    waypoint.Element(ns + "name").Value : null,
                                Date = waypoint.Element(ns + "cmt") != null ?
                                    waypoint.Element(ns + "cmt").Value : null
                            };

            foreach (var wpt in waypoints)
            {
                WayPoints temp = new WayPoints();
                try
                {
                    temp.Coordinates = new Coordinates(Double.Parse(wpt.Latitude), Double.Parse(wpt.Longitude));
                    //temp.Date = DateTime.Parse(wpt.Date);
                    temp.Elevation = Double.Parse(wpt.Elevation);
                    temp.Name = wpt.Name;
                    wayPointList.Add(temp);

                }catch (FormatException)
                {
                    Console.WriteLine("Invalid data. Skipping entry");
                }
            }

            return wayPointList;
        }

        public static Coordinates GetStartCordinatesOfTrack(string file)
        {
            List<XMLTracklogLoader.Track> tracks = XMLTracklogLoader.GetTracks(file);
            List<Coordinates> points = new List<Coordinates>();
            foreach (var track in tracks)
            {
                foreach (var point in track.Segments)
                {
                    points.Add(point.Coordinates);
                }
            }
            return points[0];
        }
        public static Coordinates GetEndCordinatesOfTrack(string file)
        {
            List<XMLTracklogLoader.Track> tracks = XMLTracklogLoader.GetTracks(file);
            List<Coordinates> points = new List<Coordinates>();
            foreach (var track in tracks)
            {
                foreach (var point in track.Segments)
                {
                    points.Add(point.Coordinates);
                }
            }
            if(points.Count > 0)
            {
                return points[points.Count -1];
            }
            return points[0];

        }
        public static string GetTrackName(string file)
        {
            List<XMLTracklogLoader.Track> tracks = XMLTracklogLoader.GetTracks(file);
            string name = "";
            foreach (var track in tracks)
            {
                name = track.Name;   
            }
            return name;

        }
        public static List<Track> GetTracks(string file)
        {
            List<Track> trackList = new List<Track>();
            XDocument gpxDoc = Load(file);
            XNamespace ns = GetNameSpace();
            var tracks = from track in gpxDoc.Descendants(ns + "trk")
                            select new
                            {
                                Name = track.Element(ns + "name") != null ?
                            track.Element(ns + "name").Value : null,
                                Segs = (
                                from trackpoint in track.Descendants(ns + "trkpt")
                                select new
                                {
                                    Latitude = trackpoint.Attribute("lat").Value,
                                    Longitude = trackpoint.Attribute("lon").Value,
                                    Elevation = trackpoint.Element(ns + "ele") != null ?
                                    trackpoint.Element(ns + "ele").Value : null,
                                    Time = trackpoint.Element(ns + "time") != null ?
                                    trackpoint.Element(ns + "time").Value : null
                                }
                                )
                            };

            foreach (var trk in tracks)
            {
                Track track = new Track(trk.Name);
                // Populate track data objects. 
                foreach (var trkSeg in trk.Segs)
                {
                    Track.TrackPoint segment = new Track.TrackPoint();
                    try
                    {
                            
                        segment.Coordinates = new Coordinates(Double.Parse(trkSeg.Latitude), Double.Parse(trkSeg.Longitude));
                        segment.Elevation = Double.Parse(trkSeg.Elevation);
                        segment.Date = DateTime.Parse(trkSeg.Time);
                        track.Segments.Add(segment);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Error tryin to parse track data. Skipping");
                    }
                        
                    // Populate detailed track segments 
                    // in the object model here. 
                    //sb.Append(
                    //  string.Format("Track:{0} - Latitude:{1} Longitude:{2} " +
                    //               "Elevation:{3} Date:{4}\n",
                    //  trk.Name, trkSeg.Latitude,
                    //  trkSeg.Longitude, trkSeg.Elevation,
                    //  trkSeg.Time));
                }
                trackList.Add(track);
            }
            return trackList;
        }
    }
}
