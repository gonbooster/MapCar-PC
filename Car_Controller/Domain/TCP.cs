using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Windows.Forms;
using Car_Controller.View;

namespace Car_Controller.Domain
{
    class TCP
    {
        private NetworkStream stream;
        private TcpClient client;
        private Boolean connected;
        private FormMain mainForm;

    public TCP(FormMain mainForm) {
        this.mainForm = mainForm;
        stream = null;
        client = null;
        connected = false;
    }
        public void connect(string ip, int port)
        {
            try{
                if (!isConnected())
                { 
                    client = new TcpClient(ip,port);
                    stream = client.GetStream();
                    connected = true;
                }
            }
            catch (Exception e)
            {
                connected = false;
                Console.WriteLine("TCP connect: {0}", e);
                mainForm.setError("TCP connect: " + e.GetType());
                mainForm.car_btn_text("Connect");
            }
        }

        public Boolean isConnected()
        {
            if (connected==true)
                return true;
            else
                return false;
        }

       public void close()
        {
           try{
               if (isConnected())
                send(":" + 0 + ":" + 0 + ":" + 0 + ";");
               client.Close();
               stream.Close();
               connected = false;
               Console.WriteLine("TCP Closed");

           }
           catch (Exception e)
           {
               connected = false;
               Console.WriteLine("TCP close: {0}", e);
               mainForm.setError("TCP close: " + e.GetType());
               mainForm.car_btn_text("Connect");
           }
        }
       public void send(string message)
        {
            try
            {
                if (isConnected())
                {
                    Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
                    // Send the message to the connected TcpServer. 
                    stream.Write(data, 0, data.Length);
                }
            }
            catch (Exception e)
            {
                connected = false;
                Console.WriteLine("TCP send: {0}", e);
                mainForm.setError("TCP send: " + e.GetType());
                mainForm.car_btn_text("Connect");
            }
        }
        
       public string recive()
        {
            string responseData = string.Empty;
            // Buffer to store the response bytes.
            
            try
            {
                if (isConnected())
                {
                    Byte[] data = new Byte[500];
                    // Read the first batch of the TcpServer response bytes.
                    Int32 bytes = stream.Read(data, 0, data.Length);
                    responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                    //Console.WriteLine("Received: {0}", responseData);
                }
                // Close everything.
                return responseData;

            }
            catch (Exception e)
            {
                connected = false;
                Console.WriteLine("TCP recive: {0}", e);
                mainForm.setError("TCP recive: " + e.GetType());
                mainForm.car_btn_text("Connect");
                return responseData;
            }
        }
    }
}
