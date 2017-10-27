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
            File.Create("odp.txt").Close();
            string answers = "";

            var factory = new SingularityFactory();
            var singularity = factory.GetSingularity();

            var job = new SimpleParameterizedJob<string>((parameter, scheduledTime) =>
             File.WriteAllText("odp.txt", answers));

            var schedule1 = new CronSchedule("0,30 * * * * * *");

            var scheduledJob1 = singularity.ScheduleParameterizedJob(
                schedule1, job, "", true);

            singularity.Start();



            List<QueryChecker> queryList = new List<QueryChecker>();

            while (true)
            {
                Console.WriteLine(Environment.NewLine+"Proszę podać numer zapytania:" + Environment.NewLine );
                int number = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine(Environment.NewLine+"Proszę wpisać zapytanie:" + Environment.NewLine);
                string text = Console.ReadLine();
                answers = "";

                QueryChecker currentQuery = new QueryChecker(number, text);

                bool correct = currentQuery.CheckQuery(text);

                if (correct)

                {
                    Console.WriteLine(Environment.NewLine+"Zapytanie poprawne. Zostanie dodane do pliku w ciągu najbliższych 30 sekund." + Environment.NewLine);

                    for (int i = queryList.Count - 1; i >= 0; i--)
                    {
                        if (queryList[i].QueryNr == number)
                        {
                            queryList.RemoveAt(i);
                        }
                    }

                    queryList.Add(new QueryChecker(number, text));
                    queryList.Sort(QueryChecker.SortQueries);
                
                   

                        foreach (var query in queryList)

                        { answers += (Convert.ToString(query.QueryNr) + ". " + query.QueryText + Environment.NewLine); }
                }

                else Console.WriteLine(Environment.NewLine+"Zapytanie nie spełnia wymagań!" + Environment.NewLine);

                              
                // select a from b where c order by d          
                            
            }


        }
    }
}