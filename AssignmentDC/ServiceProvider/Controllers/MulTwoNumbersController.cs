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
    public class MulTwoNumbersController : ApiController
    {
        // GET: api/MulTwoNumbers
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/MulTwoNumbers/5
        public string Get(int id)
        {
            return "value";
        }
        ServerInterface foob;
        // POST: api/MulTwoNumbers
        public Object Post([FromBody]MulTwoNumbersModel value)
        {
            ////the below set of code is used to call the validate function of the server interface.
            ChannelFactory<ServerInterface> foobFactory;

            //creates a client stub
            NetTcpBinding tcp = new NetTcpBinding();

            //Set the URL and create the connection!string
            var URL = "net.tcp://localhost:10108/Service1 ";
            foobFactory = new ChannelFactory<ServerInterface>(tcp, URL);
            foob = foobFactory.CreateChannel();
            //............................................................


            //The result of validation is stored in astring called "result"

            String result = foob.validate(value.id);
            //var response;
            if (result.Equals("Validated"))
            {
                //if the token validation is successful, the output will be displayed
                int sum = value.num1 * value.num2;
                var response = new { Answer = sum };
                return response;
            }
            else
            {
                //if the token validation is not successful, the below output will be displayed
                var response = new { Status = "Denied", Reason = "Authentication Error" };
                return response;
            }
            
        }

        // PUT: api/MulTwoNumbers/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MulTwoNumbers/5
        public void Delete(int id)
        {
        }
    }
}
