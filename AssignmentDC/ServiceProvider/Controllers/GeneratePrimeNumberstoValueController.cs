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
    public class GeneratePrimeNumberstoValueController : ApiController
    {
        // GET: api/GeneratePrimeNumberstoValue
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/GeneratePrimeNumberstoValue/5
        public string Get(int id)
        {
            return "value";
        }


        ServerInterface foob;

        // POST: api/GeneratePrimeNumberstoValue
        public List<Object> Post([FromBody] GeneratePrimeNumberstoValueModel value)
        {
            List<Object> primeList = new List<Object>();
            //the below set of code is used to call the validate function of the server interface.
            //A channel is created and interface is accessd through it..........................
            ChannelFactory<ServerInterface> foobFactory;

            //creates a client stub
            NetTcpBinding tcp = new NetTcpBinding();

            //Set the URL and create the connection!string
            var URL = "net.tcp://localhost:10108/Service1 ";
            foobFactory = new ChannelFactory<ServerInterface>(tcp, URL);
            foob = foobFactory.CreateChannel();
            //....................................................................

            //The result of validation is stored in astring called "result"
            String result = foob.validate(value.id);
            //var response;
            if (result.Equals("Validated"))
            {
                //if the token validation is successful, the values will be displayed
                
                int count;
                String prime = " ";

                //to display prime numbers from 1 to the given value
                for (int i = 1; i <= value.num; i++)
                {
                    count = 0;
                    //to check whether it is a prime number or not
                    for (int j = 2; j < i; j++)
                    {
                        if (i % j == 0)
                        {
                            count = count + 1;
                        }
                    }

                    if (count == 0 && i != 1)
                    {
                        //if it is a prime number it is added to the list
                        // prime = i + " ";
                        primeList.Add(i);
                    }

                }
                //the list is displlayed in json output
                return primeList;

            }
            else
            {
                ///if the validation is not successful
                var response = new { Status = "Denied", Reason = "Authentication Error" };
                primeList.Add(response);
                return primeList;
            }
        }

            // PUT: api/GeneratePrimeNumberstoValue/5
            public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GeneratePrimeNumberstoValue/5
        public void Delete(int id)
        {
        }
    }
}
