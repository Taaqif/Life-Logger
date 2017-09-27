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
            this.linkEventsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Toolbox = new System.Windows.Forms.GroupBox();
            this.ToolboxEventFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.searchRadiusLabel = new System.Windows.Forms.Label();
            this.radiusInput = new System.Windows.Forms.TextBox();
            this.mapContextMenu.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.Toolbox.SuspendLayout();
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
            this.mapCtrl.Size = new System.Drawing.Size(559, 471);
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
            this.linkEventsToolStripMenuItem});
            this.mapContextMenu.Name = "mapContextMenu";
            this.mapContextMenu.Size = new System.Drawing.Size(205, 70);
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
            // linkEventsToolStripMenuItem
            // 
            this.linkEventsToolStripMenuItem.Name = "linkEventsToolStripMenuItem";
            this.linkEventsToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.linkEventsToolStripMenuItem.Text = "Link events";
            this.linkEventsToolStripMenuItem.Click += new System.EventHandler(this.linkEventsToolStripMenuItem_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(863, 24);
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
            this.Toolbox.Controls.Add(this.radiusInput);
            this.Toolbox.Controls.Add(this.searchRadiusLabel);
            this.Toolbox.Controls.Add(this.ToolboxEventFlowLayout);
            this.Toolbox.Location = new System.Drawing.Point(577, 27);
            this.Toolbox.Name = "Toolbox";
            this.Toolbox.Size = new System.Drawing.Size(277, 471);
            this.Toolbox.TabIndex = 5;
            this.Toolbox.TabStop = false;
            this.Toolbox.Text = "Toolbox";
            // 
            // ToolboxEventFlowLayout
            // 
            this.ToolboxEventFlowLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ToolboxEventFlowLayout.AutoScroll = true;
            this.ToolboxEventFlowLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.ToolboxEventFlowLayout.Location = new System.Drawing.Point(6, 49);
            this.ToolboxEventFlowLayout.Name = "ToolboxEventFlowLayout";
            this.ToolboxEventFlowLayout.Size = new System.Drawing.Size(265, 402);
            this.ToolboxEventFlowLayout.TabIndex = 0;
            this.ToolboxEventFlowLayout.WrapContents = false;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 510);
            this.Controls.Add(this.Toolbox);
            this.Controls.Add(this.mapCtrl);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.mapContextMenu.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.Toolbox.ResumeLayout(false);
            this.Toolbox.PerformLayout();
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
    }
}