using Car_Controller.View;
using GMap.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Car_Controller.Domain
{
    class Coords
    {
        private FormMain mainForm;
        private double wrong_lat = 1000;
        private double wrong_lng = 1000;
        private PointLatLng position;

        public Coords()
        {
            position = new PointLatLng(wrong_lat, wrong_lng);
        }

        public Coords(FormMain mainForm)
        {
            this.mainForm = mainForm;
            position = new PointLatLng(wrong_lat, wrong_lng);
        }


        public void setPosition(string msg)
        {
            try
            {
                Console.WriteLine("MSG: [" + msg + "]");

                if (String.IsNullOrEmpty(msg))
                    resetCoords();
                else
                {
                    string[] words = msg.Split(':');
                    Double lat = Double.Parse(words[1]) / 10000;
                    Double lon = Double.Parse(words[2]) / 10000;
                    position =new PointLatLng(lat, lon);
                }
                Console.WriteLine("Latitude: " + position.Lat + " Longitude: " + position.Lng);
            }
            catch (Exception e)
            {
                Console.WriteLine("setPosition: {0} ", e);
                mainForm.setError("setPosition: " + e.GetType());
                resetCoords();
            }
        }

        public PointLatLng getPosition()
        {
            return this.position;
        }

        public void resetCoords()
        {
            this.position = new PointLatLng(wrong_lat, wrong_lng);

        }
         
        public bool isWrongCoords()
        {
            bool wrong = false;
            if (position.Lat == wrong_lat || position.Lng == wrong_lng)
                wrong = true;
            return wrong;
        }

    }
}
