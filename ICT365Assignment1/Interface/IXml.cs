using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ICT365Assignment1
{
    public interface IXml
    {
        XElement ToXElement(XNamespace ns);
    }
}
