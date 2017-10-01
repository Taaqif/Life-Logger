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
        MapHelper mapHelper = MapHelper.Instance();

        Dictionary<String, Event> EventDictionary = new Dictionary<string, Event>();

        XNamespace LLE = XNamespace.Get("http://www.xyz.org/lifelogevents");
        XNamespace SOAP_ENV = XNamespace.Get("http://www.w3.org/2001/12/soap-envelope");

        String FILE;

        //set up for singleton
        private static EventsHelper aEvent;

        private string HIGHEST_ID = null;

        
        private XDocument ROOT_DOCUMENT;

        public static EventsHelper Instance()
        {
            if (aEvent == null)
            {
                aEvent = new EventsHelper();
            }
            return aEvent;
        }
        public void loadFromXML(String file)
        {
            //try loading in a xdocument from the specified file
            XDocument document = null;
            FILE = file;
            try
            {
                document = XDocument.Load(FILE);
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("File not found");
            }
            ROOT_DOCUMENT = document;
            PopulateEvents();
           
        }
         //increments a string with the format IDXX where XX is a number
         //probably need to clarify this function, add a format specifier 
         //public to be able to unit test
        public string IncrementStringID(string oldID)
        {
            return Regex.Replace(oldID, @"(\d+)",
                m => (Convert.ToInt32(m.Groups[1].Value) + 1).ToString());
        }
        //adds an event to the dictionary and xml file
        public void AddEvent(Event @event)
        {
            //make sure its valid
            if (!@event.IsValid())
            {
                throw new ArgumentException("Event is not valid");
            }
            else
            {
                HIGHEST_ID = IncrementStringID(HIGHEST_ID);

                //create a new event xelement
                XElement newEvent = new XElement(LLE + "Event",
                                new XElement(LLE + "eventid", HIGHEST_ID),
                                new XElement(LLE + "link"));
                //append the events xelement to this one
                newEvent.Add(@event.ToXElement(LLE));
                
                //assign the id
                @event.ID = HIGHEST_ID;
                
                //add it
                EventDictionary.Add(HIGHEST_ID, @event);
                ROOT_DOCUMENT.Descendants(SOAP_ENV + "Body").Single().Add(newEvent);
                //save and render it
                ROOT_DOCUMENT.Save(FILE);
                @event.Render();
            }
            
            
        }
        //unlinks two events
        public bool UnLinkEvents(Event event1, Event event2)
        {
            bool unlinked = false;
            //remove the element from the xeelent entry using linq for both events
            if (event1.Links.Remove(event2.ID))
            {
                ROOT_DOCUMENT.Descendants(LLE + "Event")
                    .Where(id => id.Element(LLE + "eventid").Value == event1.ID)
                    .Single()
                    .Element(LLE + "link")
                    .Descendants(LLE + "eventid")
                    .Where(id => id.Value == event2.ID)
                    .Single()
                    .Remove();
                unlinked = true;
            }
            if (event2.Links.Remove(event1.ID))
            {
                ROOT_DOCUMENT.Descendants(LLE + "Event")
                    .Where(id => id.Element(LLE + "eventid").Value == event2.ID)
                    .Single()
                    .Element(LLE + "link")
                    .Descendants(LLE + "eventid")
                    .Where(id => id.Value == event1.ID)
                    .Single()
                    .Remove();
                unlinked = true;
            }

            //save the file if successful
            if (unlinked)
            {
                ROOT_DOCUMENT.Save(FILE);
                //remove the lines from the map
                mapHelper.Clear("links_" + event1.ID);
                mapHelper.Clear("links_" + event2.ID);
            }
            return unlinked;
        }

        //link two events
        public bool LinkEvents(Event event1, Event event2)
        {
            
            bool linked = false;
            if (event1.Links.Add(event2.ID))
            {
                ROOT_DOCUMENT.Descendants(LLE + "Event")
                    .Where(id => id.Element(LLE + "eventid").Value == event1.ID)
                    .Single()
                    .Element(LLE + "link")
                    .Add(new XElement(LLE + "eventid", event2.ID));
                linked = true;
            }
            if (event2.Links.Add(event1.ID))
            {
                ROOT_DOCUMENT.Descendants(LLE + "Event")
                    .Where(id => id.Element(LLE + "eventid").Value == event2.ID)
                    .Single()
                    .Element(LLE + "link")
                    .Add(new XElement(LLE + "eventid", event1.ID));
                linked = true;
            }
            if (linked)
            {
                ROOT_DOCUMENT.Save(FILE);
                mapHelper.DrawLine("links", event1.Location, event2.Location, Color.Green);
            }
            
            
            
            return linked;
            
        }
        //gets the event by id
        public Event GetEvent(string ID)
        {
            return EventDictionary[ID];
        }
        //returns a list of the surrounding events
        public List<Event> GetSurroundingEvents(Coordinates coordinates, double radius)
        {
           
            List<Event> eventList = new List<Event>();
            


            //https://stackoverflow.com/questions/7783684/select-coordinates-which-fall-within-a-radius-of-a-central-point

            //find points within a radius using harvoursine formula
            double havoursineConst = 0.0175;
            double KMSconst = 6371;
            var e = from ev in EventDictionary
                        let distance = Math.Acos(Math.Sin(ev.Value.Location.Latitude * havoursineConst) *
                            Math.Sin(coordinates.Latitude * havoursineConst) +
                            Math.Cos(ev.Value.Location.Latitude * havoursineConst) *
                            Math.Cos(coordinates.Latitude * havoursineConst) *
                            Math.Cos((coordinates.Longitude * havoursineConst) - (ev.Value.Location.Longitude * havoursineConst))
                        ) * KMSconst
                        where distance <= radius
                        //sort by distance
                        orderby distance
                        select ev.Value;
            return e.ToList<Event>();
        }
        //populates the event dictionary
        private void PopulateEvents()
        {
            //reset the dictionary
            EventDictionary = new Dictionary<string, Event>();
            
            foreach (XElement @event in ROOT_DOCUMENT.Descendants(LLE + "Event"))
            {
                //TODO: Fix this
                //assumes the last element will always be the one that contains the event details, 
                //which it might not be all the time
                XElement eventDetails = @event.Elements().Last();
                
                string id = @event.Element(LLE + "eventid").Value;
                //set the highest ID
                if (id.CompareTo(HIGHEST_ID) != 0)
                {
                    HIGHEST_ID = id;
                    Console.WriteLine(HIGHEST_ID);
                }
                double latitude = 0;
                double longitude = 0;
                string datetime = "";
                //try parsing the location and date form the xml
                try
                {
                    latitude = Double.Parse(eventDetails.Element(LLE + "location").Element(LLE + "lat").Value);
                    longitude = Double.Parse(eventDetails.Element(LLE + "location").Element(LLE + "long").Value);
                    datetime = eventDetails.Element(LLE + "datetimestamp").Value;
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("No location or date data for this event found. Skipping");
                }

                Event tempEvent;

                //not ideal, fix this
                switch (eventDetails.Name.LocalName)
                {
                    case "photo":
                        tempEvent = EventFactory.CreateEvent(EventFactory.EventType.Photo);
                        tempEvent.CustomProperties["Filepath"] = eventDetails.Element(LLE + "filepath").Value;
                        break;
                    case "tweet":
                        tempEvent = EventFactory.CreateEvent(EventFactory.EventType.Twitter);
                        tempEvent.CustomProperties["Text"] = eventDetails.Element(LLE + "text").Value;
                        break;
                    case "facebook-status-update":
                        tempEvent = EventFactory.CreateEvent(EventFactory.EventType.Facebook);
                        tempEvent.CustomProperties["Text"] = eventDetails.Element(LLE + "text").Value;
                        break;
                    case "video":
                        tempEvent = EventFactory.CreateEvent(EventFactory.EventType.Video);
                        tempEvent.CustomProperties["Filepath"] = eventDetails.Element(LLE + "filepath").Value;
                        break;
                    
                    case "tracklog":
                        tempEvent = EventFactory.CreateEvent(EventFactory.EventType.TrackLog);
                        //t.Location = new Coordinates(latitude, longitude);
                        tempEvent.CustomProperties["Filepath"] = eventDetails.Element(LLE + "filepath").Value;
                        break;
                    default:
                        return;
                }
                //set the location
                tempEvent.Location = new Coordinates(latitude, longitude);
                //set the datetimestamp for the event object
                if (datetime.Length > 0)
                {
                    try
                    {
                        tempEvent.Datetimestamp = DateTime.Parse(datetime);

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

                //set the id
                tempEvent.ID = id;

                try
                {
                    foreach (XElement linkedEvent in @event.Element(LLE + "link").Descendants(LLE + "eventid"))
                    {
                        tempEvent.Links.Add(linkedEvent.Value);
                        
                    }
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("No links found");
                }
                
                EventDictionary.Add(id, tempEvent);

            }

        }
        //render all the evemts to the map
        public void renderEvents()
        {
            mapHelper.ClearMap();
            //draw any links that exist between the events
            foreach (var @event in EventDictionary)
            {
                @event.Value.Render();
                foreach(string linkID in @event.Value.Links)
                {
                    mapHelper.DrawLine("links_" + linkID, @event.Value.Location, GetEvent(linkID).Location, Color.Green);
                }
            }
        }
    }
}
