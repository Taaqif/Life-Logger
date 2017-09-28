using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICT365Assignment1
{

    
    public partial class EventDetailsForm : Form
    {
        private Panel details;

        public Panel Details { get => details; set => details = value; }

        private EventDetailsForm()
        {
            InitializeComponent();
            
        }
        private static EventDetailsForm aForm = null;
        public static EventDetailsForm Instance()
        {
            if (aForm == null)
            {
                aForm = new EventDetailsForm();
            }
            return aForm;
        }
        private void mainDetailsPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void EventDetailsForm_Load(object sender, EventArgs e)
        {
            mainDetailsPanel.Controls.Clear();
            mainDetailsPanel.Controls.Add(Details);
        }
    }
}
