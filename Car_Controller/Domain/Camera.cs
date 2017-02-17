using System;
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
using System.Drawing;
using System.Text;

namespace Car_Controller.Domain
{
    class Camera
    {
        private bool connected;
        private string ip= string.Empty;
        private string port= string.Empty;
        private bool fromMode = false;
        private bool enableTorch = false;
        private bool enableOverlay = false;
        private string dir= string.Empty;
        private FormMain mainForm;

        public Camera()
        {
        }

        public Camera(FormMain mainForm)
        {

            this.mainForm = mainForm;
            this.dir = mainForm.getDir();
            connected = false;
        }

        public void setIP(string ip, string port)
        {
            this.ip = ip;
            this.port = port;
        }


        public void connect()
        {
            connected = true;
        }

        public void disconnect()
        {
            connected = false;
        }

        public bool isConnected()
        {
            if (connected == true)
                return true;
            else
                return false;
        }

        public WebResponse webResponse(String command)
        {
            WebResponse resp = null;
            try
            {
                string video_URL = "http://" + ip + ":" + port + "/" + command;
                // create HTTP request
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(video_URL);
                // get response
                resp = req.GetResponse();
                return resp;
            }
            catch (Exception e)
            {
                Console.WriteLine("Camera webresponse: {0}", e);
                mainForm.setError("Camera webresponse: " + e.GetType());
                mainForm.camera_btn_text("Connect");
                disconnect();
                return resp;
            }
        }


        private void option(string command)
        {
            try
            {
                if (isConnected())
                {
                    byte[] buffer = new byte[100000];
                    int read, total = 0;
                    // get response
                    WebResponse resp = webResponse(command);
                    // get response stream
                    Stream imagestream = resp.GetResponseStream();
                    // read data from stream
                    while ((read = imagestream.Read(buffer, total, 1000)) != 0)
                    {
                        total += read;
                    }
                    imagestream.Close();
                  }
            }
            catch (Exception e)
            {
                Console.WriteLine("Camera option: {0}", e);
                mainForm.setError("Camera option: " + e.GetType());
                mainForm.camera_btn_text("Connect");
                disconnect();
            }
        }


