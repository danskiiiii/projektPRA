using Microsoft.VisualStudio.TestTools.UnitTesting;
using projektPRA;
using System;

namespace projektPRAunitTest
{
    [TestClass]
    public class UnitTestsSchoolPeriodChecker
    {
        
        SchoolPeriodChecker testObj = new SchoolPeriodChecker();


        [TestMethod]
        public void CheckPeriodTest1()
        {

            DateTime testTime = new DateTime(2017, 10, 30, 15, 13, 0);

            string actual = testObj.CheckPeriod(testTime);

            const string expected = "2 minut do końca zajęć";

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void CheckPeriodTest2()
        {

            DateTime testTime = new DateTime(2017, 10, 30, 9, 46, 0);

            string actual = testObj.CheckPeriod(testTime);

            const string expected = "14 minut do końca przerwy";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckPeriodTest3()
        {

            DateTime testTime = new DateTime(2017, 10, 30, 5, 15, 0);

            string actual = testObj.CheckPeriod(testTime);

            const string expected = "Zajęcia zaczynamy o 8:15";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckPeriodTest4()
        {

            DateTime testTime = new DateTime(2017, 10, 30, 18, 55, 0);

            string actual = testObj.CheckPeriod(testTime);

            const string expected = "Koniec zajęć na dziś";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckPeriodTest5()
        {

            DateTime testTime = new DateTime(2017, 10, 30, 13, 13, 13);

            string actual = testObj.CheckPeriod(testTime);

            const string expected = "10000 lat do końca zajęć";

            Assert.AreNotEqual(expected, actual);
        }


    }
}
