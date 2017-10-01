# Detailed description &amp; advanced features

The problem at hand was to create a C# GUI based application that allows a user to add and view events on a map. Basic features that needed to be implemented were, loading from an XML and querying that XML using LINQ to XML. The events needed to be displayed on a map by using appropriate markers. The application should also give the user the option to add and retrieve events from the map.

There was no restriction on the type of map used therefore the map being implemented was from an external library called GMAP.NET. ( [https://greatmaps.codeplex.com/](https://greatmaps.codeplex.com/)).

Implementation of advanced features was encouraged and as such, the advanced features implemented in this system is listed below.

## Actual map

The map module used acts as a real-world map and can be used as such. Events can be placed by using real world latitude and longitude coordinates. The user can search for a place by keywords and the map will automatically center itself to that place, alternatively, if the lace is not found, it will go to the default location specified within the code.

 

##


Toolbox View

The toolbox allows the user to interact with the program through visual controls. It gives the programmer a means to present data to the user.













## Actual GPX tracklogs

GPX tracklogs can be loaded in the application, it loads in using real coordinates and displays the elevation as well as any waypoints alongside the name of the tracklog.

The application can link events through right clicking and clicking on two events consecutively which then internally links then and draws a line indicating the events are linked. The user can remove the links as well by enabling the remove link feature through the context menu and selecting two events consecutively.
Before and after linking events notice the green line contacting the two events

Error checking is used to make sure events that do not have links are ignored and handled appropriately.

When trying to link events that already exist, or trying to remove links that do not exist

## Dynamic image and video thumbnail generation

For each video and photo event, a thumbnail of the event is placed on the map itself. This differentiates each photo and video events at a glance. The one issue here is that the images are created as a square box that does not maintain aspect ratio. Clicking on the event shows the image better.

##

## Hovering over events

GMap.NET allows the use of tool tips on event markers. This allows the user to view details even without clicking on the event item. The tooltips offer a simple overview of the event. There are issues with displaying the tooltip near other events. This is discussed later on

## Searching for a location on the map

The idea behind this feature was to allow the user to jump to a location based on a keyword. If the user wanted to add an event to a specific location they would be able to by searching for that location then adding it through the context menu.

## User specified search radius

A customizable search radius allows the user to input a numerical value to search for events within a certain radius
# Self-diagnosis and evaluation

## Working features

All basic features are working from the specification sheet. All above mentioned advanced features are working. These advanced features will not be discussed in depth as they have been mentioned above. There are a few areas which I would have liked to make more robust and improve the code quality such as displaying the events, there was a lot of repeated code for creating information panels.

The basic features will be discussed in the following brief description section

## Non-working features

All features that have been implemented are working to a standard that is considered functional. I have not come across any crashes in the normal running of the program.

A feature that I implanted was the hovering over icons to view details, this feature works partially well because if other elements can sometimes block out that hovered text.

One issue that does occur is if the user pastes any text into the search fields, especially the numerical radius field, the program will allow it. I have implanted checks to fallback to a default value if any erroneous values get parsed.

If the xml file gets altered manually by an external entity, perhaps it gets removed, this can cause issues with the running of the program, especially when saving events.

If the files aren&#39;t found, the program does crash on the user with no indication of what went wrong. A simple try catch block could suffice.

If any files are moved from their location, in certain situations, the program will crash. For video and photo events, an error image is displayed, for tracklogs, the program crashes.

## Non-implemented features

All the core features are implemented. Features that I would have liked to implement are editing and removing events from the dictionary and XML file.

Another feature that would be beneficial would be to create GPX tracklogs within the application itself.

# Brief description of solution

My solution to the program was to try and create a very versatile and almost real-world version of the application. I decided to think about how things fitted together and tried to apply as many design patterns and principles where suited. The entire program is based on the GMap.NET library as it provides a solid base from which to use. Functions were created as needed and I tried to hit evry aspect of the specification.

I tried to give the user an experience that they would be familiar with i.e having the toolbox on the side, right clicking to add events.

##


Task 1

This task was simply adding in extra events. I used this task to change the xml file slightly to allow for a more fluid entry of the events. A notable change is that each event has a coordinate and date attached to it even on the tracklog and video events. I removed the start and end times from the video event as it seemed unnecessary as the video file itself will contain its duration.

I had no need to keep the data section in the tracklog events as I could not find any use for it. Perhaps adding in a description segment would have been useful.

Task 2

The windows form I ended up with was simply a map with a toolbox on the one side. The map control object is an external map control downloaded from [https://greatmaps.codeplex.com/](https://greatmaps.codeplex.com/). GMap.NET allows for easy customization and visualization of a 2d map. The control is works with real world latitude and longitude coordinates that way all the events being put into the program can be mapped to a real location.

GMap.NET gives the opportunity to draw routes, polygons and markers on the map which worked well with this assignment

 
## Task 3

Using LINQ to XML, the files were simply read into the program and store in a dictionary as specified. The dictionary contained a string as the key and an Event object as the value. The key was simply the ID of the event to make it easy to cross reference events.

One issue I had was maintaining both the XML file and the dictionary. When I added an event to the dictionary, I had to make sure the details were also being added to the XML file at the same time.

Event objects were represented to the UML below

The following algorithm will show the basic structure of reading in an XML document and using it within the events helper

//try loading in a xdocument from the specified file

            XDocument document = null;

            FILE = file;

            try

            {

                document = XDocument.Load(FILE);

            }

            catch (FileNotFoundException)

            {

                thrownewFileNotFoundException(&quot;File not found&quot;);

            }

//populate the events using linq

foreach (XElement @event in ROOT\_DOCUMENT.Descendants(LLE + &quot;Event&quot;))

            {

                //TODO: Fix this

                //assumes the last element will always be the one that contains the event details,

                //which it might not be all the time

                XElement eventDetails = @event.Elements().Last();

                string id = @event.Element(LLE + &quot;eventid&quot;).Value;



                Event tempEvent;



                //create a temp event

                 //omitted



                EventDictionary.Add(id, tempEvent);

            }

//save the document

ROOT\_DOCUMENT.Save(FILE);

## Task 4

Icons were used as markers on the map. Freely available icons were used especially for Facebook and Twitter, the actual image was used for photo and video events, tracklogs used flags as images.

##



Task 5

Adding an event was done through right clicking on the map and providing the user with a context menu which allows the user to either add an event, view events or link and unlink events. Unfortunately, due to time constraints, removing an event or editing an event is not functional. With more time, these functions could definably be implemented.

When adding a new event, the user is presented with a separate form which acts differently based on the event selection. Basic error handling checks whether the event is valid before inserting into the program.





# Refactoring&#39;s

This section will describe refactoring&#39;s to the code that I deemed to be essential in the overall quality of the program.

The simplest form of refactoring was through renaming variables and functions. Certain variables had vague names such as X and Y, within the context of the function it made sense, but renaming them to latitude and longitude made it more apparent as to what variables the functions were manipulated.

While loading the XML file, I used a few concatenated variable names such as eh, ev, xe, but later renamed them to be eventHelper, @event and XElement, this is more readable and less ambiguous when looking at it from a third person perspective

When creating the functions, many variables were used that served a purpose in the beginning but was replaced by other variables and functions which did the task better. This resulted in a few unused variables and functions that were removed as a part of the refactoring process.

A refactoring that was done was implementing a coordinates class (originally named location). The coordinates class simply contains a latitude and longitude as a double. This made it simple to select a latitude and longitude from any function without having to pass through raw latitude and longitude numbers. This made it easier to read and faster to develop as a coordinate simply defines itself by its name too. The coordinate class provided a layer of extensibility in the sense that if I were to format the values to be a string containing the degrees, minutes etc. It could be done through one function call.

Another important refactoring was moving a lot of the functionality from main into separate helper classes. I noticed I kept using the same functions over and over in different places outside main and decided it would be better to extract those classes and implement then elsewhere. I ended up using a couple of helper classed that did the same thing as before but being more focused. The eventsHelper class deals specifically with details and operations that need to be done on event objects. These operations include saving events, adding events, linking events etc. Similarly, the mapsHelper dealt with drawing directly to a map, displaying routes on the map etc. By doing this, it allowed over functions outside of main to access those functions if needed.

Changing functions from public to private was also a common thing that was done. Every time I created a function I immediately named it private. After reading a bit of my code, I noticed a lot of the functions were just internally used and had no reason to be public. Such functions were  in the mapHelper, populateEvents in the eventsHelper and so on. They do not need to be accessed outside their calling functions therefore it made sense for them to be private.

I thought it would be best to move each of those core functions to the specified event object through interface implementations. An example would be conditionally rendering an event. This requires a set of images, descriptions, text or file paths which an event might have zero, one or many of these attributes. An interface which forced the functions to essentially render itself was more maintainable and could easily be identified within the specific events. This created a sense of abstraction by allowing a more customized feel to each event.

For any global variables, I renamed them to be uppercase, this differentiated between local and global variables

# Design patterns and principles

A few design patterns and principles were implemented in the program. These were string builder, factory patter, singleton pattern and with some refactoring, although these changes don&#39;t affect the functionality, it allows for better development and in some cases more efficiency.

## Bad Smells

I will start off by pointing out some bad smells in the program that could not be sorted out in time. One major one is still using switch cases where there ideally shouldn&#39;t be used. I tried to eradicate this issue as much as possible by using interfaces and design patterns but unfortunately some areas were unable to be refactored.

In the GUI forms where the user can select the event type, a switch statement is used to determine which type of event they had selected which then creates an event of the specified type with the specific details. This is not ideal but perhaps a solution would have been to implement a builder pattern that dynamically adds event attributes at run time

switch (selectedText)

                {

                    caseEventFactory.EventType.Twitter:

                        tenpEvent.CustomProperties[&quot;Text&quot;] = mainGroupBox.Controls.Find(&quot;text&quot;, true).Single().Text;

                        break;

                    caseEventFactory.EventType.Facebook:

                        tenpEvent.CustomProperties[&quot;Text&quot;] = mainGroupBox.Controls.Find(&quot;text&quot;, true).Single().Text;

                        break;

                    caseEventFactory.EventType.Photo:

                        tenpEvent.CustomProperties[&quot;Filepath&quot;] = mainGroupBox.Controls.Find(&quot;imageLabel&quot;, true).Single().Text;

                        break;

                    caseEventFactory.EventType.Video:

                        tenpEvent.CustomProperties[&quot;Filepath&quot;] = mainGroupBox.Controls.Find(&quot;videoLabel&quot;, true).Single().Text;

                        break;

                    caseEventFactory.EventType.TrackLog:

                        tenpEvent.CustomProperties[&quot;Filepath&quot;] = mainGroupBox.Controls.Find(&quot;tracklogLabel&quot;, true).Single().Text;

                        break;

                    default:

                        return;

As mentioned earlier, before, I had large switch statements that spanned upwards of 100 lines of code, these switch statements were conditional to each event type so a chunk of code will be skipped depending on the type of event. Although this worked, it made it difficult to make slight changes and having to sift through all those cases was barely appropriate.

There are a few areas where code is being duplicated across different events. Mainly around displaying data on the form, headings and link to event labels. Perhaps implementing a class that does event links would solve that issue.

## Factory pattern

The factory pattern allows dynamic creation of objects at run time. This pattern is very versatile and fitted the best within the context of this assignment. An event factory allowed the creation of the different types of events. This allowed me to easily use the events without casting and helped create algorithms that worked on all the events.

publicstaticEvent CreateEvent (EventType e)

        {

            switch (e)

            {

                caseEventType.Facebook:

                    returnnewFacebookEvent();

                caseEventType.Twitter:

                    returnnewTwitterEvent();

                caseEventType.Photo:

                    returnnewPhotoEvent();

                caseEventType.Video:

                    returnnewVideoEvent();

                caseEventType.TrackLog:

                    returnnewTrackLogEvent();

                default:

                    returnnewNullEvent();

            }

        }

## String Builder

The string builder is a derived from the builder as its core functionality is the same. String builders are useful when a string needs to be created that requires a lot of complexity. Creating long strings using string addition causes the string to be created multiple times however string builders eradicate that issue.

In this application, string builder is used when creating string representations of objects. Especially in the coordinate class which outputs the latitude and longitude of the object as a string and is used throughout the program.

StringBuilder location = newStringBuilder();

            location.Append(this.Latitude);

            location.Append(&quot;, &quot;);

            location.Append(this.Longitude);

            return location.ToString();

## Singleton

The singleton pattern is useful when a single instance of an object was required. For the assignment, a singleton pattern was used in four separate areas. This was for the two helper classes (MapHelper and EventHelper) and two form windows (AddeventForm and EventdetailsForm).

Singletons were particularly helpful when the same method had to be called from multiple different different classes. An example is when each event calls the mapHelper class to render itself to the map, it would have been inefficient to allow multiple copies of the mapHelper class to be instantiated as it contained lists of each marker, creating new mapHelper objects would mean all those previously drawn markers would have been lost. A similar concept applies for the eventHelper.

The forms were created as a singleton to allow for one form to be created which the data inside just gets rewritten, this becomes more efficient than recreating the form each time.

Each employed a simple private constructor that and could only be instantiated once through its Instance() method. The main implementation for each of the singletons was as follows.

Source: [https://www.codeproject.com/Articles/7505/Singleton-pattern-for-MDI-child-forms](https://www.codeproject.com/Articles/7505/Singleton-pattern-for-MDI-child-forms)

private MapHelper(){}

publicstaticMapHelper Instance()

{

    if (aMap == null)

    {

         aMap = newMapHelper();

    }

         return aMap;

}

## Null Object

A null object is used to create a event object that has all the required functionality but does not have any method bodies and returns nothing. This is not used within the program but is implemented to safeguard from any potential errors that may occur when creating an object that is not specified the null object class looks like this

classNullEvent : Event

    {

        publicoverridePanel CreatePanel()

        {

            returnnewPanel();

        }

        publicoverridebool isValid()

        {

            returnfalse;

        }

        publicoverridevoid Render()

        {

            Console.WriteLine(&quot;Null event cant render&quot;);

        }

        publicoverrideXElement ToXElement(XNamespace ns)

        {

            returnnewXElement(null, null);

        }

    }

As the code displays, the object simply returns nothing for each of the abstract methods.
