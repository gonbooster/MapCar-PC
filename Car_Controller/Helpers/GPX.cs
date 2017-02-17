using GMap.NET;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Car_Controller.Helpers
{
    class GPX
    {
        private string dir;
        private XmlWriter w;
        private GMapOverlay overlay;

        public GPX(string dir, GMapOverlay overlay)
        {
            this.overlay = overlay;
            this.dir = dir;
            Main();
        }

        private void Main()
        {
            FileStream fs = new FileStream(dir + "map_"+DateTime.Now.ToString("HH_mm_ss")+".gpx", FileMode.Create);
            XmlWriterSettings xs = new XmlWriterSettings();
            xs.NewLineOnAttributes = true;
            xs.Indent = true;
            w = XmlWriter.Create(fs, xs);

            w.WriteStartDocument();
            w.WriteStartElement("gpx");
            writeMark();
            writeRoute();
            w.WriteEndDocument();
            w.Flush();
            fs.Close();
        }

        private void writeMark()
        {
            // Replace all occurrences of one char with another. 
            string lat = string.Empty;
            string lng = string.Empty;
            try
            {
                foreach (GMapMarker marker in overlay.Markers)
                {
                    lat = marker.Position.Lat.ToString().Replace(',', '.');
                    lng = marker.Position.Lng.ToString().Replace(',', '.');
                    w.WriteStartElement("wpt");
                    w.WriteAttributeString("lat", lat);
                    w.WriteAttributeString("lon", lng);
                    w.WriteElementString("name", marker.ToolTipText);
                    w.WriteElementString("desc", "&lt;img src=\"file:///" + (dir + marker.ToolTipText) + "\"/&gt;");
                    w.WriteElementString("sym", "Scenic Area");
                    w.WriteEndElement();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("write route: {0} ", e);
            }
        }

        private void writeRoute()
        {
            try
            {
                // Replace all occurrences of one char with another. 
                string lat;
                string lng;
                w.WriteStartElement("trk");
                w.WriteStartElement("trkseg");
                 foreach (PointLatLng point in overlay.Routes[0].Points)
                    {
                        lat = point.Lat.ToString().Replace(',', '.');
                        lng = point.Lng.ToString().Replace(',', '.');
                        w.WriteStartElement("trkpt");
                        w.WriteAttributeString("lat", lat);
                        w.WriteAttributeString("lon", lng);
                        w.WriteEndElement();
                    }

                w.WriteEndElement();
                w.WriteEndElement();
            }
            catch (Exception e)
            {
                Console.WriteLine("write route: {0} ", e);
            }
        }
    }
}
