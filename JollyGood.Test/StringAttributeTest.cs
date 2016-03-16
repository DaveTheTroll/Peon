using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JollyGood.Test
{
    [TestClass]
    public class StringAttributeTest
    {
        enum A
        {
            One,
            [String("2")]
            Two,
            [String("3"), String("Roman", "III")]
            Three,
            [String("4"), String(1, "FOUR")]
            Four
        }

        [TestMethod]
        public void DefaultTest()
        {
            Assert.AreEqual("One", StringAttribute.GetString(A.One));
            Assert.AreEqual("2", StringAttribute.GetString(A.Two));
            Assert.AreEqual("3", StringAttribute.GetString(A.Three));
            Assert.AreEqual("4", StringAttribute.GetString(A.Four));
        }

        [TestMethod]
        public void RomanTest()
        {
            Assert.AreEqual("One", StringAttribute.GetString(A.One, "Roman"));
            Assert.AreEqual("2", StringAttribute.GetString(A.Two, "Roman"));
            Assert.AreEqual("III", StringAttribute.GetString(A.Three, "Roman"));
            Assert.AreEqual("4", StringAttribute.GetString(A.Four, "Roman"));
        }

        [TestMethod]
        public void NumberTest()
        {
            Assert.AreEqual("One", StringAttribute.GetString(A.One, 1));
            Assert.AreEqual("2", StringAttribute.GetString(A.Two, 1));
            Assert.AreEqual("3", StringAttribute.GetString(A.Three, 1));
            Assert.AreEqual("FOUR", StringAttribute.GetString(A.Four, 1));
        }
    }
}
