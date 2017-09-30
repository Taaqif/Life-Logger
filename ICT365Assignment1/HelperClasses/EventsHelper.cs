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
        XNamespace lle = XNamespace.Get("http://www.xyz.org/lifelogevents");
        XNamespace soapENV = XNamespace.Get("http://www.w3.org/2001/12/soap-envelope");
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
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("File not found");
            }
            doc = document;
            PopulateEvents();
           
        }
        private void IncrementID()
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
                var newEvent = new XElement(lle + "Event",
                                new XElement(lle + "eventid", highestID),
                                new XElement(lle + "link"));
                newEvent.Add(e.ToXElement(lle));
                
                e.ID = highestID;
                EventDictionary.Add(highestID, e);
                doc.Descendants(soapENV + "Body").Single().Add(newEvent);
                doc.Save(file);
                e.Render();
            }
            
            
        }

        public bool UnLinkEvents(Event event1, Event event2)
        {
            bool unlinked = false;
            if (event1.Links.Remove(event2.ID))
            {
                doc.Descendants(lle + "Event")
                    .Where(id => id.Element(lle + "eventid").Value == event1.ID)
                    .Single()
                    .Element(lle + "link")
                    .Descendants(lle + "eventid")
                    .Where(id => id.Value == event2.ID)
                    .Single()
                    .Remove();
                unlinked = true;
            }
            if (event2.Links.Remove(event1.ID))
            {
                doc.Descendants(lle + "Event")
                    .Where(id => id.Element(lle + "eventid").Value == event2.ID)
                    .Single()
                    .Element(lle + "link")
                    .Descendants(lle + "eventid")
                    .Where(id => id.Value == event1.ID)
                    .Single()
                    .Remove();
                unlinked = true;
            }
            if (unlinked)
            {
                doc.Save(file);
                mh.Clear("links_" + event1.ID);
                mh.Clear("links_" + event2.ID);
            }



            return unlinked;
        }

        public bool LinkEvents(Event event1, Event event2)
        {
            
            bool linked = false;
            if (event1.Links.Add(event2.ID))
            {
                doc.Descendants(lle + "Event")
                    .Where(id => id.Element(lle + "eventid").Value == event1.ID)
                    .Single()
                    .Element(lle + "link")
                    .Add(new XElement(lle + "eventid", event2.ID));
                linked = true;
            }
            if (event2.Links.Add(event1.ID))
            {
                doc.Descendants(lle + "Event")
                    .Where(id => id.Element(lle + "eventid").Value == event2.ID)
                    .Single()
                    .Element(lle + "link")
                    .Add(new XElement(lle + "eventid", event1.ID));
                linked = true;
            }
            if (linked)
            {
                doc.Save(file);
                mh.DrawLine("links", event1.Location, event2.Location, Color.Green);
            }
            
            
            
            return linked;
            
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
            
            foreach (XElement @event in doc.Descendants(lle + "Event"))
            {
                //TODO: Fix this
                //assumes the last element will always be the one that contains the event details, which it might not be all the time
                XElement eventDetails = @event.Elements().Last();
                
                string id = @event.Element(lle + "eventid").Value;
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
                    latitude = Double.Parse(eventDetails.Element(lle + "location").Element(lle + "lat").Value);
                    longitude = Double.Parse(eventDetails.Element(lle + "location").Element(lle + "long").Value);
                    datetime = eventDetails.Element(lle + "datetimestamp").Value;
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
                        t.CustomProperties["Filepath"] = eventDetails.Element(lle + "filepath").Value;
                        break;
                    case "tweet":
                        t = EventFactory.CreateEvent(EventFactory.EventType.Twitter);
                        t.CustomProperties["Text"] = eventDetails.Element(lle + "text").Value;
                        break;
                    case "facebook-status-update":
                        t = EventFactory.CreateEvent(EventFactory.EventType.Facebook);
                        t.CustomProperties["Text"] = eventDetails.Element(lle + "text").Value;
                        break;
                    case "video":
                        t = EventFactory.CreateEvent(EventFactory.EventType.Video);
                        t.CustomProperties["Filepath"] = eventDetails.Element(lle + "filepath").Value;
                        break;
                    
                    case "tracklog":
                        t = EventFactory.CreateEvent(EventFactory.EventType.TrackLog);
                        //t.Location = new Coordinates(latitude, longitude);
                        t.CustomProperties["Filepath"] = eventDetails.Element(lle + "filepath").Value;
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
                    foreach (XElement linkedEvent in @event.Element(lle + "link").Descendants(lle + "eventid"))
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
                    mh.DrawLine("links_" + linkID, @event.Value.Location, GetEvent(linkID).Location, Color.Green);
                }
            }
        }
    }
}
