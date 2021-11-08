using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Authenticator;
using Registry;
using Registry.Controllers;
using Registry.Models;

namespace ServicePublishingConsole
{
    class Program
    {
       // private ServerInterface foob;
        static void Main(string[] args)
        {
            //To access the seerver interface and its functions chanels are createdd through below set of codes.......................
            ServerInterface foob;

            //This is a factory that generates remote connections to our remote class. This is what hides the RPC stuff!
            ChannelFactory<Authenticator.ServerInterface> foobFactory;
            NetTcpBinding tcp = new NetTcpBinding();

            //Set the URL and create the connection!
            string URL = "net.tcp://localhost:10108/Service1";
            foobFactory = new ChannelFactory<ServerInterface>(tcp, URL);
             foob = foobFactory.CreateChannel();
            //........................................


            Console.WriteLine("Have you registered to the system?");
            String ans = Console.ReadLine();

            int token =0;
                        //the app asks for the username and password in the console and sends them to  an appropriate Authentication service and Login . 

                        if (ans.Equals("YES") ||ans.Equals("yes") ||ans.Equals("Yes") == true)
                        {
                            Console.WriteLine("Welcome to system login");
                            Console.WriteLine("Enter username:");
                            String user = Console.ReadLine();

                            Console.WriteLine("Enter password");
                            String pass = Console.ReadLine();

                            token=foob.Login(user,pass);
                        }

                        //the app asks for the username and password in the console and sends them to an appropriate Authentication service called register.

                        else
                        {
                            Console.WriteLine("Let's start our registration process");
                            Console.WriteLine("Please enter a username:");
                            String user = Console.ReadLine();

                            Console.WriteLine("Please enter password");
                            String pass = Console.ReadLine();

                            foob.Register(user, pass);
                        }
                        Console.WriteLine("You are all set");
                        


            //Checking whetehr user wants to publish service
           
            Console.WriteLine("Do you want to publish a service?");
            String ans1 = Console.ReadLine();


            if (ans1.Equals("YES") || ans1.Equals("yes") || ans1.Equals("Yes") == true)
            {
                //getting details about the services and sending them to an appropriate Registry service to publish..........................................

                PublishModel publishObject = new PublishModel();

                Console.WriteLine("Enter Servicename:");
                publishObject.Name = Console.ReadLine();


                Console.WriteLine("Enter Service description:");
                publishObject.Description = Console.ReadLine();

                Console.WriteLine("Enter Api endpoint:");
                publishObject.Api_endpoint = Console.ReadLine();

                Console.WriteLine("Enter no of operands:");
                publishObject.number_of_operands = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter operand type:");
                publishObject.operand_type = Console.ReadLine();
                publishObject.id = token;

                //calling the respective post method
                PublishController pb = new PublishController();
                pb.Post(publishObject);
                Console.WriteLine("Your service is published successfully");
            }

            //...........................................................
          
            //Checking whther user wants to unpublish service..................
            Console.WriteLine("Do you want to unpublish a service?");
            String upAns = Console.ReadLine();


            if (upAns.Equals("YES") || upAns.Equals("yes") || upAns.Equals("Yes") == true)
            {


                Console.WriteLine("We are going to unpublish a service");


                UnpublishModel unpublishObject = new UnpublishModel();
                //app asks the user to imput api end point
                Console.WriteLine("Enter apiEnd point:");
                unpublishObject.Api_endpoint = Console.ReadLine();

                UnpublishController up = new UnpublishController();
                up.Post(unpublishObject);

                Console.WriteLine("Your service is unpublished successfully");

            }


        }
    }
}
