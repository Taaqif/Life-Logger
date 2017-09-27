using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ICT365Assignment1
{
    public class EventsHelper
    {
        MapHelper mh = MapHelper.Instance();
        Dictionary<String, Event> EventDictionary = new Dictionary<string, Event>();
        XNamespace ns = XNamespace.Get("http://www.xyz.org/lifelogevents");
        XNamespace nsa = XNamespace.Get("http://www.w3.org/2001/12/soap-envelope");
        private static EventsHelper aEvent;
        private string highestID = null;
        String file;
        private XDocument doc;
        public static EventsHelper Instance()
        {
            if (aEvent == null)
            {
                aEvent = new EventsHelper();
            }
            return aEvent;
        }
        public void loadFromXML(String f)
        {
            XDocument document = null;
            file = f;
            try
            {
                document = XDocument.Load(file);
                
            }
            catch (FileNotFoundException e)
            {
                throw new ArgumentException("File not found");
            }
            doc = document;
            PopulateEvents();
           
        }
        public void IncrementID()
        {
            highestID = Regex.Replace(highestID, @"(\d+)",
                m => (Convert.ToInt32(m.Groups[1].Value) + 1).ToString());
        }
        public void AddEvent(Event e)
        {
            if (!e.isValid())
            {
                throw new ArgumentException("Event is not valid");
            }
            else
            {
                IncrementID();
                var newEvent = new XElement(ns + "Event",
                                new XElement(ns + "eventid", highestID));
                newEvent.Add(e.ToXElement(ns));
                //switch (e)
                //{
                //    case FacebookEvent facebook:

                //        break;
                //    case TwitterEvent twitter:
                //        newEvent.Add(new XElement(ns + "tweet",
                //            new XElement(ns + "text", "q"),
                //            new XElement(ns + "location",
                //                new XElement(ns + "lat", "1"),
                //                new XElement(ns + "long", "2")),
                //            new XElement(ns + "datetimestamp", "datetime")));
                //        //newEvent.Add(new XElement(ns + "tweet",
                //        //    new XElement(ns + "text", ""),
                //        //    new XElement(ns + "location", 
                //        //        new XElement(ns + "lat", twitter.Location.Latitude),
                //        //        new XElement(ns + "long", twitter.Location.Longitude)),
                //        //    new XElement(ns + "datetimestamp", "datetime")));
                //        break;
                //    case PhotoEvent photo:
                //        break;
                //    case VideoEvent video:
                //        break;
                //    case TrackLogEvent tracklog:
                //        break;
                //    default:
                //        break;
                //}
                e.ID = highestID;
                EventDictionary.Add(highestID, e);
                doc.Descendants(nsa + "Body").Single().Add(newEvent);
                doc.Save(file);
                //EventDictionary.Add("ffff", e);
                e.Render();
            }
            
            
        }

        public void LinkEvents(Event event1, Event event2)
        {
            event1.Links.Add(event2.ID);
            //add and save new links here 
            mh.DrawLine("links", event1.Location, event2.Location, Color.Green);
        }
        public Event GetEvent(string ID)
        {
            return EventDictionary[ID];
        }
        public List<Event> GetSurroundingEvents(Coordinates coordinates, double radius)
        {
           
            List<Event> eventList = new List<Event>();
            double KMSconst = 6371;

           
            //https://stackoverflow.com/questions/7783684/select-coordinates-which-fall-within-a-radius-of-a-central-point
           
            //find points within a radius using harvoursine formula
            var e = from ev in EventDictionary
                        let distance = Math.Acos(Math.Sin(ev.Value.Location.Latitude * 0.0175) *
                            Math.Sin(coordinates.Latitude * 0.0175) +
                            Math.Cos(ev.Value.Location.Latitude * 0.0175) *
                            Math.Cos(coordinates.Latitude * 0.0175) *
                            Math.Cos((coordinates.Longitude * 0.0175) - (ev.Value.Location.Longitude * 0.0175))
                        ) * KMSconst
                        where distance <= radius
                        orderby distance
                        select ev.Value;
            return e.ToList<Event>();
        }

        private void PopulateEvents()
        {
            //reset the dictionary
            EventDictionary = new Dictionary<string, Event>();
            
            foreach (XElement @event in doc.Descendants(ns + "Event"))
            {
                //TODO: Fix this
                //assumes the last element will always be the one that contains the event details, which it might not be all the time
                XElement eventDetails = @event.Elements().Last();
                
                string id = @event.Element(ns + "eventid").Value;
                if (id.CompareTo(highestID) > 0)
                {
                    highestID = id;
                    Console.WriteLine(highestID);
                }
                double latitude = 0;
                double longitude = 0;
                string datetime = "";
                try
                {
                    latitude = Double.Parse(eventDetails.Element(ns + "location").Element(ns + "lat").Value);
                    longitude = Double.Parse(eventDetails.Element(ns + "location").Element(ns + "long").Value);
                    datetime = eventDetails.Element(ns + "datetimestamp").Value;
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("No location or date data for this event found. Skipping");
                }

                Event t;

                switch (eventDetails.Name.LocalName)
                {
                    case "photo":
                        t = EventFactory.CreateEvent(EventFactory.EventType.Photo);
                        t.CustomProperties["Filepath"] = eventDetails.Element(ns + "filepath").Value;
                        break;
                    case "tweet":
                        t = EventFactory.CreateEvent(EventFactory.EventType.Twitter);
                        t.CustomProperties["Text"] = eventDetails.Element(ns + "text").Value;
                        break;
                    case "facebook-status-update":
                        t = EventFactory.CreateEvent(EventFactory.EventType.Facbook);
                        t.CustomProperties["Text"] = eventDetails.Element(ns + "text").Value;
                        break;
                    case "video":
                        t = EventFactory.CreateEvent(EventFactory.EventType.Video);
                        t.CustomProperties["Filepath"] = eventDetails.Element(ns + "filepath").Value;
                        break;
                    
                    case "tracklog":
                        t = EventFactory.CreateEvent(EventFactory.EventType.TrackLog);
                        //t.Location = new Coordinates(latitude, longitude);
                        t.CustomProperties["Filepath"] = eventDetails.Element(ns + "filepath").Value;
                        break;
                    default:
                        return;
                }
                t.Location = new Coordinates(latitude, longitude);
                if (datetime.Length > 0)
                {
                    try
                    {
                        t.Datetimestamp = DateTime.Parse(datetime);

                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid date format. Skipping");
                    }
                }
                else
                {
                    Console.WriteLine("No date found for event");
                }

                t.ID = id;

                try
                {
                    foreach (XElement linkedEvent in @event.Element(ns + "link").Descendants(ns + "eventid"))
                    {
                        t.Links.Add(linkedEvent.Value);
                        
                    }
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("No links found");
                }
                
                EventDictionary.Add(id, t);

            }

        }
        public void renderEvents()
        {
            mh.ClearMap();
            foreach (var @event in EventDictionary)
            {
                @event.Value.Render();
                foreach(string linkID in @event.Value.Links)
                {
                    mh.DrawLine("links", @event.Value.Location, GetEvent(linkID).Location, Color.Green);
                }
                //TODO: make each seperate function
                //double longitude, latitude;
                //longitude = e.Value.Location.Longitude;
                //latitude = e.Value.Location.Latitude;
                //string iconPath = null;
                //switch (e.Value)
                //{
                //    case FacebookEvent facebook:
                //        facebook.Render();
                //        iconPath = "facebook.png";
                //        //mh.AddMarker("facebook", new Bitmap(iconPath), latitude, longitude, facebook.Text);
                //        break;
                //    case TwitterEvent twitter:
                //        iconPath = "twitter.png";
                //        mh.AddMarker("twitter", new Bitmap(iconPath), latitude, longitude, twitter.Text);
                //        break;
                //    case PhotoEvent photo:
                //        iconPath = photo.Filepath;
                //        Bitmap original = new Bitmap(iconPath);
                //        mh.AddMarker("photo", new Bitmap(original, 42, 42), latitude, longitude, null);
                //        break;
                //    case VideoEvent video:
                //        Stream thumbJpegStream = new MemoryStream();
                //        var ffMpeg = new NReco.VideoConverter.FFMpegConverter();
                //        ffMpeg.GetVideoThumbnail(video.Filepath, thumbJpegStream, 5);
                //        Bitmap orig = new Bitmap(thumbJpegStream);
                //        mh.AddMarker("video", new Bitmap(orig, 42, 42), latitude, longitude, null);
                //        break;
                //    case TrackLogEvent tracklog:
                //        break;
                //    default:
                //        break;
                //}
                //if (e.Value.GetType() == typeof(TwitterEvent))
                //{

                //    iconPath = "twitter.png";
                //    mh.AddMarker("twitter", new Bitmap(iconPath), latitude, longitude, ((TwitterEvent)e.Value).Text);

                //}
                //if (e.Value.GetType() == typeof(FacebookEvent))
                //{
                //    iconPath = "facebook.png";
                //    mh.AddMarker("facebook", new Bitmap(iconPath), latitude, longitude, ((FacebookEvent)e.Value).Text);


                //}
                //if (e.Value.GetType() == typeof(PhotoEvent))
                //{
                //    iconPath = ((PhotoEvent)e.Value).Filepath;
                //    Bitmap original = new Bitmap(iconPath);
                //    mh.AddMarker("photo", new Bitmap(original, 42, 42), latitude, longitude, null);

                //}
                //if (e.Value.GetType() == typeof(VideoEvent))
                //{
                //    Stream thumbJpegStream = new MemoryStream();
                //    var ffMpeg = new NReco.VideoConverter.FFMpegConverter();
                //    ffMpeg.GetVideoThumbnail(((VideoEvent)e.Value).Filepath, thumbJpegStream, 5);
                //    Bitmap original = new Bitmap(thumbJpegStream);
                //    mh.AddMarker("video", new Bitmap(original, 42, 42), latitude, longitude, null);

                //}

            }
        }
    }
}
