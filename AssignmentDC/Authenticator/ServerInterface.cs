using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Authenticator
{

    //This is the server interface which shows/displays the available functions
    //Contracts are useful for building WCF service applications.
    [ServiceContract]
    public interface ServerInterface
    {
        [OperationContract]
        String Register(String name, String Password);

        [OperationContract]
        int Login(String name, String Password);

        [OperationContract]
        String validate(int token);
    }
}
