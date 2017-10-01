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
    public class EventsHelperTests
    {
        [TestMethod()]
        public void IncrementIDTest()
        {
            EventsHelper helper = EventsHelper.Instance();
            //test if the incrementing the ID works
            string expectedID = "ID200";
            Assert.AreEqual(expectedID, helper.IncrementStringID("ID199"));
        }
    }
}