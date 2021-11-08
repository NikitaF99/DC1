using Authenticator;
using ServiceProvider.Controllers;
using ServiceProvider.Models;
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

namespace Client
{
    /// <summary>
    /// Interaction logic for SpecificServices.xaml
    /// </summary>
    public partial class SpecificServices : Page
    {
        private ServerInterface foob;
        String num1;
        String num2;
        int id;
        //To create dynamic textboxes
        TextBox txtb;
        TextBox txt2;
        TextBox txt3;
        public SpecificServices(string key, int num, int token)
        {
            InitializeComponent();
            //The token value passed from the previous page is saved here
            id = token;
           // test.Content = key + num;
            ChannelFactory<ServerInterface> foobFactory;

            //creates a client stub
            NetTcpBinding tcp = new NetTcpBinding();

            //Set the URL and create the connection!string
            var URL = "net.tcp://localhost:10108/Service1 ";
            foobFactory = new ChannelFactory<ServerInterface>(tcp, URL);
            foob = foobFactory.CreateChannel();

            //Based on the values (key and num) passed from the previous page, dynamic textboxes and buttons are created
            //And the respective function is called for each button

            if (key.Equals("ADD") && num == 2)
            {
                //FOR ADDING TWO NUMBERS
               txtb = new TextBox();
                txtb.Height = 30;
               txtb.Width = 100;
               txtb.Text = "";
                //add textbox in the above height and width
               this.stackpanel.Children.Add(txtb);
              
               txt2 = new TextBox();
                txt2.Height = 30;
                txt2.Margin = new Thickness(0, 40, 0, 0);
                txt2.Width = 100;

                txt2.Text = "";
                //add textbox2 in the above hight and width
                this.stackpanel.Children.Add(txt2);
                


                Button btn = new Button();
                btn.Height = 80;
                btn.Width = 150;
                btn.Margin = new Thickness(0, 50, 0, 0);
                btn.Content = "Click ME";
                //Onbutton click the below function will be called
                btn.Click += AddTwoButton_Click;
                //add dynamic button based on the above features
                this.stackpanel.Children.Add(btn);

            }


            if (key.Equals("ADD") && num == 3)
            {
                //FOR ADDING THREE NUMBERS
                txtb = new TextBox();
                txtb.Height = 30;
               txtb.Width = 100;
                txtb.Text = "";
                this.stackpanel.Children.Add(txtb);

                txt2 = new TextBox();
                txt2.Height = 30;
                txt2.Margin = new Thickness(0, 40, 0, 0);
                txt2.Width = 100;
                txt2.Text = "";
                this.stackpanel.Children.Add(txt2);

                txt3 = new TextBox();
                txt3.Height = 30;
                txt3.Margin = new Thickness(0, 40, 0, 0);
                txt3.Width = 100;
                txt3.Text = "";
                this.stackpanel.Children.Add(txt3);


                Button btn = new Button();
                btn.Height = 80;
                btn.Width = 120;
                btn.Margin = new Thickness(0, 50, 0, 0);
                btn.Content = "Click ME";
                btn.Click += AddThreeButton_Click;
                this.stackpanel.Children.Add(btn);

            }

            if (key.Equals("MUL") && num == 2)
            {
                //FOR MULTIPLYING TWO NUMBERS
                txtb = new TextBox();
                txtb.Height = 30;
                txtb.Width = 100;
                txtb.Text = "";
                this.stackpanel.Children.Add(txtb);

                txt2 = new TextBox();
                txt2.Height = 30;
                txt2.Margin = new Thickness(0, 40, 0, 0);
                txt2.Width = 100;

                txt2.Text = "";
                this.stackpanel.Children.Add(txt2);



                Button btn = new Button();
                btn.Height = 80;
                btn.Width = 150;
                btn.Margin = new Thickness(0, 50, 0, 0);
                btn.Content = "Click ME";
                btn.Click += MulTwoButton_Click;
                this.stackpanel.Children.Add(btn);
            }

            if (key.Equals("MUL") && num == 3)
            {
                //FOR MULTIPLYING 3 NUMBERS
                txtb = new TextBox();
                txtb.Height = 30;
                txtb.Width = 100;
                txtb.Text = "";
                this.stackpanel.Children.Add(txtb);

                txt2 = new TextBox();
                txt2.Height = 30;
                txt2.Margin = new Thickness(0, 40, 0, 0);
                txt2.Width = 100;

                txt2.Text = "";
                this.stackpanel.Children.Add(txt2);

                txt3 = new TextBox();
                txt3.Height = 30;
                txt3.Margin = new Thickness(0, 40, 0, 0);
                txt3.Width = 100;
                txt3.Text = "";
                this.stackpanel.Children.Add(txt3);


                Button btn = new Button();
                btn.Height = 80;
                btn.Width = 150;
                btn.Margin = new Thickness(0, 50, 0, 0);
                btn.Content = "Click ME";
                btn.Click += MulThreeButton_Click;
                this.stackpanel.Children.Add(btn);
            }

            if (key.Equals("isprime") && num == 1)
            {
                //TO FIND WHTHER A GIVEN NUMBER IS A PRIME NUMBER
                txtb = new TextBox();
                txtb.Height = 30;
                txtb.Width = 100;
                txtb.Text = "";
                this.stackpanel.Children.Add(txtb);

              


                Button btn = new Button();
                btn.Height = 80;
                btn.Width = 150;
                btn.Margin = new Thickness(0, 50, 0, 0);
                btn.Content = "Click ME";
                btn.Click += isPrimeButton_Click;
                this.stackpanel.Children.Add(btn);
            }

            if (key.Equals("primeRange") && num == 2)
            {
                //TO DISPLAY PRIME NUMBERS IN A GIVEN RANGE
                txtb = new TextBox();
                txtb.Height = 30;
                txtb.Width = 100;
                txtb.Text = "";
                this.stackpanel.Children.Add(txtb);

                txt2 = new TextBox();
                txt2.Height = 30;
                txt2.Margin = new Thickness(0, 40, 0, 0);
                txt2.Width = 100;

                txt2.Text = "";
                this.stackpanel.Children.Add(txt2);



                Button btn = new Button();
                btn.Height = 80;
                btn.Width = 150;
                btn.Margin = new Thickness(0, 50, 0, 0);
                btn.Content = "Click ME";
                btn.Click += primeRange_Click;
                this.stackpanel.Children.Add(btn);
            }

            if (key.Equals("primeValue") && num == 1)
            {
                //TO DISPLAY PRIME NUMBERS UPTO A GIVEN VALUE
                txtb = new TextBox();
                txtb.Height = 30;
                txtb.Width = 100;
                txtb.Text = "";
                this.stackpanel.Children.Add(txtb);




                Button btn = new Button();
                btn.Height = 80;
                btn.Width = 150;
                btn.Margin = new Thickness(0, 50, 0, 0);
                btn.Content = "Click ME";
                //  btn.Background = new SolidColorBrush(Colors.Orange);
                //  btn.Foreground = new SolidColorBrush(Colors.Black);
                btn.Click += PrimeValueButton_Click;
                this.stackpanel.Children.Add(btn);
            }

        }

        

    
        //To call the post function of the IsPrimeNumberController and to access the respective model, objects are created
        IsPrimeNumberController isPrime = new IsPrimeNumberController();
        IsPrimeNumberModel isPrimeModel = new IsPrimeNumberModel();
        private void isPrimeButton_Click(object sender, RoutedEventArgs e)
        {
            //values passed in the textbox is retrieved and stored in the variable of the model class
           isPrimeModel.num = Int32.Parse(txtb.Text);
            //id passed from the previous page is store to the variable of the model class
            isPrimeModel.id = id;
            //the output received by calling the method is stored in the label
            test.Content = isPrime.Post(isPrimeModel);
        }


