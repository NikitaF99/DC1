using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

//NOTE :THE TEXT FILES CREATED, WILL BE SAVED IN THE D: DRIVE

//All the fucntions declared in the server interface,  are implemented in this class
namespace Authenticator
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    internal class DataServer : ServerInterface
    {

        //This is the Login function, which takes inputs as username and password, and if they are correct, it will return a token, and will save it in token.txt.
        public int Login(string name, string Password)
        {
            String userpath = "d:\\bar.txt"; //file which stores username and password
            String tokenPath = "d:\\token.txt";//file which stores token

            int token = 0;
            if (!File.Exists(userpath))
            {
              //if the bar.txt(file with username and passwords) doen't exist, it will not create a token, and will return 0.
                return 0;
            }
            using (StreamReader sr = File.OpenText(userpath))
            {

                //reads all the lines in the txt file (bar.txt)
                string[] lines = File.ReadAllLines(userpath);
                bool isMatch = false;
                for (int x = 0; x < lines.Length; x++)
                {
                    //Checks whther username and password given, matches with the ones stored in the txt file(bar.txt)
                    isMatch = lines[x].Contains(name) && lines[x].Contains(Password);
                    if (isMatch == true)

                    {
                        //IIf there is a match it will create a random number as token between the range 1-100
                        Random rand = new Random();
                        token = rand.Next(1, 100);

                        //if token.txt doen't exist, it will create a new file in same name, and stores the token number in it.
                        if (!File.Exists(tokenPath))
                        {
                            using (TextWriter tw = new StreamWriter(tokenPath))
                            {
                                tw.WriteLine(token);
                                break;
                            }
                        }
                        else
                        {
                            //if the token.txt file exists in the file path, it will add the new token to the existing file
                            using (StreamWriter tw = File.AppendText(tokenPath))
                            {
                                tw.WriteLine(token);
                                break;
                            }
                        }
                               
                    }
                    isMatch = false;


                }


            }
           //returning the token
            return token;
        }

            //All the new username, passwords are stored in bar.txt file........................
         public string Register(string name, string Password)
         {
            String path = "d:\\bar.txt";
            if (!File.Exists(path))
            {
                using (TextWriter tw = new StreamWriter(path))
                {
                    tw.WriteLine(name + " " + Password);
                }
            }

            else
            {
                using (StreamWriter tw = File.AppendText(path))
                {
                    tw.WriteLine(name + " " + Password);
                }
            }


            //If the new username and password are correctly saved in the txt file, it will return "Sucessful"
            //Else, it will return "unscuccessful"

            String result = "UnSuccessful";
            string[] lines = File.ReadAllLines(path);
            bool isMatch = false;
            for (int x = 0; x < lines.Length; x++)
            {
                isMatch = lines[x].Contains(name) && lines[x].Contains(Password);
                if (isMatch == true)
                {
                    result = "Successful";
                }
                
            }

            return result;
        }



        //This function is used to checks whether the token is already generated.
        //If the token could be validated, the return is “validated”, else “not validated

        public string validate(int token)
        {
            String tokenPath = "d:\\token.txt";
            String result = "NotValidated";

            //if there is no file, in the give path, it will return "File doesn't exist"
            if (!File.Exists(tokenPath))
            {
                String error = "File doesnt' exist";

                return error;
            }

            using (StreamReader sr = File.OpenText(tokenPath))
            {
                string domain = token.ToString();

                //Reads all the lines in token.txt and checks whether there is a match, in line by line.
                string[] lines = File.ReadAllLines(tokenPath);
                bool isMatch = false;
                for (int x = 0; x < lines.Length ; x++)
                {
                    isMatch = (lines[x].Contains(domain));
                    if(isMatch == true)

                    {
                        sr.Close();
                        Console.WriteLine("There is a match");
                        
                        result = "Validated";
                        break;


                    }
                }
            }

            return result;
        }
    }
}
