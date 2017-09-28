namespace ICT365Assignment1
{
    partial class MainForm
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
            this.mapCtrl = new GMap.NET.WindowsForms.GMapControl();
            this.mapContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.linkEventsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeLinksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Toolbox = new System.Windows.Forms.GroupBox();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.radiusInput = new System.Windows.Forms.TextBox();
            this.searchRadiusLabel = new System.Windows.Forms.Label();
            this.ToolboxEventFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.legendLabel = new System.Windows.Forms.Label();
            this.linkPictureBox = new System.Windows.Forms.PictureBox();
            this.trackPictureBox = new System.Windows.Forms.PictureBox();
            this.waypointPictureBox = new System.Windows.Forms.PictureBox();
            this.twitterPictureBox = new System.Windows.Forms.PictureBox();
            this.facebookPictureBox = new System.Windows.Forms.PictureBox();
            this.facebookLabel = new System.Windows.Forms.Label();
            this.twitterLabel = new System.Windows.Forms.Label();
            this.wayPointlabel = new System.Windows.Forms.Label();
            this.trackLabel = new System.Windows.Forms.Label();
            this.linkLabel = new System.Windows.Forms.Label();
            this.mapContextMenu.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.Toolbox.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.linkPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.waypointPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.twitterPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facebookPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mapCtrl
            // 
            this.mapCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mapCtrl.Bearing = 0F;
            this.mapCtrl.CanDragMap = true;
            this.mapCtrl.EmptyTileColor = System.Drawing.Color.Navy;
            this.mapCtrl.GrayScaleMode = false;
            this.mapCtrl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.mapCtrl.LevelsKeepInMemmory = 5;
            this.mapCtrl.Location = new System.Drawing.Point(12, 27);
            this.mapCtrl.MarkersEnabled = true;
            this.mapCtrl.MaxZoom = 18;
            this.mapCtrl.MinZoom = 2;
            this.mapCtrl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            this.mapCtrl.Name = "mapCtrl";
            this.mapCtrl.NegativeMode = false;
            this.mapCtrl.PolygonsEnabled = true;
            this.mapCtrl.RetryLoadTile = 0;
            this.mapCtrl.RoutesEnabled = true;
            this.mapCtrl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.mapCtrl.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.mapCtrl.ShowTileGridLines = false;
            this.mapCtrl.Size = new System.Drawing.Size(730, 561);
            this.mapCtrl.TabIndex = 0;
            this.mapCtrl.Zoom = 0D;
            this.mapCtrl.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.gmap_OnMarkerClick);
            this.mapCtrl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mapCtrl_MouseClick);
            // 
            // mapContextMenu
            // 
            this.mapContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolStripSeparator1,
            this.linkEventsToolStripMenuItem,
            this.removeLinksToolStripMenuItem});
            this.mapContextMenu.Name = "mapContextMenu";
            this.mapContextMenu.Size = new System.Drawing.Size(205, 98);
            // 
            // insertToolStripMenuItem
            // 
            this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            this.insertToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.insertToolStripMenuItem.Text = "Insert new event here";
            this.insertToolStripMenuItem.Click += new System.EventHandler(this.insertToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.viewToolStripMenuItem.Text = "View surrounding events";
            this.viewToolStripMenuItem.Click += new System.EventHandler(this.viewToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(201, 6);
            // 
            // linkEventsToolStripMenuItem
            // 
            this.linkEventsToolStripMenuItem.Name = "linkEventsToolStripMenuItem";
            this.linkEventsToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.linkEventsToolStripMenuItem.Text = "Link events";
            this.linkEventsToolStripMenuItem.Click += new System.EventHandler(this.linkEventsToolStripMenuItem_Click);
            // 
            // removeLinksToolStripMenuItem
            // 
            this.removeLinksToolStripMenuItem.Name = "removeLinksToolStripMenuItem";
            this.removeLinksToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.removeLinksToolStripMenuItem.Text = "Remove links";
            this.removeLinksToolStripMenuItem.Click += new System.EventHandler(this.removeLinksToolStripMenuItem_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1023, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            this.menuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Toolbox
            // 
            this.Toolbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Toolbox.AutoSize = true;
            this.Toolbox.Controls.Add(this.InfoLabel);
            this.Toolbox.Controls.Add(this.radiusInput);
            this.Toolbox.Controls.Add(this.searchRadiusLabel);
            this.Toolbox.Controls.Add(this.ToolboxEventFlowLayout);
            this.Toolbox.Location = new System.Drawing.Point(748, 27);
            this.Toolbox.Name = "Toolbox";
            this.Toolbox.Size = new System.Drawing.Size(266, 561);
            this.Toolbox.TabIndex = 5;
            this.Toolbox.TabStop = false;
            this.Toolbox.Text = "Toolbox";
            // 
            // InfoLabel
            // 
            this.InfoLabel.AutoSize = true;
            this.InfoLabel.Location = new System.Drawing.Point(7, 40);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(206, 52);
            this.InfoLabel.TabIndex = 3;
            this.InfoLabel.Text = "Drag the map by left clicking and moving. \r\nUse the mousewheel to zoom.\r\nRight-cl" +
    "ick on the map to perform actions. \r\nLeft-click on an event to view more details" +
    "\r\n";
            // 
            // radiusInput
            // 
            this.radiusInput.Location = new System.Drawing.Point(115, 17);
            this.radiusInput.Name = "radiusInput";
            this.radiusInput.Size = new System.Drawing.Size(26, 20);
            this.radiusInput.TabIndex = 2;
            this.radiusInput.Text = "2";
            this.radiusInput.TextChanged += new System.EventHandler(this.radiusInput_TextChanged);
            this.radiusInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.radiusInput_KeyPress);
            // 
            // searchRadiusLabel
            // 
            this.searchRadiusLabel.AutoSize = true;
            this.searchRadiusLabel.Location = new System.Drawing.Point(7, 20);
            this.searchRadiusLabel.Name = "searchRadiusLabel";
            this.searchRadiusLabel.Size = new System.Drawing.Size(106, 13);
            this.searchRadiusLabel.TabIndex = 1;
            this.searchRadiusLabel.Text = "Search Radius (Kms)";
            // 
            // ToolboxEventFlowLayout
            // 
            this.ToolboxEventFlowLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ToolboxEventFlowLayout.AutoScroll = true;
            this.ToolboxEventFlowLayout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ToolboxEventFlowLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.ToolboxEventFlowLayout.Location = new System.Drawing.Point(6, 95);
            this.ToolboxEventFlowLayout.Name = "ToolboxEventFlowLayout";
            this.ToolboxEventFlowLayout.Size = new System.Drawing.Size(254, 460);
            this.ToolboxEventFlowLayout.TabIndex = 0;
            this.ToolboxEventFlowLayout.WrapContents = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.linkLabel);
            this.panel1.Controls.Add(this.trackLabel);
            this.panel1.Controls.Add(this.wayPointlabel);
            this.panel1.Controls.Add(this.twitterLabel);
            this.panel1.Controls.Add(this.facebookLabel);
            this.panel1.Controls.Add(this.linkPictureBox);
            this.panel1.Controls.Add(this.trackPictureBox);
            this.panel1.Controls.Add(this.waypointPictureBox);
            this.panel1.Controls.Add(this.twitterPictureBox);
            this.panel1.Controls.Add(this.facebookPictureBox);
            this.panel1.Controls.Add(this.legendLabel);
            this.panel1.Location = new System.Drawing.Point(610, 407);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(132, 181);
            this.panel1.TabIndex = 6;
            // 
            // legendLabel
            // 
            this.legendLabel.AutoSize = true;
            this.legendLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.legendLabel.Location = new System.Drawing.Point(4, 4);
            this.legendLabel.Name = "legendLabel";
            this.legendLabel.Size = new System.Drawing.Size(81, 24);
            this.legendLabel.TabIndex = 0;
            this.legendLabel.Text = "Legend";
            // 
            // linkPictureBox
            // 
            this.linkPictureBox.Image = global::ICT365Assignment1.Properties.Resources.link;
            this.linkPictureBox.InitialImage = null;
            this.linkPictureBox.Location = new System.Drawing.Point(8, 151);
            this.linkPictureBox.Name = "linkPictureBox";
            this.linkPictureBox.Size = new System.Drawing.Size(26, 21);
            this.linkPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.linkPictureBox.TabIndex = 5;
            this.linkPictureBox.TabStop = false;
            // 
            // trackPictureBox
            // 
            this.trackPictureBox.Image = global::ICT365Assignment1.Properties.Resources.start_end_track;
            this.trackPictureBox.InitialImage = null;
            this.trackPictureBox.Location = new System.Drawing.Point(8, 113);
            this.trackPictureBox.Name = "trackPictureBox";
            this.trackPictureBox.Size = new System.Drawing.Size(51, 32);
            this.trackPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.trackPictureBox.TabIndex = 4;
            this.trackPictureBox.TabStop = false;
            // 
            // waypointPictureBox
            // 
            this.waypointPictureBox.Image = global::ICT365Assignment1.Properties.Resources.waypoint;
            this.waypointPictureBox.InitialImage = null;
            this.waypointPictureBox.Location = new System.Drawing.Point(8, 86);
            this.waypointPictureBox.Name = "waypointPictureBox";
            this.waypointPictureBox.Size = new System.Drawing.Size(26, 21);
            this.waypointPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.waypointPictureBox.TabIndex = 3;
            this.waypointPictureBox.TabStop = false;
            // 
            // twitterPictureBox
            // 
            this.twitterPictureBox.Image = global::ICT365Assignment1.Properties.Resources.twitter;
            this.twitterPictureBox.InitialImage = null;
            this.twitterPictureBox.Location = new System.Drawing.Point(8, 59);
            this.twitterPictureBox.Name = "twitterPictureBox";
            this.twitterPictureBox.Size = new System.Drawing.Size(26, 21);
            this.twitterPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.twitterPictureBox.TabIndex = 2;
            this.twitterPictureBox.TabStop = false;
            // 
            // facebookPictureBox
            // 
            this.facebookPictureBox.Image = global::ICT365Assignment1.Properties.Resources.facebook;
            this.facebookPictureBox.InitialImage = null;
            this.facebookPictureBox.Location = new System.Drawing.Point(8, 32);
            this.facebookPictureBox.Name = "facebookPictureBox";
            this.facebookPictureBox.Size = new System.Drawing.Size(26, 21);
            this.facebookPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.facebookPictureBox.TabIndex = 1;
            this.facebookPictureBox.TabStop = false;
            // 
            // facebookLabel
            // 
            this.facebookLabel.AutoSize = true;
            this.facebookLabel.Location = new System.Drawing.Point(39, 40);
            this.facebookLabel.Name = "facebookLabel";
            this.facebookLabel.Size = new System.Drawing.Size(86, 13);
            this.facebookLabel.TabIndex = 6;
            this.facebookLabel.Text = "Facebook Event";
            // 
            // twitterLabel
            // 
            this.twitterLabel.AutoSize = true;
            this.twitterLabel.Location = new System.Drawing.Point(39, 67);
            this.twitterLabel.Name = "twitterLabel";
            this.twitterLabel.Size = new System.Drawing.Size(70, 13);
            this.twitterLabel.TabIndex = 7;
            this.twitterLabel.Text = "Twitter Event";
            // 
            // wayPointlabel
            // 
            this.wayPointlabel.AutoSize = true;
            this.wayPointlabel.Location = new System.Drawing.Point(39, 94);
            this.wayPointlabel.Name = "wayPointlabel";
            this.wayPointlabel.Size = new System.Drawing.Size(83, 13);
            this.wayPointlabel.TabIndex = 8;
            this.wayPointlabel.Text = "Track Waypoint";
            // 
            // trackLabel
            // 
            this.trackLabel.AutoSize = true;
            this.trackLabel.Location = new System.Drawing.Point(60, 123);
            this.trackLabel.Name = "trackLabel";
            this.trackLabel.Size = new System.Drawing.Size(49, 13);
            this.trackLabel.TabIndex = 9;
            this.trackLabel.Text = "Tracklog";
            // 
            // linkLabel
            // 
            this.linkLabel.AutoSize = true;
            this.linkLabel.Location = new System.Drawing.Point(40, 159);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(63, 13);
            this.linkLabel.TabIndex = 10;
            this.linkLabel.Text = "Event Links";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 600);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Toolbox);
            this.Controls.Add(this.mapCtrl);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Life Logger v1.0";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.mapContextMenu.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.Toolbox.ResumeLayout(false);
            this.Toolbox.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.linkPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.waypointPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.twitterPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facebookPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl mapCtrl;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip mapContextMenu;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.GroupBox Toolbox;
        private System.Windows.Forms.FlowLayoutPanel ToolboxEventFlowLayout;
        private System.Windows.Forms.ToolStripMenuItem linkEventsToolStripMenuItem;
        private System.Windows.Forms.TextBox radiusInput;
        private System.Windows.Forms.Label searchRadiusLabel;
        private System.Windows.Forms.Label InfoLabel;
        private System.Windows.Forms.ToolStripMenuItem removeLinksToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label legendLabel;
        private System.Windows.Forms.PictureBox waypointPictureBox;
        private System.Windows.Forms.PictureBox twitterPictureBox;
        private System.Windows.Forms.PictureBox facebookPictureBox;
        private System.Windows.Forms.PictureBox trackPictureBox;
        private System.Windows.Forms.PictureBox linkPictureBox;
        private System.Windows.Forms.Label linkLabel;
        private System.Windows.Forms.Label trackLabel;
        private System.Windows.Forms.Label wayPointlabel;
        private System.Windows.Forms.Label twitterLabel;
        private System.Windows.Forms.Label facebookLabel;
    }
}