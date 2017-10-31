using System;
using System.Collections.Generic;
using System.Text;

namespace projektPRA
{
  public class SchoolPeriodChecker
    {
        public SchoolPeriodChecker() { }

        /// <summary>
        /// method for checking how many minutes left till the end of current school period
        /// </summary>
        public string CheckPeriod (DateTime currentTime)
        {                        
            TimeSpan now = currentTime.TimeOfDay;

            TimeSpan start = new TimeSpan(00, 00, 1);
            TimeSpan end = new TimeSpan(8,14,59);
            if (start <= now && now <= end)
            {                
                return "Zajęcia zaczynamy o 8:15";
            }

            start = new TimeSpan(8, 15, 0);
            end = new TimeSpan(9, 44, 59);
            if (start <= now && now <= end)
            {
                var timeLeft = end - now;
                return Convert.ToString((timeLeft.Hours*60) + timeLeft.Minutes +1)+ " minut do końca zajęć";
            }

            start = new TimeSpan(9, 45, 0);
            end = new TimeSpan(9, 59, 59);
            if (start <= now && now <= end)
            {
                var timeLeft = end - now;
                return Convert.ToString(timeLeft.Minutes + 1) + " minut do końca przerwy";
            }


            start = new TimeSpan(10, 0, 0);
            end = new TimeSpan(11, 29, 59);
            if (start <= now && now <= end)
            {
                var timeLeft = end - now;
                return Convert.ToString((timeLeft.Hours * 60) + timeLeft.Minutes +1) + " minut do końca zajęć";
            }

            start = new TimeSpan(11,30, 0);
            end = new TimeSpan(11, 44, 59);
            if (start <= now && now <= end)
            {
                var timeLeft = end - now;
                return Convert.ToString(timeLeft.Minutes + 1) + " minut do końca przerwy";
            }

            start = new TimeSpan(11, 45, 0);
            end = new TimeSpan(13, 14, 59);
            if (start <= now && now <= end)
            {
                var timeLeft = end - now;
                return Convert.ToString((timeLeft.Hours * 60) + timeLeft.Minutes + 1) + " minut do końca zajęć";
            }

            start = new TimeSpan(13, 15, 0);
            end = new TimeSpan(13, 44, 59);
            if (start <= now && now <= end)
            {
                var timeLeft = end - now;
                return Convert.ToString(timeLeft.Minutes + 1) + " minut do końca przerwy";
            }

            start = new TimeSpan(13, 45, 0);
            end = new TimeSpan(15, 14, 59);
            if (start <= now && now <= end)
            {
                var timeLeft = end - now;
                return Convert.ToString((timeLeft.Hours * 60) + timeLeft.Minutes + 1) + " minut do końca zajęć";
            }


            start = new TimeSpan(15, 15, 0);
            end = new TimeSpan(15, 29, 59);
            if (start <= now && now <= end)
            {
                var timeLeft = end - now;
                return Convert.ToString(timeLeft.Minutes + 1) + " minut do końca przerwy";
            }

            start = new TimeSpan(15, 30, 0);
            end = new TimeSpan(16, 59, 59);
            if (start <= now && now <= end)
            {
                var timeLeft = end - now;
                return Convert.ToString((timeLeft.Hours * 60) + timeLeft.Minutes + 1) + " minut do końca zajęć";
            }

            start = new TimeSpan(17, 0, 0);
            end = new TimeSpan(17, 14, 59);
            if (start <= now && now <= end)
            {
                var timeLeft = end - now;
                return Convert.ToString(timeLeft.Minutes + 1) + " minut do końca przerwy";
            }

            start = new TimeSpan(17, 15, 0);
            end = new TimeSpan(18, 44, 59);
            if (start <= now && now <= end)
            {
                var timeLeft = end - now;
                return Convert.ToString((timeLeft.Hours * 60) + timeLeft.Minutes + 1) + " minut do końca zajęć";
            }

            else return "Koniec zajęć na dziś";
        }
    }
}
