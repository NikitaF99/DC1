using Authenticator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

//Login page
namespace Client
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        private ServerInterface foob;
        public Login()
        {
            InitializeComponent();

            //To access server interface we are creating channels 
            ChannelFactory<ServerInterface> foobFactory;

            //creates a client stub
            NetTcpBinding tcp = new NetTcpBinding();

            //Set the URL and create the connection!string
            var URL = "net.tcp://localhost:10108/Service1 ";
            foobFactory = new ChannelFactory<ServerInterface>(tcp, URL);
            foob = foobFactory.CreateChannel();
        }
        String user, pass;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Gets username and password from textbox
            user = username.Text;
            pass = password.Text;

            //using the channel created we are able to access the login function
            int num = foob.Login(user, pass);
            if (num != null)
            {
                //Pass the token created through login to the next page which is show services
                NavigationService nav = NavigationService.GetNavigationService(this);
                nav.Navigate(new ShowServices(num));
            }
        }
    }
}
