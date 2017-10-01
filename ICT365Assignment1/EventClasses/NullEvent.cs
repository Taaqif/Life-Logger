using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ICT365Assignment1
{
    class NullEvent : Event
    {
        public override Panel CreatePanel()
        {
            return new Panel();
        }

        public override bool IsValid()
        {
            return false;
        }

        public override void Render()
        {
            Console.WriteLine("Null event cant render");
        }

        public override XElement ToXElement(XNamespace ns)
        {
            return new XElement(null, null);
        }
    }
}
