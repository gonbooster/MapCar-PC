using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using XInputDotNetPure;
using System.IO.Ports;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Net.Sockets;

using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using Car_Controller;
using Car_Controller.Properties;
using System.Resources;
using Car_Controller.View;
using Car_Controller.Helpers;
using Car_Controller.Domain;
using System.Drawing.Imaging;
using System.Security.Principal;
using System.Security.AccessControl;
using System.Windows.Threading;

namespace Car_Controller.View
{
    public partial class FormMain : Form
    {
        public Dispatcher dispacher = Dispatcher.CurrentDispatcher;

        //Coords
        private Coords coords;

        //TCP
        private TCP tcp;

        //Joystick
        Joystick_Custom joystick;

        //CAM
        private Camera camera;
        private string dir = "C:\\Car_controller\\Generate\\" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + "\\";

        //MAP     
        private Map_Custom map;
        private int gmap_MinZoom = 1;
        private int gmap_MaxZoom = 20;
        private int gmap_Zoom = 18;
        private bool gmap_ShowTileGridLines = false;

        public FormMain()
        {
            InitializeComponent();
        }
        //This event is triggered when the GUI loads
        //Multiple threads are started with this event, and are configured to run in the background
        private void Form_Load(object sender, EventArgs e)
        {

            //map initialization
            map_Box.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;

            //initialization
            joystick = new Joystick_Custom(this);
            coords = new Coords(this);
            tcp = new TCP(this);
            map = new Map_Custom(this);
            camera = new Camera(this);

            //Thread for handling Xbox 360 controller
            Thread updatecontroller = new Thread(new ThreadStart(joystick.UpdateState));
            updatecontroller.IsBackground = true;
            updatecontroller.Start();

        }


        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (tcp.isConnected())
                disconnectCar();
            if (camera.isConnected())
                disconnectCam();
            Console.WriteLine("Main Form Closed");
        }


        //---------------------------------------------------------------------------------------------------------
        //The following section contains code for TCP functions
        //---------------------------------------------------------------------------------------------------------

        private void connectCar()
        {
            Thread t_carConnect = new Thread(() => tcp.connect(tcp_ip.Text, int.Parse(tcp_port.Text)));
            t_carConnect.IsBackground = true;
            t_carConnect.Start();
            car_btn_text("Disconnect");
            coords.resetCoords();

        }
        private void disconnectCar()
        {
            Thread t_carDisconnect = new Thread(() => tcp.close());
            t_carDisconnect.IsBackground = true;
            t_carDisconnect.Start();
            car_btn_text("Connect");
            coords.resetCoords();

        }

        public void car_on_of()
        {
            if (tcp.isConnected())
                disconnectCar();
            else
                connectCar();
        }

        private void tcp_connect_Click(object sender, EventArgs e)
        {
            car_on_of();
        }

        //Send move command and recive GPS coords
        public void moveCar(string gear, int thottle, int steering)
        {

            if (tcp.isConnected())
            {
                tcp.send(":" + gear + ":" + thottle + ":" + steering + ";");
                Console.WriteLine("[:" + gear + ":" + thottle + ":" + steering + ";]");
                Thread.Sleep(50);
                coords.setPosition(tcp.recive());
            }
        }

        //---------------------------------------------------------------------------------------------------------
        //The following section contains code for the IP camera
        //---------------------------------------------------------------------------------------------------------

        public void cam_on_of()
        {

            if (camera.isConnected())
                disconnectCam();
            else
                connectCam();
        }

        private void camera_video_button_Click(object sender, EventArgs e)
        {
            cam_on_of();
        }

        private void disconnectCam()
        {
            camera.disconnect();
            camera_btn_text("Connect");
        }

        private void connectCam()
        {
            camera.setIP(camera_ip.Text, camera_port.Text);
            Thread get_video_stream = new Thread(new ThreadStart(camera.video_stream));
            get_video_stream.IsBackground = true;
            get_video_stream.Start();
            camera_btn_text("Disconnect");
        }

        //---------------------------------------------------------------------------------------------------------
        //The following section contains code for the MAP
        //---------------------------------------------------------------------------------------------------------


        private void gMapControl_Load(object sender, EventArgs e)
        {
            // Initialize map:
            map_Box.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;


            map_Box.MinZoom = gmap_MinZoom;
            map_Box.MaxZoom = gmap_MaxZoom;
            //set zoom
            map_Box.Zoom = gmap_Zoom;
            map_Box.ShowTileGridLines = gmap_ShowTileGridLines;
        }


