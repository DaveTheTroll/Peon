using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Peon.Maps;

namespace Peon.Test
{
    [TestClass]
    public class PolylineTest
    {
        [TestMethod]
        public void PolylineDecodeTest()
        {
            string text = "my~_IfxaF^tW??lS}L";
            Peon.Maps.Polyline polyline = new Peon.Maps.Polyline() { Points = text };
            List<LatLong> points = polyline.GetList();

            // 52.59175, -1.16116
            // 52.59159, -1.16511
            // 52.58832, -1.16288
            Assert.AreEqual(4, points.Count);
            Assert.AreEqual(52.59175, points[0].Latitude, 1e-5);
            Assert.AreEqual(-1.16116, points[0].Longitude, 1e-5);
            Assert.AreEqual(52.59159, points[1].Latitude, 1e-5);
            Assert.AreEqual(-1.16511, points[1].Longitude, 1e-5);
            Assert.AreEqual(52.59159, points[2].Latitude, 1e-5);
            Assert.AreEqual(-1.16511, points[2].Longitude, 1e-5);
            Assert.AreEqual(52.58832, points[3].Latitude, 1e-5);
            Assert.AreEqual(-1.16288, points[3].Longitude, 1e-5);
        }
    }
}
