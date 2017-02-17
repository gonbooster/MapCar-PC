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
using Car_Controller.Domain;

namespace Car_Controller.Domain
{
    class Joystick_Custom
    {
             private FormMain mainForm;

        public Joystick_Custom(FormMain mainForm)
        {
            this.mainForm = mainForm;
        }

        //CAR move
        private String gear = "stop";
        private int thottle = 0;
        private int steering = 0;

        //The following variables are used across several threads
        private float shared_left_trig = 0;
        private float shared_left_stick_x = 0;
        //private float shared_left_stick_y = 0;
        private float shared_right_trig = 0;
        private float shared_right_stick_x = 0;
        private float shared_right_stick_y = 0;

        private int shared_A = 0;
        private int shared_B = 0;
        private int shared_X = 0;
        private int shared_Y = 0;

        private int shared_dpad_up = 0;
        private int shared_dpad_down = 0;
        private int shared_dpad_left = 0;
        private int shared_dpad_right = 0;

        private int shared_left_shoulder = 0;
        private int shared_right_shoulder = 0;


        private int steering_mode = 0;
        private int throttle_mode = 0;

        private int headlights = 0;
        private int light_brightness = 5;
        private int light_sequence = 0;
        private int slowmode = 0;

        //counters used for managing the toggling of car functions
        //eg headlights or slow mode. These counters are used to stop repeated toggling on/off
        //if the xbox controller button is held down too long
        private int samplecount = 0;
        private int oldsamplecount1 = 0;
        private int rumblecount = 0;


        //---------------------------------------------------------------------------------------------------------
        //The following section contains code for handling the Xbox360 controller
        //---------------------------------------------------------------------------------------------------------


