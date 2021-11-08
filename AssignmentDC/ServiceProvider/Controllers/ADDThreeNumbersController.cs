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
    public class ADDThreeNumbersController : ApiController
    {
       

        ServerInterface foob;
        // POST: api/ADDThreeNumbers
        public Object Post([FromBody] ADDThreeNumbersModel value)
        {
            //the below set of code is used to call the validate function of the server interface.
            //A channel is created and interface is accessd through it..........................
            ChannelFactory<ServerInterface> foobFactory;

            //creates a client stub
            NetTcpBinding tcp = new NetTcpBinding();

            //Set the URL and create the connection!string
            var URL = "net.tcp://localhost:10108/Service1 ";
            foobFactory = new ChannelFactory<ServerInterface>(tcp, URL);
            foob = foobFactory.CreateChannel();
            //.......................................................................................

            //The result of the validate function is stored in a string
            String result = foob.validate(value.id);
            //var response;

            //if the token validation is successful, the values will be added
            if (result.Equals("Validated"))
            {
                int sum = value.num1 + value.num2+value.num3;
                var response = new { total = sum };
                return response;
            }
            else
            {
                //if the token validation is not successful, the below output will be displayed as json
                var response = new { Status = "Denied", Reason = "Authentication Error" };
                return response;
            }
        }
        

        //All the other auto generated methods which are not used

        /*
       // GET: api/ADDThreeNumbers
       public IEnumerable<string> Get()
       {
           return new string[] { "value1", "value2" };
       }

       // GET: api/ADDThreeNumbers/5
       public string Get(int id)
       {
           return "value";
       }


       // PUT: api/ADDThreeNumbers/5
       public void Put(int id, [FromBody] string value)
       {
       }

       // DELETE: api/ADDThreeNumbers/5
       public void Delete(int id)
       {
       }
       */
        //............................................................................

    }
}
