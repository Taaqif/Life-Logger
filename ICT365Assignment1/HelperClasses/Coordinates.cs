using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT365Assignment1
{
    public class Coordinates
    {
        //only allow one constructor, ensure lat and long gets set
        public Coordinates(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
        private double latitude;
        private double longitude;

        public override string ToString()
        {
            StringBuilder location = new StringBuilder();
            location.Append(this.Latitude);
            location.Append(", ");
            location.Append(this.Longitude);
            return location.ToString();
        }

        public double Latitude { get => latitude; set => latitude = value; }
        public double Longitude { get => longitude; set => longitude = value; }
    }
}