        public void UpdateState()
        {
            try
            {

                while (true)
                {
                    thottle = 0; //set thottle to 0 at the begin of the interation
                    GamePadState state = GamePad.GetState(PlayerIndex.One);

                    if (!state.IsConnected)
                        mainForm.joystick_Text("Joystick Disconnected");
                    else
                        mainForm.joystick_Text("Joystick Connected");


                    //Read analog control values and save into shared variables
                    //Left/right triggers and left thumbstick (x-axis only) also have a process function to change
                    //the behaviour of the controls between linear/squared/cubed modes.
                    //Squared and cubed gives more control for low speed / small steering angles

                    shared_left_trig = state.Triggers.Left;
                    shared_left_trig = process_raw_throttle_data(shared_left_trig);
                    display_left_trig(shared_left_trig);
                    shared_left_stick_x = state.ThumbSticks.Left.X;
                    shared_left_stick_x = process_raw_steer_data(shared_left_stick_x);
                    display_left_stick_x(shared_left_stick_x);
                    //display_left_stick_y(shared_left_stick_y);

                    shared_right_trig = state.Triggers.Right;
                    shared_right_trig = process_raw_throttle_data(shared_right_trig);
                    display_right_trig(shared_right_trig);
                    shared_right_stick_x = state.ThumbSticks.Right.X;
                    display_right_stick_x(shared_right_stick_x);
                    shared_right_stick_y = state.ThumbSticks.Right.Y;
                    //display_right_stick_y(shared_right_stick_y);

                    //Update digital button values
                    //The xinputdotnetpure wrapper returns the text "Pressed" or "Released" for button state
                    //The following if statements read this status for the various buttons, and update the shared status variables

                    if (state.Buttons.LeftShoulder.ToString().Equals("Pressed"))
                    {
                        shared_left_shoulder = 1;
                    }
                    else if (state.Buttons.LeftShoulder.ToString().Equals("Released"))
                    {
                        shared_left_shoulder = 0;
                    }
                    if (state.Buttons.RightShoulder.ToString().Equals("Pressed"))
                    {
                        shared_right_shoulder = 1;
                    }
                    else if (state.Buttons.RightShoulder.ToString().Equals("Released"))
                    {
                        shared_right_shoulder = 0;
                    }

                    if (state.DPad.Up.ToString().Equals("Pressed"))
                    {
                        //simple check to stop function toggling on/off when button is held too long
                        if ((samplecount - oldsamplecount1) > 3 || (samplecount - oldsamplecount1) < 0)
                        {
                            shared_dpad_up = 1;
                            if (light_brightness < 9)
                            {
                                light_brightness++;
                            }
                            else
                            {
                                light_brightness = 9;
                            }
                        }
                        oldsamplecount1 = samplecount;
                    }
                    else if (state.DPad.Up.ToString().Equals("Released"))
                    {
                        shared_dpad_up = 0;
                    }

                    if (state.DPad.Down.ToString().Equals("Pressed"))
                    {
                        //simple check to stop function toggling on/off when button is held too long
                        if ((samplecount - oldsamplecount1) > 3 || (samplecount - oldsamplecount1) < 0)
                        {
                            shared_dpad_down = 1;
                            if (light_brightness > 1)
                            {
                                light_brightness--;
                            }
                            else
                            {
                                light_brightness = 1;
                            }
                        }
                        oldsamplecount1 = samplecount;
                    }
                    else if (state.DPad.Down.ToString().Equals("Released"))
                    {
                        shared_dpad_down = 0;
                    }

                    if (state.DPad.Left.ToString().Equals("Pressed"))
                    {
                        //simple check to stop function toggling on/off when button is held too long
                        if ((samplecount - oldsamplecount1) > 3 || (samplecount - oldsamplecount1) < 0)
                        {
                            shared_dpad_left = 1;
                            if (light_sequence > 0)
                            {
                                light_sequence--;
                            }
                            else
                            {
                                light_sequence = 9;
                            }
                        }
                        oldsamplecount1 = samplecount;
                    }
                    else if (state.DPad.Left.ToString().Equals("Released"))
                    {
                        shared_dpad_left = 0;
                    }

                    if (state.DPad.Right.ToString().Equals("Pressed"))
                    {
                        //simple check to stop function toggling on/off when button is held too long
                        if ((samplecount - oldsamplecount1) > 3 || (samplecount - oldsamplecount1) < 0)
                        {
                            shared_dpad_right = 1;
                            if (light_sequence < 9)
                            {
                                light_sequence++;
                            }
                            else
                            {
                                light_sequence = 0;
                            }
                        }
                        oldsamplecount1 = samplecount;
                    }
                    else if (state.DPad.Right.ToString().Equals("Released"))
                    {
                        shared_dpad_right = 0;
                    }


                    if (state.Buttons.A.ToString().Equals("Pressed"))
                    {
                        shared_A = 1;
                        //GamePad.SetVibration(PlayerIndex.One, 0.5f,0.0f);     //test code - left motor vibrates when A is pressed
                    }
                    else if (state.Buttons.A.ToString().Equals("Released"))
                    {
                        shared_A = 0;
                        //GamePad.SetVibration(PlayerIndex.One, 0.0f, 0.0f);    //test code - vibration is off when A is released
                    }
                    if (state.Buttons.B.ToString().Equals("Pressed"))
                    {
                        //simple check to stop function toggling on/off when button is held too long
                        if ((samplecount - oldsamplecount1) > 3 || (samplecount - oldsamplecount1) < 0)
                        {
                            shared_B = 1;
                            if (slowmode == 0)
                            {
                                slowmode = 1;
                            }
                            else
                            {
                                slowmode = 0;
                            }
                        }
                        oldsamplecount1 = samplecount;
                    }
                    else if (state.Buttons.B.ToString().Equals("Released"))
                    {
                        shared_B = 0;
                    }
                    if (state.Buttons.X.ToString().Equals("Pressed"))
                    {
                        shared_X = 1;
                    }
                    else if (state.Buttons.X.ToString().Equals("Released"))
                    {
                        shared_X = 0;
                    }
                    if (state.Buttons.Y.ToString().Equals("Pressed"))
                    {
                        //simple check to stop function toggling on/off when button is held too long
                        if ((samplecount - oldsamplecount1) > 3 || (samplecount - oldsamplecount1) < 0)
                        {
                            shared_Y = 1;
                            if (headlights == 0)
                            {
                                headlights = 1;
                            }
                            else
                            {
                                headlights = 0;
                            }
                        }
                        oldsamplecount1 = samplecount;
                    }
                    else if (state.Buttons.Y.ToString().Equals("Released"))
                    {
                        shared_Y = 0;
                    }

                    //The following 'invokes' update the GUI with the various button statuses
                    //display_left_shoulder(shared_left_shoulder);
                    //display_right_shoulder(shared_right_shoulder);
                    display_dpad_up(shared_dpad_up);
                    display_dpad_down(shared_dpad_down);
                    display_dpad_left(shared_dpad_left);
                    display_dpad_right(shared_dpad_right);
                    display_button_A(shared_A);
                    display_button_B(shared_B);
                    display_button_X(shared_X);
                    display_button_Y(shared_Y);

                    //Put a limit on how frequently this updates
                   // Thread.Sleep(50);

                    //Frame counter for managing repeated on/off toggling of car functions
                    //For example, this counter is used for the headlight on/off toggle, to stop it
                    //turning on/off continuously when the button is held down.
                    samplecount++;
                    //manually reset counter if it gets large
                    if (samplecount > 2000000000)
                    {
                        samplecount = 0;
                    }

                    //Countdown rumblecount
                    //Rumblecount is required so that rumble occurs for a minimum number of controller frames
                    if (rumblecount > 0)
                    {
                        GamePad.SetVibration(PlayerIndex.One, 0.8f, 0.5f);
                        rumblecount--;
                    }
                    else if (rumblecount == 0)
                    {
                        GamePad.SetVibration(PlayerIndex.One, 0.0f, 0.0f);
                    }
                        mainForm.moveCar(gear, thottle, steering);
                    }

                            }
            catch (Exception e)
            {
                Console.WriteLine("Joystick: {0}", e);
                mainForm.setError("Joystick: " + e.GetType());
            }
        }


