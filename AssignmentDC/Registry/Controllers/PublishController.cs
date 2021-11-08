using Authenticator;
using Registry.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.ServiceModel;
using System.Web.Http;

namespace Registry.Controllers
{
    //NOTE: WHEN PUBLISHING NEW SERVICES IT IS HIGHLY REQUESTED TO SET THE NAME OF THE FUNCTIONS AS " "AddTwoNumbers" , "AddThreeNumbers",
    //"MultiplyTwoNumbers" , "MultiplyThreeNumbers" , "IsPrimeNumber", "GeneratePrimeNumbersinRange" , "GeneratePrimeNumberstoValue" 
    //The reason for such a request is in the codes, .Content() is used for string comparison. .Content() is case sensitive
    //AS A RESULT IT IS REQUESTED TO PUBLISH NEEW SERVICES IN THE ABOVE FORMAT
    public class PublishController : ApiController
    {

        //This rest service saves the service description in a local text file.
        //If successful it returns the status accordingly in JSON.This service expects the input in a JSON format
        //POST method is used to save the details in txt file

        ServerInterface foob;
        // POST: api/Publish
        public Object Post([FromBody]PublishModel value)
        {
            String result = "UnSuccessful";

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
                //if file doesn't exist, it creates a new file and saves the details in it.
                if (!File.Exists("d:\\status.txt"))
                {
                    using (TextWriter tw = new StreamWriter("d:\\status.txt"))
                    {
                        tw.WriteLine(value.Name);
                        tw.WriteLine(value.Description);
                        tw.WriteLine(value.Api_endpoint);
                        tw.WriteLine(value.number_of_operands);
                        tw.WriteLine(value.operand_type);
                        result = "Successful";
                    }
                }
                else
                {
                    //If file already exists, it appends the new data to the existing file(starus.txt)
                    using (StreamWriter tw = File.AppendText("d:\\status.txt"))
                    {
                        tw.WriteLine(value.Name);
                        tw.WriteLine(value.Description);
                        tw.WriteLine(value.Api_endpoint);
                        tw.WriteLine(value.number_of_operands);
                        tw.WriteLine(value.operand_type);
                        result = "Successful";
                    }
                }

                //return the appropriate json result.
                var response = new { Output = result };
                return response;
            }

            else
            {
                //if the validation is not successful, the below output will be displayed in json format
                var response = new { Status = "Denied", Reason = "Authentication Error" };
                return response;
            }
        }


        //These are the other auto-generated functions which are not used for this project
        /*

        // GET: api/Publish
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Publish/5
        public string Get(int id)
        {
            return "value";
        }

        // PUT: api/Publish/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Publish/5
        public void Delete(int id)
        {
        }
        */
    }
}
