using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

using Chroniton;
using Chroniton.Jobs;
using Chroniton.Schedules;


namespace projektPRA
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("W celu wyjścia z programu należy podać 0 jako numer zapytania.");
            File.Create("odp.txt").Close();
            string temp = "";
            int number =0;
            string text = "";
            QueryChecker currentQuery = new QueryChecker(number, text);
            SchoolPeriodChecker timeChecker = new SchoolPeriodChecker();
            List<QueryChecker> queryList = new List<QueryChecker>();


            /// <summary>
            /// code for running cron jobs
            /// </summary>
            var factory = new SingularityFactory();
            var singularity = factory.GetSingularity();

            //writing queries to a file every 30 sec
            var job1 = new SimpleParameterizedJob<string>((parameter, scheduledTime) =>
            File.WriteAllText("odp.txt", temp));

            var schedule1 = new CronSchedule("0,30 * * * * * *");            
            var scheduledJob1 = singularity.ScheduleParameterizedJob(
                schedule1, job1, "", true);

            //displaying time left until the end of current school period
            var job2 = new SimpleParameterizedJob<string>((parameter, scheduledTime) =>
            Console.WriteLine("                           "+timeChecker.CheckPeriod(DateTime.Now)));

            var schedule2 = new CronSchedule("0 * 7-17 ? * MON-FRI *"); // cron schedule works in UTC time zone, offset -1 hour to convert to CET time
            var scheduledJob2 = singularity.ScheduleParameterizedJob(
                schedule2, job2, "", true);

            singularity.Start();

            /// <summary>
            /// main loop: takes input from user and processes it
            /// </summary>
            while (true)
            {
                // taking input from user
                try
                {
                    Console.WriteLine(Environment.NewLine + "Proszę podać numer zapytania:");
                    number = Convert.ToInt32(Console.ReadLine());
                }
                catch 
                {
                    Console.WriteLine(Environment.NewLine + "Wprowadzono niepoprawny numer zapytania!");
                    continue;
                }                
                if (number == 0) break; //exit the loop if 0 was entered as query number

                Console.WriteLine(Environment.NewLine+"Proszę wpisać zapytanie:");
                text = Console.ReadLine();

                // checking if the SQL query is correct
                bool correct = currentQuery.CheckQuery(text);

                if (correct)
                {
                    temp = "";
                    Console.WriteLine(Environment.NewLine+"Zapytanie poprawne. Zostanie automatycznie dodane do pliku w ciągu najbliższych 30 sekund.");

                    // replacing old query if the ID is the same 
                    for (int i = queryList.Count - 1; i >= 0; i--)
                    {
                        if (queryList[i].QueryNr == number)
                        {
                            queryList.RemoveAt(i);
                        }
                    }

                    // adding new query to list of objects and sorting it
                    queryList.Add(new QueryChecker(number, text));
                    queryList.Sort(QueryChecker.SortQueries);

                    // parsing objects from a list to temp string (for txt file export purpose)
                    foreach (var query in queryList)
                    {
                      temp += (Convert.ToString(query.QueryNr) + ". " + query.QueryText + Environment.NewLine);
                    }
                }

                // informing user about incorrect query
                else Console.WriteLine(Environment.NewLine+ "Zapytanie nie spełnia wymagań!");                     
                             
                           
            }

            //add remaining correct queries to odp.txt after exiting the loop
            File.WriteAllText("odp.txt", temp);

        }
    }
}