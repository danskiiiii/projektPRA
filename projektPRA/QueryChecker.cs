using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
namespace projektPRA
{
  public class QueryChecker
    {
        private int queryNr;
        private string queryText;

        public QueryChecker(int queryNr, string queryText)
        {
            this.queryNr = queryNr;
            this.queryText = queryText;
        }

        public int QueryNr
        {
            get { return queryNr; }
            set { queryNr = value; }
        }

        public string QueryText
        {
            get { return queryText; }
            set { queryText = value; }
        }

        /// <summary>
        /// method for checking if string is a valid SQL query
        /// </summary>
        public bool CheckQuery(string s)
        {
            Regex rex = new Regex(@"((select )).*(( from )).*(( where )).*(( order by ))", RegexOptions.IgnoreCase);

            if (rex.IsMatch(s))
                return true;
            else return false;
        }

        /// <summary>
        /// method for sorting SQL queries by query number
        /// </summary>
        public static int SortQueries(QueryChecker x, QueryChecker y)
        { return x.QueryNr.CompareTo(y.QueryNr); }

    }
}
