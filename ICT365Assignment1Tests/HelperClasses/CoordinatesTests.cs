using Microsoft.VisualStudio.TestTools.UnitTesting;
using ICT365Assignment1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT365Assignment1.Tests
{
    [TestClass()]
    public class CoordinatesTests
    {
        [TestMethod()]
        public void CoordinatesConstructorTest()
        {
            //test to make sure the coordinates are not switched
            double expectedLatitude = -31.950527;
            double expectedLongitude = 115.860457;

            Coordinates coordinates = new Coordinates(-31.950527, 115.860457);

            Assert.AreEqual(expectedLatitude,coordinates.Latitude);
            Assert.AreEqual(expectedLongitude, coordinates.Longitude);
        }
    }
}