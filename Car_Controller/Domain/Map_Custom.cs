using Car_Controller.Helpers;
using Car_Controller.Properties;
using Car_Controller.View;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace Car_Controller.Domain
{
    class Map_Custom
    {
        public Dispatcher dispacher = Dispatcher.CurrentDispatcher;
        private GMapOverlay overlay;
        private GMapRoute route;
        GMarkerGoogle marker;
        private string dir= string.Empty;
        private FormMain mainForm;
        public Map_Custom(FormMain mainForm)
        {
            this.mainForm = mainForm;
            this.dir = mainForm.getDir();
            overlay = new GMapOverlay("markers");
            route = new GMapRoute("Route");
        }

        public GMapOverlay getOverlay()
        {
            return this.overlay;
        }

        //Add marker to the map
        public void addMarker(String text, Coords coords)
        {
            if (!coords.isWrongCoords())
            {

                Console.WriteLine("Marker");

                    this.dispacher.Invoke(DispatcherPriority.Normal, (Action)(() =>
                    {
                        marker = new GMarkerGoogle(coords.getPosition(), GMarkerGoogleType.green);
                        marker.ToolTipText = text;
                        overlay.Markers.Add(marker);
                        addRoute(coords);
                    }));
            }
        }

        //Add new position to the map, and connect existing points  
        public void addRoute(Coords coords)
        {
            if (!coords.isWrongCoords())
            {
                Console.WriteLine("Route");
                this.dispacher.Invoke(DispatcherPriority.Normal, (Action)(() =>
                {
                    if (!isRepeatLastCoord(coords.getPosition())) // dont save last same coords
                {
                    route.Points.Add(coords.getPosition());
                    overlay.Routes.Add(route);
                }
                }));
            }
        }

        public Boolean isRepeatLastCoord(PointLatLng coord)
        {
            if (route.Points.Count() == 0 || route.Points.Last() != coord) // dont save last same coords
                return false;
            else
                return true;
        }
        public void exporMap()
        {
            if (route.Points.Count > 0)
            {
                mainForm.generateDirectory();
                new GPX(dir, overlay);
            }
        }
    }
}