        //Functions for processing raw analog control data
        private float process_raw_steer_data(float raw_data)
        {
            float modified_data = 0;
            if (steering_mode == 0)
            {
                modified_data = raw_data;
            }
            else if (steering_mode == 1)
            {
                modified_data = raw_data * raw_data;
                if (raw_data < 0)
                {
                    modified_data = -modified_data;
                }
            }
            else if (steering_mode == 2)
            {
                modified_data = raw_data * raw_data * raw_data;
            }
            return modified_data;
        }

        private float process_raw_throttle_data(float raw_data)
        {
            float modified_data = 0;
            if (throttle_mode == 0)
            {
                modified_data = raw_data;
            }
            else if (throttle_mode == 1)
            {
                modified_data = raw_data * raw_data;
                if (raw_data < 0)
                {
                    modified_data = -modified_data;
                }
            }
            else if (throttle_mode == 2)
            {
                modified_data = raw_data * raw_data * raw_data;
            }
            return modified_data;
        }


        //Functions for use with the delegates
        private void display_left_trig(float i)
        {
            if (i != 0)
            {
                thottle = Convert.ToInt32(i * 10);
                gear = "back";
            }
        }

        private void display_left_stick_x(float i)
        {
            steering = Convert.ToInt32(i * 6);
        }

        private void display_right_stick_x(float i)
        {
            if (i > 0 || i < 0)
            {
                mainForm.cameraZoom(Convert.ToInt32(i * 10));

            }
        }

        private void display_right_trig(float i)
        {
            if (i != 0)
            {
                thottle = Convert.ToInt32(i * 10);
                gear = "forward";

            }
        }


        private void display_dpad_up(int status)
        {
            if (status == 1)
            {
                mainForm.cam_on_of();
                Thread.Sleep(1000);
            }

        }

        private void display_dpad_right(int status)
        {
            if (status == 1)
            {
                mainForm.car_on_of();
                Thread.Sleep(1000);
            }
        }

        private void display_dpad_down(int status)
        {

            if (status == 1)
            {
                mainForm.exportMap();
                Thread.Sleep(500);
            }

        }

        private void display_dpad_left(int status)
        {

            if (status == 1)
            {
                mainForm.openExplorer();
                Thread.Sleep(500);
            }

        }

        private void display_button_A(int status)
        {
            if (status == 1)
            {
                mainForm.take_photo();
                Thread.Sleep(500);
            }
        }

        private void display_button_B(int status)
        {
            if (status == 1)
            {
                mainForm.overlay();
                Thread.Sleep(500);
            }
        }

        private void display_button_X(int status)
        {
            if (status == 1)
            {
                mainForm.flashlight();
                Thread.Sleep(500);
            }
        }

        private void display_button_Y(int status)
        {
            if (status == 1)
            {
                mainForm.cameraMode();
                Thread.Sleep(500);
            }
        }
    }
}