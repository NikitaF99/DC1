using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Authenticator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hey so like welcome to my server");

            //This is the actual host service system
            //ServiceHost provides everything you need to host a service
            ServiceHost host;

            //This represents a tcp/ip binding in the Windows network stack
            NetTcpBinding tcp = new NetTcpBinding();

            //Bind server to the implementation of DataServer
            host = new ServiceHost(typeof(DataServer));

            //Present the publicly accessible interface to the client. 
            //:10108 means this will use port 10108. Srvice1 is a name for the actual service, this can be any string.
            host.AddServiceEndpoint(typeof(ServerInterface), tcp, "net.tcp://localhost:10108/Service1");

           
        
            //And open the host for business!
            host.Open();


            //the below lines of codes are used only for purpose of testing the server.........................
            DataServer dataServer = new DataServer();

            Console.WriteLine("System Online");
           
            Console.WriteLine("Enter username:");
           var name = Console.ReadLine();

           Console.WriteLine("Enter password:");
            var Password = Console.ReadLine();
            

            Console.WriteLine(dataServer.Register(name, Password));
            Console.WriteLine(dataServer.Login("Nikita", "niki"));

            String result = dataServer.validate(0);
            Console.WriteLine(result);

            // String result = dataServer.validate(81);
            Console.WriteLine(result);



            //Don't forget to close the host after you're done!
            host.Close();
        }
    }
}
