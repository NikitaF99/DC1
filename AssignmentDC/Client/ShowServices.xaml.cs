using Authenticator;
using Registry.Controllers;
using Registry.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Net.Http;

namespace Client
{
    /// <summary>
    /// Interaction logic for ShowServices.xaml
    /// </summary>
    public partial class ShowServices : Page
    {
        //NOTE: IN THE TEXT FILE, THE SERVICE NAMES ARE SAVED AS "AddTwoNumbers" , "AddThreeNumbers", "MultiplyTwoNumbers" , "MultiplyThreeNumbers" , 
        //"IsPrimeNumber", "GeneratePrimeNumbersinRange" , "GeneratePrimeNumberstoValue" , through the publish method().
        //Therefore string validation is done according to these name
        // .Contain() is used for string comaprison. Since it is case sensitive, when publishing new services, it is requested to use  the same string as
        //as give above.

        private ServerInterface foob;
        int token = 0;
        public ShowServices(int num)
        {
            InitializeComponent();
            //The token value passed from login page is saved in this variable
            token = num;
           
            ChannelFactory<ServerInterface> foobFactory;

            //creates a client stub
            NetTcpBinding tcp = new NetTcpBinding();

            //Set the URL and create the connection!string
            var URL = "net.tcp://localhost:10108/Service1 ";
            foobFactory = new ChannelFactory<ServerInterface>(tcp, URL);
            foob = foobFactory.CreateChannel();
        }
       
        String key;
        int number;
        //To access functions and variables of SearchController and SearchModel
        SearchModel search = new SearchModel();
        SearchController sc = new SearchController();
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //the keyword given as user input is saved to the variable of the SearchModel
            search.keyword = keyword.Text;
            search.id = token;

           
         
            //The post method of search controller class is called, and the result is displayed in a list
            foreach (Object element in sc.Post(search))
            {
                serviceList.Items.Add(element);
                String value = element.ToString();
              

                }
            }

        //To access the get() method of the AllServicesControlleer class in order to display all the services available
        AllServicesModel all = new AllServicesModel();
        AllServicesController allC = new AllServicesController();
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
          

            foreach (Object element in allC.Get()) 
            {
                serviceList.Items.Add(element);
                //String value = element.ToString();
                
            }
        }

        //The below function is written to specify the tasks to be occured when a given item is selected
        private void myListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
         
            //To convert the details of the selected item to string and store it in a variable called value
            String value = serviceList.SelectedItem.ToString();

            //The below codes are used to check the each list item and passes appropriate key and number
            //For Addingtwonumber function
            if (value.Contains("AddTwo") == true)
            {

                key = "ADD";
                number = 2;
                test.Content = value;
            }
            //for addingthreenumber function
            if (value.Contains("AddThree") == true)
            {

                key = "ADD";
                number = 3;
                test.Content = value;
            }
            //for multiplyingtwo number function
            if (value.Contains("MultiplyTwo") == true)
            {

                key = "MUL";
                number = 2;
                test.Content = value;
            }

            //when multiply three number function
            if (value.Contains("MultiplyThree") == true)
            {

                key = "MUL";
                number = 3;
                test.Content = value;
            }

            //For isAPrimeNumber function
            if (value.Contains("IsPrime") == true)
            {

                key = "isprime";
                number = 1;
                test.Content = value;
            }

            //For the function to find prime numbers in a range
            if (value.Contains("inRange") == true)
            {

                key = "primeRange";
                number = 2;
                test.Content = value;
            }
            //for the function to find prime numbers to a given value
            if (value.Contains("toValue") == true)
            {

                key = "primeValue";
                number = 1;
                test.Content = value;
            }
        }
        
        //this function is written to navigate to the next page if a list item is selected
        private void listView_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            //the key , number and the token id are passed to the next page
            nav.Navigate(new SpecificServices(key, number, token));
        }




    }
}
