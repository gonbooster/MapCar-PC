namespace Car_Controller.View
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.configMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.map_Box = new GMap.NET.WindowsForms.GMapControl();
            this.camera_Box = new System.Windows.Forms.PictureBox();
            this.labelGPS = new System.Windows.Forms.Label();
            this.image_Box = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tcp_port = new System.Windows.Forms.TextBox();
            this.tcp_ip = new System.Windows.Forms.TextBox();
            this.tcp_connect_btn = new System.Windows.Forms.Button();
            this.ip_address_textbox = new System.Windows.Forms.Label();
            this.photo_btn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.camera_port = new System.Windows.Forms.TextBox();
            this.camera_ip = new System.Windows.Forms.TextBox();
            this.camera_connect_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.explore_btn = new System.Windows.Forms.Button();
            this.errorControllerBox = new System.Windows.Forms.GroupBox();
            this.errorBox = new System.Windows.Forms.TextBox();
            this.f_b_camera_btn = new System.Windows.Forms.Button();
            this.flashlight_btn = new System.Windows.Forms.Button();
            this.main_groupBox = new System.Windows.Forms.GroupBox();
            this.joystick_lbl = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.export_btn = new System.Windows.Forms.Button();
            this.overlay_btn = new System.Windows.Forms.Button();
            this.label_Zoom = new System.Windows.Forms.Label();
            this.zoomBar = new System.Windows.Forms.TrackBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.camera_Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.image_Box)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.errorControllerBox.SuspendLayout();
            this.main_groupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomBar)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configMenu,
            this.helpMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1332, 24);
            this.menuStrip1.TabIndex = 66;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // configMenu
            // 
            this.configMenu.Name = "configMenu";
            this.configMenu.Size = new System.Drawing.Size(55, 20);
            this.configMenu.Text = "Config";
            this.configMenu.Click += new System.EventHandler(this.configToolStripMenuItem_Click);
            // 
            // helpMenu
            // 
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(44, 20);
            this.helpMenu.Text = "Help";
            this.helpMenu.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // map_Box
            // 
            this.map_Box.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.map_Box.Bearing = 0F;
            this.map_Box.CanDragMap = true;
            this.map_Box.EmptyTileColor = System.Drawing.Color.Navy;
            this.map_Box.GrayScaleMode = false;
            this.map_Box.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.map_Box.LevelsKeepInMemmory = 5;
            this.map_Box.Location = new System.Drawing.Point(662, 19);
            this.map_Box.MarkersEnabled = true;
            this.map_Box.MaxZoom = 2;
            this.map_Box.MinZoom = 2;
            this.map_Box.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.map_Box.Name = "map_Box";
            this.map_Box.NegativeMode = false;
            this.map_Box.PolygonsEnabled = true;
            this.map_Box.RetryLoadTile = 0;
            this.map_Box.RoutesEnabled = true;
            this.map_Box.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.map_Box.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.map_Box.ShowTileGridLines = false;
            this.map_Box.Size = new System.Drawing.Size(636, 449);
            this.map_Box.TabIndex = 67;
            this.map_Box.Zoom = 0D;
            this.map_Box.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.gmap_OnMarkerClick);
            this.map_Box.Load += new System.EventHandler(this.gMapControl_Load);
            // 
            // camera_Box
            // 
            this.camera_Box.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.camera_Box.BackColor = System.Drawing.Color.Gray;
            this.camera_Box.Location = new System.Drawing.Point(6, 19);
            this.camera_Box.Name = "camera_Box";
            this.camera_Box.Size = new System.Drawing.Size(617, 461);
            this.camera_Box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.camera_Box.TabIndex = 21;
            this.camera_Box.TabStop = false;
            // 
            // labelGPS
            // 
            this.labelGPS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelGPS.AutoSize = true;
            this.labelGPS.Location = new System.Drawing.Point(939, 19);
            this.labelGPS.Name = "labelGPS";
            this.labelGPS.Size = new System.Drawing.Size(0, 13);
            this.labelGPS.TabIndex = 22;
            // 
            // image_Box
            // 
            this.image_Box.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.image_Box.Location = new System.Drawing.Point(662, 35);
            this.image_Box.Name = "image_Box";
            this.image_Box.Size = new System.Drawing.Size(636, 433);
            this.image_Box.TabIndex = 68;
            this.image_Box.TabStop = false;
            this.image_Box.Visible = false;
            this.image_Box.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.tcp_port);
            this.groupBox3.Controls.Add(this.tcp_ip);
            this.groupBox3.Controls.Add(this.tcp_connect_btn);
            this.groupBox3.Controls.Add(this.ip_address_textbox);
            this.groupBox3.Location = new System.Drawing.Point(676, 486);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(616, 51);
            this.groupBox3.TabIndex = 67;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "TCP Controller";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(270, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = ":";
            // 
            // tcp_port
            // 
            this.tcp_port.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.tcp_port.Location = new System.Drawing.Point(286, 25);
            this.tcp_port.Name = "tcp_port";
            this.tcp_port.Size = new System.Drawing.Size(45, 20);
            this.tcp_port.TabIndex = 27;
            this.tcp_port.Text = "400";
            // 
            // tcp_ip
            // 
            this.tcp_ip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.tcp_ip.Location = new System.Drawing.Point(138, 25);
            this.tcp_ip.Name = "tcp_ip";
            this.tcp_ip.Size = new System.Drawing.Size(126, 20);
            this.tcp_ip.TabIndex = 26;
            this.tcp_ip.Text = "192.168.43.116";
            // 
            // tcp_connect_btn
            // 
            this.tcp_connect_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.tcp_connect_btn.Location = new System.Drawing.Point(374, 12);
            this.tcp_connect_btn.Name = "tcp_connect_btn";
            this.tcp_connect_btn.Size = new System.Drawing.Size(134, 33);
            this.tcp_connect_btn.TabIndex = 23;
            this.tcp_connect_btn.Text = "Connect";
            this.tcp_connect_btn.UseVisualStyleBackColor = true;
            this.tcp_connect_btn.Click += new System.EventHandler(this.tcp_connect_Click);
            // 
            // ip_address_textbox
            // 
            this.ip_address_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.ip_address_textbox.AutoSize = true;
            this.ip_address_textbox.Location = new System.Drawing.Point(90, 28);
            this.ip_address_textbox.Name = "ip_address_textbox";
            this.ip_address_textbox.Size = new System.Drawing.Size(17, 13);
            this.ip_address_textbox.TabIndex = 25;
            this.ip_address_textbox.Text = "IP";
            // 
            // photo_btn
            // 
            this.photo_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.photo_btn.Location = new System.Drawing.Point(16, 22);
            this.photo_btn.Name = "photo_btn";
            this.photo_btn.Size = new System.Drawing.Size(116, 26);
            this.photo_btn.TabIndex = 22;
            this.photo_btn.Text = "Take Photo";
            this.photo_btn.UseVisualStyleBackColor = true;
            this.photo_btn.Click += new System.EventHandler(this.camera_photo_button_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.camera_port);
            this.groupBox2.Controls.Add(this.camera_ip);
            this.groupBox2.Controls.Add(this.camera_connect_btn);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(7, 486);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(616, 56);
            this.groupBox2.TabIndex = 66;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Camera Controller";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(270, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = ":";
            // 
            // camera_port
            // 
            this.camera_port.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.camera_port.Location = new System.Drawing.Point(286, 17);
            this.camera_port.Name = "camera_port";
            this.camera_port.Size = new System.Drawing.Size(45, 20);
            this.camera_port.TabIndex = 29;
            this.camera_port.Text = "8080";
            // 
            // camera_ip
            // 
            this.camera_ip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.camera_ip.Location = new System.Drawing.Point(138, 17);
            this.camera_ip.Name = "camera_ip";
            this.camera_ip.Size = new System.Drawing.Size(126, 20);
            this.camera_ip.TabIndex = 26;
            this.camera_ip.Text = "192.168.43.1";
            // 
            // camera_connect_btn
            // 
            this.camera_connect_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.camera_connect_btn.Location = new System.Drawing.Point(374, 17);
            this.camera_connect_btn.Name = "camera_connect_btn";
            this.camera_connect_btn.Size = new System.Drawing.Size(131, 33);
            this.camera_connect_btn.TabIndex = 23;
            this.camera_connect_btn.Text = "Connect";
            this.camera_connect_btn.UseVisualStyleBackColor = true;
            this.camera_connect_btn.Click += new System.EventHandler(this.camera_video_button_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "IP";
            // 
            // explore_btn
            // 
            this.explore_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.explore_btn.Location = new System.Drawing.Point(138, 86);
            this.explore_btn.Name = "explore_btn";
            this.explore_btn.Size = new System.Drawing.Size(116, 26);
            this.explore_btn.TabIndex = 70;
            this.explore_btn.Text = "Explorer";
            this.explore_btn.UseVisualStyleBackColor = true;
            this.explore_btn.Click += new System.EventHandler(this.explore_btn_Click);
            // 
            // errorControllerBox
            // 
            this.errorControllerBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.errorControllerBox.Controls.Add(this.errorBox);
            this.errorControllerBox.Location = new System.Drawing.Point(662, 548);
            this.errorControllerBox.Name = "errorControllerBox";
            this.errorControllerBox.Size = new System.Drawing.Size(636, 112);
            this.errorControllerBox.TabIndex = 67;
            this.errorControllerBox.TabStop = false;
            this.errorControllerBox.Text = "Feedback";
            // 
            // errorBox
            // 
            this.errorBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.errorBox.Location = new System.Drawing.Point(14, 23);
            this.errorBox.Multiline = true;
            this.errorBox.Name = "errorBox";
            this.errorBox.ReadOnly = true;
            this.errorBox.Size = new System.Drawing.Size(608, 69);
            this.errorBox.TabIndex = 0;
            // 
            // f_b_camera_btn
            // 
            this.f_b_camera_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.f_b_camera_btn.Location = new System.Drawing.Point(138, 21);
            this.f_b_camera_btn.Name = "f_b_camera_btn";
            this.f_b_camera_btn.Size = new System.Drawing.Size(116, 27);
            this.f_b_camera_btn.TabIndex = 71;
            this.f_b_camera_btn.Text = "Front Camera";
            this.f_b_camera_btn.UseVisualStyleBackColor = true;
            this.f_b_camera_btn.Click += new System.EventHandler(this.f_b_camera_btn_Click);
            // 
            // flashlight_btn
            // 
            this.flashlight_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.flashlight_btn.Location = new System.Drawing.Point(16, 54);
            this.flashlight_btn.Name = "flashlight_btn";
            this.flashlight_btn.Size = new System.Drawing.Size(116, 26);
            this.flashlight_btn.TabIndex = 72;
            this.flashlight_btn.Text = "Enable Flashlight";
            this.flashlight_btn.UseVisualStyleBackColor = true;
            this.flashlight_btn.Click += new System.EventHandler(this.flashlight_btn_Click);
            // 
            // main_groupBox
            // 
            this.main_groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.main_groupBox.Controls.Add(this.joystick_lbl);
            this.main_groupBox.Controls.Add(this.groupBox1);
            this.main_groupBox.Controls.Add(this.errorControllerBox);
            this.main_groupBox.Controls.Add(this.groupBox2);
            this.main_groupBox.Controls.Add(this.groupBox3);
            this.main_groupBox.Controls.Add(this.image_Box);
            this.main_groupBox.Controls.Add(this.labelGPS);
            this.main_groupBox.Controls.Add(this.camera_Box);
            this.main_groupBox.Controls.Add(this.map_Box);
            this.main_groupBox.Location = new System.Drawing.Point(12, 27);
            this.main_groupBox.Name = "main_groupBox";
            this.main_groupBox.Size = new System.Drawing.Size(1308, 696);
            this.main_groupBox.TabIndex = 65;
            this.main_groupBox.TabStop = false;
            // 
            // joystick_lbl
            // 
            this.joystick_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.joystick_lbl.AutoSize = true;
            this.joystick_lbl.Location = new System.Drawing.Point(1187, 667);
            this.joystick_lbl.Name = "joystick_lbl";
            this.joystick_lbl.Size = new System.Drawing.Size(45, 13);
            this.joystick_lbl.TabIndex = 67;
            this.joystick_lbl.Text = "Joystick";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.export_btn);
            this.groupBox1.Controls.Add(this.overlay_btn);
            this.groupBox1.Controls.Add(this.label_Zoom);
            this.groupBox1.Controls.Add(this.zoomBar);
            this.groupBox1.Controls.Add(this.flashlight_btn);
            this.groupBox1.Controls.Add(this.f_b_camera_btn);
            this.groupBox1.Controls.Add(this.explore_btn);
            this.groupBox1.Controls.Add(this.photo_btn);
            this.groupBox1.Location = new System.Drawing.Point(7, 548);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(616, 132);
            this.groupBox1.TabIndex = 67;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // export_btn
            // 
            this.export_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.export_btn.Location = new System.Drawing.Point(16, 86);
            this.export_btn.Name = "export_btn";
            this.export_btn.Size = new System.Drawing.Size(116, 26);
            this.export_btn.TabIndex = 75;
            this.export_btn.Text = "Export Map";
            this.export_btn.UseVisualStyleBackColor = true;
            this.export_btn.Click += new System.EventHandler(this.export_btn_Click);
            // 
            // overlay_btn
            // 
            this.overlay_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.overlay_btn.Location = new System.Drawing.Point(138, 53);
            this.overlay_btn.Name = "overlay_btn";
            this.overlay_btn.Size = new System.Drawing.Size(116, 27);
            this.overlay_btn.TabIndex = 74;
            this.overlay_btn.Text = "Enable Overlay";
            this.overlay_btn.UseVisualStyleBackColor = true;
            this.overlay_btn.Click += new System.EventHandler(this.overlay_btn_Click);
            // 
            // label_Zoom
            // 
            this.label_Zoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label_Zoom.AutoSize = true;
            this.label_Zoom.Location = new System.Drawing.Point(294, 29);
            this.label_Zoom.Name = "label_Zoom";
            this.label_Zoom.Size = new System.Drawing.Size(37, 13);
            this.label_Zoom.TabIndex = 73;
            this.label_Zoom.Text = "Zoom:";
            // 
            // zoomBar
            // 
            this.zoomBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.zoomBar.Location = new System.Drawing.Point(297, 54);
            this.zoomBar.Name = "zoomBar";
            this.zoomBar.Size = new System.Drawing.Size(299, 45);
            this.zoomBar.TabIndex = 69;
            this.zoomBar.ValueChanged += new System.EventHandler(this.zoomBar_ValueChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1332, 735);
            this.Controls.Add(this.main_groupBox);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Car Controller";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.Form_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.camera_Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.image_Box)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.errorControllerBox.ResumeLayout(false);
            this.errorControllerBox.PerformLayout();
            this.main_groupBox.ResumeLayout(false);
            this.main_groupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem configMenu;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private GMap.NET.WindowsForms.GMapControl map_Box;
        private System.Windows.Forms.PictureBox camera_Box;
        private System.Windows.Forms.Label labelGPS;
        private System.Windows.Forms.PictureBox image_Box;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tcp_port;
        private System.Windows.Forms.TextBox tcp_ip;
        private System.Windows.Forms.Button tcp_connect_btn;
        private System.Windows.Forms.Label ip_address_textbox;
        private System.Windows.Forms.Button photo_btn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox camera_port;
        private System.Windows.Forms.TextBox camera_ip;
        private System.Windows.Forms.Button camera_connect_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button explore_btn;
        private System.Windows.Forms.GroupBox errorControllerBox;
        private System.Windows.Forms.TextBox errorBox;
        private System.Windows.Forms.Button f_b_camera_btn;
        private System.Windows.Forms.Button flashlight_btn;
        private System.Windows.Forms.GroupBox main_groupBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_Zoom;
        private System.Windows.Forms.TrackBar zoomBar;
        private System.Windows.Forms.Button overlay_btn;
        private System.Windows.Forms.Label joystick_lbl;
        private System.Windows.Forms.Button export_btn;
        private System.Windows.Forms.Timer timer1;

    }
}