        public Bitmap get_image()
        {
            try
            {
                if (isConnected())
                {
                    byte[] buffer = new byte[100000];
                    int read, total = 0;
                    // get response
                    WebResponse resp = webResponse("shot.jpg");
                    // get response stream
                    Stream imagestream = resp.GetResponseStream();
                    // read data from stream
                    while ((read = imagestream.Read(buffer, total, 1000)) != 0)
                    {
                        total += read;
                    }
                    // get bitmap
                    return (Bitmap)Bitmap.FromStream(new MemoryStream(buffer, 0, total));

                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine("Camera photo: {0}", e);
                mainForm.setError("Camera photo: " + e.GetType());
                mainForm.camera_btn_text("Connect");
                disconnect();
                return null;
            }
        }


        //MJPEG Video
        //This function is for displaying a live MJPEG video stream from an IP camera (Foscam FI8910W)
        //It works by sending the http request for MJPEG video and processing the received continuous stream
        //The function picks out the individual JPEG frames by searching for the JPEG header and JPEG footer
        //When a JPEG header is found, it starts saving the data into a byte array called imagebuffer. It keeps
        //saving until the JPEG footer is detected. Once this happens, the JPEG image is created from the byte
        //array, and displayed. The imagebuffer byte array is cleared, and the process starts again.
        //The size of the imagebuffer array is 64000. While developing this code, it was found that the JPEG typically
        //fills up to 36000.

        public void video_stream()
        {
            try
            {
       
                    WebResponse resp = webResponse("video");

                    //Video stream is a multipart http response, with a defined boundary "ipcamera".
                    //Each part starts with a header, and ends with the boundary (<CR><LF>--ipcamera)

                    Stream imagestream = resp.GetResponseStream();

                    const int BufferSize = 64000;
                    byte[] imagebuffer = new byte[BufferSize];
                    int a = 2;
                    int framecounter = 0;
                    int framecounter2 = 0;
                    int startreading = 0;
                    byte[] start_checker = new byte[2];
                    byte[] end_checker = new byte[2];

                    //reset videorun flag
                    connect();

                    while (isConnected())
                    {
                        start_checker[1] = (byte)imagestream.ReadByte();
                        end_checker[1] = start_checker[1];

                        //This if statement searches for the JPEG header, and performs the relevant operations
                        if (start_checker[0] == 0xff && start_checker[1] == 0xd8)// && Reset ==0)
                        {
                            Array.Clear(imagebuffer, 0, imagebuffer.Length);
                            //Rebuild jpeg header into imagebuffer
                            imagebuffer[0] = 0xff;
                            imagebuffer[1] = 0xd8;
                            a = 2;
                            framecounter++;
                            startreading = 1;
                        }

                        //This if statement searches for the JPEG footer, and performs the relevant operations
                        if (end_checker[0] == 0xff && end_checker[1] == 0xd9)
                        {
                            framecounter2++;
                            startreading = 0;
                            //Write final part of JPEG header into imagebuffer
                            imagebuffer[a] = start_checker[1];
                            MemoryStream jpegstream = new MemoryStream(imagebuffer);
                            Bitmap bmp = (Bitmap)Bitmap.FromStream(jpegstream);
                            mainForm.reloadCam(bmp);//display image
                        }

                        //This if statement fills the imagebuffer, if the relevant flags are set
                        if (startreading == 1 && a < BufferSize)
                        {
                            imagebuffer[a] = start_checker[1];
                            a++;
                        }

                        //Catches error condition where a = buffer size - this should not happen in normal operation
                        if (a == BufferSize)
                        {
                            a = 2;
                            startreading = 0;
                        }

                        start_checker[0] = start_checker[1];
                        end_checker[0] = end_checker[1];

                    }
                    resp.Close();
       
            }
            catch (Exception e)
            {
                Console.WriteLine("Camera streaming: {0}", e);
                mainForm.setError("Camera streaming: " + e.GetType());
                mainForm.camera_btn_text("Connect");
                disconnect();
            }
        }

        public void flashlight()
        {
            if (isConnected())
            {
                if (enableTorch == true)
                {
                    option("disabletorch");
                    enableTorch = false;
                    mainForm.reloadFlashlight_btn("Enable flashlight");
                }
                else
                {
                    option("enabletorch");
                    enableTorch = true;
                    mainForm.reloadFlashlight_btn("Disable flashlight");
                }
                Console.WriteLine("camera flashlight");
            }
        }

        public void cameraMode()
        {
            if (isConnected())
            {
                if (fromMode == true)
                {
                    option("settings/ffc?set=off");
                    fromMode = false;
                    mainForm.reloadCameraMode_btn("From Mode");
                }
                else
                {
                    option("settings/ffc?set=on");
                    fromMode = true;
                    mainForm.reloadCameraMode_btn("Back Mode");
                }
                Console.WriteLine("camera mode");
            }

        }

        //camera zoom
        public void zoom(int value)
        {
            
            if (isConnected()) 
            {
                int v = value;
                if (value < 0)
                    v = 0;
               option("ptz?zoom=" + value);
               mainForm.reloadCameraZoom(v);
               Console.WriteLine("camera zoom");
            }

        }

        // display batery informatión
        public void overlay()
        {
            if (isConnected())
            {
                if (enableOverlay == true)
                {
                    option("settings/overlay?set=off");
                    enableOverlay = false;
                    mainForm.reloadOverlay_btn("Enable Overlay");
                }
                else
                {
                    option("settings/overlay?set=on");
                    enableOverlay = true;
                    mainForm.reloadOverlay_btn("Disable Overlay");
                }
                Console.WriteLine("camera overlay");
            }
        }
    }
}