        //To call the post function of the MulThreeNumbersController and to access the respective model, objects are created

        MulThreeNumbersController mulThree = new MulThreeNumbersController();
        MulThreeNumbersModel mulThreeModel = new MulThreeNumbersModel();
        private void MulThreeButton_Click(object sender, RoutedEventArgs e)
        {
            mulThreeModel.num1 = Int32.Parse(txtb.Text);
            mulThreeModel.num2 = Int32.Parse(txt2.Text);
            mulThreeModel.num3 = Int32.Parse(txt3.Text);
            mulThreeModel.id = id;
            test.Content = mulThree.Post(mulThreeModel);
        }

        //To call the post function of the MulTwoNumbersController and to access the respective model, objects are created

        MulTwoNumbersController mulTwo = new MulTwoNumbersController();
        MulTwoNumbersModel mulTwoModel = new MulTwoNumbersModel();

        private void MulTwoButton_Click(object sender, RoutedEventArgs e)
        {
            mulTwoModel.num1 = Int32.Parse(txtb.Text);
            mulTwoModel.num2 = Int32.Parse(txt2.Text);
            mulTwoModel.id = id;
            test.Content = mulTwo.Post(mulTwoModel);
        }


        //To call the post function of the ADDThreeNumbersController and to access the respective model, objects are created

