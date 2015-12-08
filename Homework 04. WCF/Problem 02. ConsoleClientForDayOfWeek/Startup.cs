using System;

namespace Problem_02.ConsoleClientForDayOfWeek
{
    public class Startup
    {
        static void Main()
        {
            var client = new ServiceReference2.DayOfWeekServiceClient();
            var day = client.GetDayOfWeek(DateTime.Now);

            Console.WriteLine(day);
            Console.WriteLine("If you see ??? its due to Console settings/ just use debug");
        }
    }
}