        // OnMarkerClick, the image connected with that marker will opened
        private void gmap_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {

            Bitmap image = (Bitmap)Image.FromFile(dir + item.ToolTipText, true);
            image_Box.Image = image;
            image_Box.Visible = true;
        }

        // On click in oppened image, it will closed
        private void pictureBox_Click(object sender, EventArgs e)
        {
            image_Box.Visible = false;
        }

        //---------------------------------------------------------------------------------------------------------
        //The following section contains code for the Menu
        //---------------------------------------------------------------------------------------------------------

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormHelp help = new FormHelp(this);
            help.Show();
            this.Enabled = false;
        }

        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormConfig conf = new FormConfig(this);
            conf.Show();
            this.Enabled = false;
        }

        //---------------------------------------------------------------------------------------------------------
        //The following section contains code for Option buttons
        //---------------------------------------------------------------------------------------------------------

        private void camera_photo_button_Click(object sender, EventArgs e)
        {
            take_photo();
        }

        public void take_photo()
        {
            Thread photo = new Thread(new ThreadStart(process_photo));
            photo.IsBackground = true;
            photo.Start();
        }

        //Take photo, save it and update marker in the map
        private void process_photo()
        {
            if (camera.isConnected())
            {
                generateDirectory();
                Bitmap image = camera.get_image();
                if (image == null)
                    setError("null photo");
                string filename = DateTime.Now.ToString("HH_mm_ss") + ".jpeg";
                saveBMP(dir + filename, image);
                map.addMarker(filename, coords);
            }
        }

        private void saveBMP(string patch, Bitmap bmp) // now 'ref' parameter
        {
            try
            {
                bmp.Save(patch, ImageFormat.Jpeg);
                Console.WriteLine("photo saved");
            }
            catch (Exception e)
            {
                Console.WriteLine("save photo: {0}", e);
                setError("save photo: " + e.GetType());
            }
        }

        private void zoomBar_ValueChanged(object sender, EventArgs e)
        {
            cameraZoom(zoomBar.Value);
        }

        private void flashlight_btn_Click(object sender, EventArgs e)
        {
            flashlight();
        }

        private void f_b_camera_btn_Click(object sender, EventArgs e)
        {
            cameraMode();
        }

        private void overlay_btn_Click(object sender, EventArgs e)
        {
            overlay();
        }

        private void export_btn_Click(object sender, EventArgs e)
        {
            exportMap();
        }

        private void explore_btn_Click(object sender, EventArgs e)
        {
            openExplorer();
        }

        public void cameraZoom(int v)
        {
            camera.zoom(v);
        }

        public void flashlight()
        {
            camera.flashlight();
        }

        public void cameraMode()
        {
            camera.cameraMode();
        }

        public void overlay()
        {
            camera.overlay();
        }

        public void exportMap()
        {
            map.exporMap();
        }

        public void openExplorer()
        {
             try
            {
                if (!System.IO.Directory.Exists(dir))
                    setError("First you need take photo or export map!");

                else
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = dir,
                        UseShellExecute = true,
                        Verb = "open"
                    });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Explore btn: {0}", e);
                setError("Explore btn: " + e.GetType());
            }
        }

        //---------------------------------------------------------------------------------------------------------
        //The following section contains code for miscelanius functions
        //---------------------------------------------------------------------------------------------------------

        public void generateDirectory()
        {
            if (!System.IO.Directory.Exists(dir))
            { // generate dir if not exist
                System.IO.Directory.CreateDirectory(dir);
                SetPermissions(dir);
            }
        }

        //Full access control to folder or directory
        private static void SetPermissions(string dirPath)
        {
            DirectoryInfo info = new DirectoryInfo(dirPath);
            WindowsIdentity self = System.Security.Principal.WindowsIdentity.GetCurrent();
            DirectorySecurity ds = info.GetAccessControl();
            ds.AddAccessRule(new FileSystemAccessRule(self.Name,
            FileSystemRights.FullControl,
            InheritanceFlags.ObjectInherit |
            InheritanceFlags.ContainerInherit,
            PropagationFlags.None,
            AccessControlType.Allow));
            info.SetAccessControl(ds);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (!coords.isWrongCoords())
            {
                Thread t_addRoute = new Thread(() =>map.addRoute(coords));
                t_addRoute.IsBackground = true;
                t_addRoute.Start();

                if (!map.isRepeatLastCoord(coords.getPosition()))
                {
                    Thread t_MapOverlay = new Thread(()=> reloadMapOverlay(map.getOverlay()));
                    t_MapOverlay.IsBackground = true;
                    t_MapOverlay.Start();
                
                    Thread t_MapPosition = new Thread(() => reloadMapPosition(coords.getPosition()));
                    t_MapPosition.IsBackground = true;
                    t_MapPosition.Start();

                    Thread t_CoordText = new Thread(new ThreadStart(reloadCoordsText));
                    t_CoordText.IsBackground = true;
                    t_CoordText.Start();
                    }
            }
        }


        //---------------------------------------------------------------------------------------------------------
        //The following section contains code for public controller
        //---------------------------------------------------------------------------------------------------------
        public void setError(String text)
        {
            try
            {
                if (errorBox.InvokeRequired)
                    Invoke(new Action(() => errorBox.Text = text));
                else
                    errorBox.Text = text;
            }
            catch (Exception e)
            {
                Console.WriteLine("setError: {0}", e);
            }
        }


        public void reloadCoordsText()
        {
            try
            {
                PointLatLng pos = coords.getPosition();
                if (labelGPS.InvokeRequired)
                    Invoke(new Action(() => labelGPS.Text = "Latitude: " + pos.Lat + " Longitude: " + pos.Lng));
                else
                    labelGPS.Text = "Latitude: " + pos.Lat + " Longitude: " + pos.Lng;
            }
            catch (Exception e)
            {
                Console.WriteLine("reloadCoordsText: {0}", e);
                this.setError("reloadCoordsText: " + e.GetType());
            }
        }

        public void reloadMapPosition(PointLatLng position)
        {
            try
            {
                if (map_Box.InvokeRequired)
                    Invoke(new Action(() => this.map_Box.Position = position));
                else
                    this.map_Box.Position = position;
                
            }
            catch (Exception e)
            {
                Console.WriteLine("reloadMapPosition: {0}", e);
                this.setError("reloadMapPosition: " + e.GetType());
            }
        }

        public void reloadMapOverlay(GMapOverlay overlay)
        {
            try
            {
                if (map_Box.InvokeRequired)
                    Invoke(new Action(() => this.map_Box.Overlays.Add(overlay)));
                else
                    this.map_Box.Overlays.Add(overlay);
            }
            catch (Exception e)
            {
                Console.WriteLine("reloadMapOverlay: {0}", e.GetType());
                this.setError("reloadMapOverlay: " + e);
            }
        }

        public void reloadCam(Bitmap image)
        {
            Invoke(new Action(() => this.camera_Box.Image = image));
        }

        public void reloadCameraMode_btn(string text)
        {
            if (InvokeRequired)
                Invoke(new Action(() => this.f_b_camera_btn.Text = text));
            else
                this.f_b_camera_btn.Text = text;
        }

        public void reloadFlashlight_btn(string text)
        {
            if (InvokeRequired)
                Invoke(new Action(() => this.flashlight_btn.Text = text));
            else
                this.flashlight_btn.Text = text;
        }

        public void reloadOverlay_btn(string text)
        {
            if (InvokeRequired)
                Invoke(new Action(() => this.overlay_btn.Text = text));
            else
                this.overlay_btn.Text = text;
        }

        public void reloadCameraZoom(int i)
        {
            if (InvokeRequired)
                Invoke(new Action(() => this.zoomBar.Value = i));
            else
                this.zoomBar.Value = i;
        }

        public void camera_btn_text(string text)
        {
            if (InvokeRequired)
                Invoke(new Action(() => this.camera_connect_btn.Text = text));
            else
                this.camera_connect_btn.Text = text;
        }

        public void car_btn_text(string text)
        {
            if (InvokeRequired)
                Invoke(new Action(() => this.tcp_connect_btn.Text = text));
            else
                this.tcp_connect_btn.Text = text;
        }

        public void joystick_Text(string text)
        {
            if (InvokeRequired)
                Invoke(new Action(() => this.joystick_lbl.Text = text));
            else
                this.joystick_lbl.Text = text;
        }

        public string getDir()
        {
            return this.dir;
        }

    }
}
