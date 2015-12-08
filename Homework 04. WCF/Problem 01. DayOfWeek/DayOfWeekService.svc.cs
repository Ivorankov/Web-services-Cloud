using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class DayOfWeekService : IDayOfWeekService
    {

        private string[] daysCollection;

        public DayOfWeekService()
        {
            this.daysCollection = new string[7];
            this.daysCollection[0] = "Понеделник";
            this.daysCollection[1] = "Вторник";
            this.daysCollection[2] = "Сряда";
            this.daysCollection[3] = "Четвъртък";
            this.daysCollection[4] = "Петък";
            this.daysCollection[5] = "Събота";
            this.daysCollection[6] = "Неделя";
        }

        public string GetDayOfWeek(DateTime date)
        {
            return this.daysCollection[DayOfWeek(date)];
        }


        private int DayOfWeek(DateTime date)
        {
            var day = date.DayOfWeek.ToString();
            switch (day)
            {
                case "Monday": return 0;
                case "Tuesday": return 1;
                case "Wednesday": return 2;
                case "Thursday": return 3;
                case "Friday": return 4;
                case "Saturday": return 5;
                case "Sunday": return 6;
                default: return 0;
            }
        }
    }
}
