using Microsoft.VisualStudio.TestTools.UnitTesting;
using projektPRA;

namespace projektPRAunitTest
{
    [TestClass]
    public class UnitTestsQueryChecker
    {     
       static int temp1 = 0;
       static string temp2 = "";
       QueryChecker testObj = new QueryChecker(temp1,temp2);


        [TestMethod]
        public void CheckQueryTest1()
        {           

            string query = "incorrect query 123";

            bool actual  = testObj.CheckQuery(query);

            const bool expected = false;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckQueryTest2()
        {

            string query = "select a where aaa order by aaaa from XX";

            bool actual = testObj.CheckQuery(query);

            const bool expected = false;

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void CheckQueryTest3()
        {

            string query = "SelecT a from aa wHERE aaa order by aaaa";

            bool actual = testObj.CheckQuery(query);

            const bool expected = true;

            Assert.AreEqual(expected, actual);
        }

     
        [TestMethod]
        public void CheckQueryTest4()
        {

            string query = "SELECT 1 FROM 2 WHERE 3 ORDER BY 4 ";

            bool actual = testObj.CheckQuery(query);

            const bool expected = true;

            Assert.AreEqual(expected, actual);
        }
    }
}
