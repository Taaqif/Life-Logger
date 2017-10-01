namespace ICT365Assignment1
{
    partial class AddEventForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>

        

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.locationInfoLabel = new System.Windows.Forms.Label();
            this.eventTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.TracklogRadioButton = new System.Windows.Forms.RadioButton();
            this.VideoRadioButton = new System.Windows.Forms.RadioButton();
            this.photoRadioButton = new System.Windows.Forms.RadioButton();
            this.facebookRadioButton = new System.Windows.Forms.RadioButton();
            this.tweetRadioButton = new System.Windows.Forms.RadioButton();
            this.addEventButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.mainGroupBox = new System.Windows.Forms.GroupBox();
            this.mainControlPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.locationLabel = new System.Windows.Forms.Label();
            this.eventTypeGroupBox.SuspendLayout();
            this.mainGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // locationInfoLabel
            // 
            this.locationInfoLabel.AutoSize = true;
            this.locationInfoLabel.Location = new System.Drawing.Point(15, 18);
            this.locationInfoLabel.Name = "locationInfoLabel";
            this.locationInfoLabel.Size = new System.Drawing.Size(57, 13);
            this.locationInfoLabel.TabIndex = 0;
            this.locationInfoLabel.Text = "Add Event";
            // 
            // eventTypeGroupBox
            // 
            this.eventTypeGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eventTypeGroupBox.AutoSize = true;
            this.eventTypeGroupBox.Controls.Add(this.TracklogRadioButton);
            this.eventTypeGroupBox.Controls.Add(this.VideoRadioButton);
            this.eventTypeGroupBox.Controls.Add(this.photoRadioButton);
            this.eventTypeGroupBox.Controls.Add(this.facebookRadioButton);
            this.eventTypeGroupBox.Controls.Add(this.tweetRadioButton);
            this.eventTypeGroupBox.Location = new System.Drawing.Point(12, 63);
            this.eventTypeGroupBox.Name = "eventTypeGroupBox";
            this.eventTypeGroupBox.Size = new System.Drawing.Size(354, 56);
            this.eventTypeGroupBox.TabIndex = 2;
            this.eventTypeGroupBox.TabStop = false;
            this.eventTypeGroupBox.Text = "Event Type";
            // 
            // TracklogRadioButton
            // 
            this.TracklogRadioButton.AutoSize = true;
            this.TracklogRadioButton.Location = new System.Drawing.Point(263, 20);
            this.TracklogRadioButton.Name = "TracklogRadioButton";
            this.TracklogRadioButton.Size = new System.Drawing.Size(67, 17);
            this.TracklogRadioButton.TabIndex = 4;
            this.TracklogRadioButton.TabStop = true;
            this.TracklogRadioButton.Text = "Tracklog";
            this.TracklogRadioButton.UseVisualStyleBackColor = true;
            this.TracklogRadioButton.CheckedChanged += new System.EventHandler(this.radioSwitchTracklog);
            // 
            // VideoRadioButton
            // 
            this.VideoRadioButton.AutoSize = true;
            this.VideoRadioButton.Location = new System.Drawing.Point(205, 20);
            this.VideoRadioButton.Name = "VideoRadioButton";
            this.VideoRadioButton.Size = new System.Drawing.Size(52, 17);
            this.VideoRadioButton.TabIndex = 3;
            this.VideoRadioButton.TabStop = true;
            this.VideoRadioButton.Text = "Video";
            this.VideoRadioButton.UseVisualStyleBackColor = true;
            this.VideoRadioButton.CheckedChanged += new System.EventHandler(this.radioSwitchVideo);
            // 
            // photoRadioButton
            // 
            this.photoRadioButton.AutoSize = true;
            this.photoRadioButton.Location = new System.Drawing.Point(146, 19);
            this.photoRadioButton.Name = "photoRadioButton";
            this.photoRadioButton.Size = new System.Drawing.Size(53, 17);
            this.photoRadioButton.TabIndex = 2;
            this.photoRadioButton.TabStop = true;
            this.photoRadioButton.Text = "Photo";
            this.photoRadioButton.UseVisualStyleBackColor = true;
            this.photoRadioButton.CheckedChanged += new System.EventHandler(this.radioSwitchPhoto);
            // 
            // facebookRadioButton
            // 
            this.facebookRadioButton.AutoSize = true;
            this.facebookRadioButton.Location = new System.Drawing.Point(67, 19);
            this.facebookRadioButton.Name = "facebookRadioButton";
            this.facebookRadioButton.Size = new System.Drawing.Size(73, 17);
            this.facebookRadioButton.TabIndex = 1;
            this.facebookRadioButton.TabStop = true;
            this.facebookRadioButton.Text = "Facebook";
            this.facebookRadioButton.UseVisualStyleBackColor = true;
            this.facebookRadioButton.CheckedChanged += new System.EventHandler(this.radioSwitchFacebook);
            // 
            // tweetRadioButton
            // 
            this.tweetRadioButton.AutoSize = true;
            this.tweetRadioButton.Location = new System.Drawing.Point(6, 20);
            this.tweetRadioButton.Name = "tweetRadioButton";
            this.tweetRadioButton.Size = new System.Drawing.Size(55, 17);
            this.tweetRadioButton.TabIndex = 0;
            this.tweetRadioButton.TabStop = true;
            this.tweetRadioButton.Text = "Tweet";
            this.tweetRadioButton.UseVisualStyleBackColor = true;
            this.tweetRadioButton.CheckedChanged += new System.EventHandler(this.radioSwitchTwitter);
            // 
            // addEventButton
            // 
            this.addEventButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addEventButton.AutoSize = true;
            this.addEventButton.Location = new System.Drawing.Point(291, 248);
            this.addEventButton.Name = "addEventButton";
            this.addEventButton.Size = new System.Drawing.Size(75, 23);
            this.addEventButton.TabIndex = 3;
            this.addEventButton.Text = "Add Event";
            this.addEventButton.UseVisualStyleBackColor = true;
            this.addEventButton.Click += new System.EventHandler(this.addEventButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(210, 248);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // mainGroupBox
            // 
            this.mainGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainGroupBox.AutoSize = true;
            this.mainGroupBox.Controls.Add(this.mainControlPanel);
            this.mainGroupBox.Location = new System.Drawing.Point(12, 125);
            this.mainGroupBox.Name = "mainGroupBox";
            this.mainGroupBox.Size = new System.Drawing.Size(354, 117);
            this.mainGroupBox.TabIndex = 5;
            this.mainGroupBox.TabStop = false;
            this.mainGroupBox.Text = "Event Details";
            // 
            // mainControlPanel
            // 
            this.mainControlPanel.AutoSize = true;
            this.mainControlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainControlPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.mainControlPanel.Location = new System.Drawing.Point(3, 16);
            this.mainControlPanel.Name = "mainControlPanel";
            this.mainControlPanel.Size = new System.Drawing.Size(348, 98);
            this.mainControlPanel.TabIndex = 0;
            // 
            // locationLabel
            // 
            this.locationLabel.AutoSize = true;
            this.locationLabel.Location = new System.Drawing.Point(15, 36);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(83, 13);
            this.locationLabel.TabIndex = 6;
            this.locationLabel.Text = "Location not set";
            // 
            // AddEventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(378, 283);
            this.Controls.Add(this.locationLabel);
            this.Controls.Add(this.mainGroupBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.addEventButton);
            this.Controls.Add(this.eventTypeGroupBox);
            this.Controls.Add(this.locationInfoLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEventForm";
            this.Text = "Add Event";
            this.Load += new System.EventHandler(this.AddEventForm_Load);
            this.eventTypeGroupBox.ResumeLayout(false);
            this.eventTypeGroupBox.PerformLayout();
            this.mainGroupBox.ResumeLayout(false);
            this.mainGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label locationInfoLabel;
        private System.Windows.Forms.GroupBox eventTypeGroupBox;
        private System.Windows.Forms.RadioButton photoRadioButton;
        private System.Windows.Forms.RadioButton facebookRadioButton;
        private System.Windows.Forms.RadioButton tweetRadioButton;
        private System.Windows.Forms.Button addEventButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.RadioButton TracklogRadioButton;
        private System.Windows.Forms.RadioButton VideoRadioButton;
        private System.Windows.Forms.GroupBox mainGroupBox;
        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.FlowLayoutPanel mainControlPanel;
    }
}