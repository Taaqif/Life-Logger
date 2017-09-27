namespace ICT365Assignment1
{
    partial class EventDetailsForm
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
            this.mainDetailsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // mainDetailsPanel
            // 
            this.mainDetailsPanel.AutoSize = true;
            this.mainDetailsPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mainDetailsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainDetailsPanel.Location = new System.Drawing.Point(0, 0);
            this.mainDetailsPanel.Name = "mainDetailsPanel";
            this.mainDetailsPanel.Size = new System.Drawing.Size(264, 118);
            this.mainDetailsPanel.TabIndex = 0;
            this.mainDetailsPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainDetailsPanel_Paint);
            // 
            // EventDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(264, 118);
            this.Controls.Add(this.mainDetailsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EventDetailsForm";
            this.Text = "Event Details";
            this.Load += new System.EventHandler(this.EventDetailsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel mainDetailsPanel;
    }
}