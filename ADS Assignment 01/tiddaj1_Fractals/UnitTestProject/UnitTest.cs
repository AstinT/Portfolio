using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tiddaj1_Fractals;
using System.Drawing;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestFindMidPoint()
        {
            PointF p1 = new PointF(10, 10);
            PointF p2 = new PointF(20, 20);

            PointF expected = new PointF(15, 15);
            PointF actual = Mathmatics.findMidPoint(p1, p2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCalcDistBetweenPoints()
        {
            PointF p1 = new PointF(10, 0);
            PointF p2 = new PointF(20, 0);

            float expected = 10;
            float actual = Mathmatics.calcDistBetweenPoints(p1, p2);

            Assert.AreEqual(expected, actual);
        }
    }
}
