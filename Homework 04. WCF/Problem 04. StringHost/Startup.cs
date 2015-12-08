namespace Problem_04.StringHost
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Description;
    using Problem_03.RepeatingStrings;

    internal class Startup
    {
        static void Main()
        {
            Uri serviceAddress = new Uri("http://localhost:9111/");
            ServiceHost host = new ServiceHost(typeof(StringSearcherService), serviceAddress);

            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            host.Description.Behaviors.Add(smb);

            using (host)
            {
                try
                {
                    host.Open();
                    Console.WriteLine("Server running");

                    Console.WriteLine("Press any key to shutdown");
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Run the exe as admin!");
                }
            }
        }
    }
}
