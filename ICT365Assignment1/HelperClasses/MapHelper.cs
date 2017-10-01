using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;
using System.Drawing;
using GMap.NET;
using System.Windows.Forms;

namespace ICT365Assignment1
{
    public class MapHelper
    {
        //store all the routes and markers ina dictionary
        private Dictionary<String, GMapOverlay> overlayDictionary = new Dictionary<String, GMapOverlay>();
        private List<GMapOverlay> routeList = new List<GMapOverlay>();
        private GMapControl mapCtrl;
        private static MapHelper aMap;
        //set up for singleton
        private MapHelper()
        {

        }
        public void AssignMapControl(GMapControl mapController)
        {
            mapCtrl = mapController;
        }
        public static MapHelper Instance()
        {
            if (aMap == null)
            {
                aMap = new MapHelper();
            }
            return aMap;
        }
        //configures the map using hardcoded data. 
        //probably allow for more customisation
        public void ConfigMap()
        {
            if (mapCtrl == null)
            {
                throw new Exception("Please assign a map controller");
            }
            //GMap.NET specific stuff
            mapCtrl.MapProvider = GMapProviders.GoogleMap;
            
            mapCtrl.MinZoom = 5;
            mapCtrl.MaxZoom = 17;
            mapCtrl.Zoom = 13;
            mapCtrl.Manager.Mode = AccessMode.ServerAndCache;
            mapCtrl.DragButton = MouseButtons.Left;
            mapCtrl.ShowCenter = false;
            
            mapCtrl.IgnoreMarkerOnMouseWheel = true;
        }
        //sets the center location
        public bool SetMapCenterLocation(string location)
        {
            if (mapCtrl.SetPositionByKeywords(location) == GeoCoderStatusCode.G_GEO_SUCCESS)
            {
                return true;
            }

            return false; ;
        }
        //adds an overlay to the dictionary, catching any errors and skipping them
        public void AddOverlay(string name)
        {
            if(mapCtrl == null)
            {
                throw new ArgumentException("Please assign a map controller");
            }
            try
            {
                overlayDictionary.Add(name, new GMapOverlay(name));
                mapCtrl.Overlays.Add(overlayDictionary[name]);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Overlay exists, not adding");
            }
        }
        //adds a marker to the map, needs a name, an image, coordinates, a tooltip and an event object reference
        public void AddMarker(string overlayName, Bitmap b, Coordinates coordinates, string toolTip, Event e)
        {
            if (mapCtrl == null)
            {
                throw new Exception("Please assign a map controller");
            }
            if (!overlayDictionary.ContainsKey(overlayName))
            {
                AddOverlay(overlayName);
            }

            GMarkerGoogle marker;
            //to push the marker down slightly, looks neater
            marker = new GMarkerGoogle(new PointLatLng(coordinates.Latitude - 0.0003, coordinates.Longitude), b)
            {
                Tag = e
            };
            //make sure to catch errors if no tool tip is specified
            if (toolTip != null && toolTip != "")
            {
                marker.ToolTipText = toolTip;
                marker.ToolTip.Fill = Brushes.Black;
                marker.ToolTip.Foreground = Brushes.White;
                marker.ToolTip.Stroke = Pens.Black;
                marker.ToolTip.TextPadding = new Size(10, 10);
                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            }
            overlayDictionary[overlayName].Markers.Add(marker);
        }
        //adds a route using a list of points 
        //maybe chnage to corrdinates instead
        public void AddRoute(string name, List<PointLatLng> points)
        {
            GMapRoute route = new GMapRoute(points, name);
            route.Stroke = new Pen(Color.Blue, 3);
            AddOverlay(name);
            overlayDictionary[name].Routes.Add(route);
        }
        //drawas acircle on the map using some good ol math found at 
        //https://stackoverflow.com/questions/9308673/how-to-draw-circle-on-the-map-using-gmap-net-in-c-sharp
        public void DrawCircle(string name, Coordinates coordinates, double radius, int segments)
        {

            List<PointLatLng> gpollist = new List<PointLatLng>();

            double seg = Math.PI * 2 / segments;
            double aspect = 0.80;
            //draw a circle on the map
            for (int i = 0; i < segments; i++)
            {
                double theta = seg * i;
                double a =  coordinates.Latitude + Math.Cos(theta) * (radius/100) * aspect;
                double b = coordinates.Longitude + Math.Sin(theta) * (radius/100);

                PointLatLng gpoi = new PointLatLng(a, b);

                gpollist.Add(gpoi);
            }
            GMapPolygon gpol = new GMapPolygon(gpollist, "pol");
            gpol.Fill = null;
            gpol.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
            gpol.Stroke = new Pen(Color.Red, 1);

            GMarkerGoogle center;
            center = new GMarkerGoogle(new PointLatLng(coordinates.Latitude, coordinates.Longitude), GMarkerGoogleType.lightblue);

            AddOverlay(name);
            overlayDictionary[name].Clear();
            overlayDictionary[name].Markers.Add(center);
            overlayDictionary[name].Polygons.Add(gpol);
        }

        //draws a line form one point to another in a specifed color
        public void DrawLine(string name, Coordinates coordinatesStart, Coordinates coordinatesEnd, Color color)
        {
            GMapOverlay line = new GMapOverlay();

            List<PointLatLng> points = new List<PointLatLng>();
            points.Add(new PointLatLng(coordinatesStart.Latitude, coordinatesStart.Longitude));
            points.Add(new PointLatLng(coordinatesEnd.Latitude, coordinatesEnd.Longitude));

            GMapRoute route = new GMapRoute(points, "Closest");
            route.Stroke = new Pen(color, 2);

            AddOverlay(name);
            overlayDictionary[name].Routes.Add(route);
            
        }
        public void Clear(string overlay)
        {
            try
            {
                overlayDictionary[overlay].Clear();
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("No overlay to clear");
            }
            
        }

        internal void ClearMap()
        {
            foreach (var overlay in overlayDictionary) {
                overlay.Value.Clear();
            }
        }
    }
}
