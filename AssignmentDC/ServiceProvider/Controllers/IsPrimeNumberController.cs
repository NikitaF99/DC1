using Authenticator;
using ServiceProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.ServiceModel;
using System.Web.Http;

namespace ServiceProvider.Controllers
{
    public class IsPrimeNumberController : ApiController
    {

        ServerInterface foob;

        // POST: api/IsPrimeNumber
        public Object Post([FromBody] IsPrimeNumberModel value)
        {
            ////the below set of code is used to call the validate function of the server interface.
            ChannelFactory<ServerInterface> foobFactory;

            //creates a client stub
            NetTcpBinding tcp = new NetTcpBinding();

            //Set the URL and create the connection!string
            var URL = "net.tcp://localhost:10108/Service1 ";
            foobFactory = new ChannelFactory<ServerInterface>(tcp, URL);
            foob = foobFactory.CreateChannel();
            //..........................................................

            //The result of validation is stored in astring called "result"
            String result = foob.validate(value.id);
            //var response;
            if (result.Equals("Validated"))
            {
                //if the token validation is successful, the output will be displayed
                int count = 0;
                Boolean prime = false;

                 for (int j = 2; j < value.num; j++)
                 {
                     if (value.num % j == 0)
                      {
                        count = count + 1;
                     }
                 }

                 //Checks whether it is a prime number or not
                if (count == 0 && value.num != 1)
                 {
                      prime = true;
                  }
                //display the result in json format
                var response = new { Output = prime };
                 return response;
            }
            else
            {
                //if validation is not successful
                var response = new { Status = "Denied", Reason = "Authentication Error" };
                return response;
            }
        }

        //the below set of codes are auto generated and is not used in the project
        /*
        // GET: api/IsPrimeNumber
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/IsPrimeNumber/5
        public string Get(int id)
        {
            return "value";
        }
        // PUT: api/IsPrimeNumber/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/IsPrimeNumber/5
        public void Delete(int id)
        {
        }
        */
    }
}
