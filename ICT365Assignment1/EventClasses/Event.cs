using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ICT365Assignment1
{
    public abstract class Event : IRenderable, IXml
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
        public List<string> Links { get => links; set => links = value; }

        private List<string> links = new List<string>();
        private Coordinates location = new Coordinates();
        private DateTime datetimestamp = new DateTime();
        public abstract void Render();
        public abstract XElement ToXElement(XNamespace ns);
        public abstract Panel CreatePanel();
        public abstract bool isValid();
    }
}
