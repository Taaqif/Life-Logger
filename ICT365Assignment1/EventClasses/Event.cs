using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ICT365Assignment1
{
    public abstract class Event : IRenderable, IXml, IWinFormPanel
    {
        public Event()
        {
            CustomProperties = new Dictionary<string, object>();
        }
        private String id;
        public Dictionary<string, object> CustomProperties { get; private set; }
        public Coordinates Location { get => location; set => location = value; }
        public DateTime Datetimestamp { get => datetimestamp; set => datetimestamp = value; }
        public string ID { get => id; set => id = value; }
        public HashSet<string> Links { get => links; set => links = value; }

        private HashSet<string> links = new HashSet<string>();
        private Coordinates location;
        private DateTime datetimestamp = new DateTime();
        public abstract void Render();
        public abstract XElement ToXElement(XNamespace ns);
        public abstract Panel CreatePanel();
        public abstract bool IsValid();
    }
}
