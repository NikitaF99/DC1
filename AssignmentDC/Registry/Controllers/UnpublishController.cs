using Authenticator;
using Registry.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.ServiceModel;
using System.Web.Http;

//I HAVE TRIED MY BEST IN FINDING A SOLUTION, HOWEVER COULD NOT COME UP WITH A PERFECT SOLUTION

namespace Registry.Controllers
{
    public class UnpublishController : ApiController
    {
        // Given a service endpoint, this rest service will remove the service description from the local text file.
        ServerInterface foob;
        // POST: api/Unpublish
        public Object Post([FromBody] UnpublishModel value)
        {
            //Object called output is created to return the json output
            List<Object> output = new List<Object>();

            //BUSINESS LOGIC ADDED
            //the below set of code is used to call the validate function of the server interface.
            //A channel is created and interface is accessd through it..........................
            ChannelFactory<ServerInterface> foobFactory;

            //creates a client stub
            NetTcpBinding tcp = new NetTcpBinding();

            //Set the URL and create the connection!string
            var URL = "net.tcp://localhost:10108/Service1 ";
            foobFactory = new ChannelFactory<ServerInterface>(tcp, URL);
            foob = foobFactory.CreateChannel();
            //...............................................

            //The result of validation is stored in astring called "result"
            String resultN = foob.validate(value.id);
            //var response;
            if (resultN.Equals("Validated"))
            {
                using (StreamReader sr = File.OpenText("d:\\status.txt"))
                {
                    //Read all the lines
                    string[] lines = File.ReadAllLines("d:\\status.txt");
                    bool isMatch = false;
                    int counter = 0;
                    for (int x = 0; x < lines.Length - 1; x++)
                    {
                        //Checks the keyword with the file
                        isMatch = lines[x].Contains(value.Api_endpoint);
                        if (isMatch == true)

                        {
                            break;
                        }
                        counter++;
                    }
                    //moving eleiments in array to array list
                    ArrayList myAL = new ArrayList(lines);

                    //removing the specific range of elements in the arraylist
                    myAL.RemoveRange(counter - 2, 5);
                    // for (int x = 0; x < myAL. ; x++)
                    // {

                    //rewriting the document with updated values
                    using (TextWriter tw = new StreamWriter("d:\\s.txt"))
                    {
                        tw.WriteLine(myAL);

                    }

                }
                var response = new { Status = "Successful" };

                return response;
            }

            else
            {

                //if the validation is not successful, the below output will be displayed in json format
                var response = new { Status = "Denied", Reason = "Authentication Error" };
             
                return response;

            }
        }



        //All the other auto-generated functions which are not used in this project
        /*

        // GET: api/Unpublish
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Unpublish/5
        public string Get(int id)
        {
            return "value";
        }
        // PUT: api/Unpublish/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Unpublish/5
        public void Delete(int id)
        {
        }
        */
    }
}
