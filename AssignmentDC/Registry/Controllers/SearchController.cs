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
    public class SearchController : ApiController
    {
        //This rest service searches an input service description in a local text file and returns the service information.
        //Return the appropriate json


        ServerInterface foob;
        // POST: api/Search
        public List<Object> Post([FromBody] SearchModel value)
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
                if (!File.Exists("d:\\status.txt"))
                {
                    //if the file doesn't exist, it return json as  "File doesn't exist"
                    String error = "File doesnt' exist";
                    output.Add(error);
                    return output;
                }

                using (StreamReader sr = File.OpenText("d:\\status.txt"))
                {
                    // read all the lines in the status.txt and save it in the array called lines[]
                    string[] lines = File.ReadAllLines("d:\\status.txt");
                    bool isMatch = false;
                    for (int x = 0; x < lines.Length - 1; x++)
                    {
                        //Checks the keyword with the file
                        isMatch = lines[x].Contains(value.keyword);
                        if (isMatch == true)

                        {
                            //If the keyword exist, it returns the appropriate output in JSON.
                            //That is, it adds the line to object "Output" and returns it throug final return statement

                            var result = new { Name = lines[x], Description = lines[x + 1], Api_endpoint = lines[x + 2], number_of_operands = lines[x + 3], operand_type = lines[x + 4] };
                            //return Json(result, JsonRequestBehavior.AllowGet);
                            output.Add(result);

                            x = x + 4;
                            isMatch = false;
                        }

                    }
                }
                return output;
            }
            else
            {
                
                //if the validation is not successful, the below output will be displayed in json format
                var response = new { Status = "Denied", Reason = "Authentication Error" };
                output.Add(response);
                return output;
                
            }
           
        }
        
        //All the other auto-generated functions which are not used in this project

        /*
         *   // GET: api/Search
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Search/5
        public string Get(int id)
        {
            return "value";
        }
        // PUT: api/Search/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Search/5
        public void Delete(int id)
        {
        }
        */
    }
}
