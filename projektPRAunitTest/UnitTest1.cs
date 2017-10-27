using Microsoft.VisualStudio.TestTools.UnitTesting;
using projektPRA;

using System.Text.RegularExpressions;

namespace projektPRAunitTest
{
    [TestClass]
    public class UnitTest1
    {

        public bool CheckQuery(string s)
        {
            Regex rex = new Regex(@"((select )).*(( from )).*(( where )).*(( order by ))", RegexOptions.IgnoreCase);

            if (rex.IsMatch(s))
                return true;
            else return false;
        }



        [TestMethod]
        public void CheckQueryTest1()
        {           

            string query = "zle query 123";

            bool actual  = CheckQuery(query);

            const bool expected = false;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckQueryTest2()
        {

            string query = "Select a from aa where aaa order by aaaa";

            bool actual = CheckQuery(query);

            const bool expected = true;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckQueryTest3()
        {

            string query = "select a where aaa order by aaaa";

            bool actual = CheckQuery(query);

            const bool expected = false;

            Assert.AreEqual(expected, actual);
        }
    }
}