        ADDThreeNumbersController addThree = new ADDThreeNumbersController();
        ADDThreeNumbersModel addThreeModel = new ADDThreeNumbersModel();

        private void AddThreeButton_Click(object sender, RoutedEventArgs e)
        {
            addThreeModel.num1 = Int32.Parse(txtb.Text);
            addThreeModel.num2 = Int32.Parse(txt2.Text);
            addThreeModel.num3 = Int32.Parse(txt3.Text);
            addThreeModel.id = id;
            test.Content = addThree.Post(addThreeModel);
        }

        //To call the post function of the ADDTwoNumbersController and to access the respective model, objects are created


        ADDTwoNumbersController addTwo = new ADDTwoNumbersController();
        ADDTwoNumbersModel addTwoModel = new ADDTwoNumbersModel();

        private void AddTwoButton_Click(object sender, EventArgs e)
        {
            addTwoModel.num1 = Int32.Parse(txtb.Text);
            addTwoModel.num2 = Int32.Parse(txt2.Text);
            addTwoModel.id = id;
            test.Content=addTwo.Post(addTwoModel);
        }

        //NOTE: SINCE THE OUTPUT SHOULD BE DISPLYED IN THE LIST, THE OUTPUT OF THIS FUCNTION WILL NOT BE SHOWN IN THE CLIENT PAGE
        //I TRIED MY BEST IN IDENTIFYING AND IMPLEMENTING THE FUNCTIONS
        //To call the post function of the GeneratePrimeNumberstoValueController and to access the respective model, objects are created
        GeneratePrimeNumberstoValueController value = new GeneratePrimeNumberstoValueController();
        GeneratePrimeNumberstoValueModel valueModel = new GeneratePrimeNumberstoValueModel();

        private void PrimeValueButton_Click(object sender, RoutedEventArgs e)
        {
            //When the respective button is clicked, this functon will be invoked

            //Stores the value from textbox to the variable of the model class
            valueModel.num = Int32.Parse(txtb.Text);
            //Store the id passed from the previous page to the variable of the model class
            valueModel.id = id;
            //call the post function and the result is stored in the label

            
            foreach (Object element in value.Post(valueModel))
            {

                outputList.Items.Add(element);


            }


        }
        //The below codes are created in the same method as mentioned above

        //To call the post function of the GeneratePrimeNumbersinRangeController and to access the respective model, objects are created
        GeneratePrimeNumbersinRangeController range = new GeneratePrimeNumbersinRangeController();
        GeneratePrimeNumbersinRangeModel rangeModel = new GeneratePrimeNumbersinRangeModel();
        private void primeRange_Click(object sender, RoutedEventArgs e)
        {
            rangeModel.start = Int32.Parse(txtb.Text);
            rangeModel.end = Int32.Parse(txt2.Text);
            rangeModel.id = id;
            //store the output in the label
            foreach (Object element in range.Post(rangeModel))
            {
                
                outputList.Items.Add(element);
             

            }

        }

    }
}
