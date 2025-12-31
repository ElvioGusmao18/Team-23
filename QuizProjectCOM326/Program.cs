using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizProjectCOM326
{
    public class Program
    {
        
        public static void Main(String[] args)
        {
            QuizMenu();
        }

        public static void QuizMenu()
        {
            Console.WriteLine("\t\tQUIZ SYSTEM");

            Console.WriteLine("Welcome to the Quiz! \nPlease type '1' to Login, '2' to Register and '0' to exit.");
            int selection = Convert.ToInt32(Console.ReadLine());

            try
            {
                switch (selection)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        LoginPathway();
                        break;
                    case 2:
                        RegisterPathway();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid choice made");
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
            }
        }

        public static void RegisterPathway()
        {
            Console.WriteLine("QUIZ || REGISTER");

            Console.WriteLine("Welcome to the system! Please enter your username");
            string usernameEntered = Console.ReadLine();
            Console.WriteLine("Please enter your email");
            string emailEntered = Console.ReadLine();
            Console.WriteLine("Please enter your password");
            string passwordEntered = Console.ReadLine();
            Console.WriteLine("Please re-enter your password from before:");
            string secondPasswordEntered = Console.ReadLine();

            Console.Clear();

            RegisterUser(usernameEntered, passwordEntered, secondPasswordEntered, emailEntered);
        }

        public static void LoginPathway()
        {
            Console.WriteLine("QUIZ || LOGIN");

            Console.WriteLine("Please login by entering your username");
            string usernameEntered = Console.ReadLine();
            Console.WriteLine("Please enter your password");
            string passwordEntered = Console.ReadLine();

            Console.Clear();

            LoginUser(usernameEntered, passwordEntered);
        }


        private static void RegisterUser(string EnteredUser, string EnteredPass, string EnteredSecondPass, string EnteredEmail)
        {
            string AuthCode = "G23";
            
            Console.WriteLine("What type of user are you registering? Please type 'Admin' or 'Student'.");
            string choice = Console.ReadLine();

            try
            {
                if (choice == "Admin")
                {
                    Console.WriteLine("Enter authorisation code:");
                    string codeCheck = Console.ReadLine();

                    if (codeCheck != AuthCode || string.IsNullOrEmpty(choice))
                    {
                        Console.WriteLine("Wrong/no code provided. Please try again");
                        Console.ReadKey();
                        Console.Clear();
                        QuizMenu();
                        return;
                    }
                    else if (codeCheck == AuthCode)
                    {
                        Console.WriteLine("Correct code provided. Please continue by pressing any key.");
                        Console.ReadKey();
                        Console.Clear();
                    }

                }
                else if (choice == "Student")
                {
                    Console.Clear();
                }
                else
                {
                    Console.Write("Invalid choice, starting over...");
                    Console.ReadKey();
                    Console.Clear();
                    QuizMenu();
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Users.txt");
            FileStream aFile;
            StreamWriter sw;
            try
            {

                if (!string.IsNullOrEmpty(EnteredUser) && !string.IsNullOrEmpty(EnteredPass) && !string.IsNullOrEmpty(EnteredSecondPass) && !string.IsNullOrEmpty(EnteredEmail))
                {
                    if (EnteredPass == EnteredSecondPass)
                    {
                        if (EnteredUser.Length < 12)
                        {
                            int nextID = 1;
                            bool fileExists = File.Exists(filePath);

                            if (fileExists)
                            {
                                nextID = File.ReadAllLines(filePath).Length + 1;
                            }

                            bool UsernameExistsAlready = false;

                            if (fileExists)
                            {
                                using (StreamReader userExist = new StreamReader(filePath))
                                {
                                    string line;
                                    while ((line = userExist.ReadLine()) != null)
                                    {
                                        string user = line.Split('~')[1];

                                        if (user == EnteredUser)
                                        {
                                            UsernameExistsAlready = true;
                                            break;
                                        }
                                    }
                                }
                            }


                            if (UsernameExistsAlready == false)
                            {
                                if (!File.Exists(filePath))
                                {

                                    aFile = new FileStream(filePath, FileMode.Create, FileAccess.Write);

                                }
                                else
                                {
                                    aFile = new FileStream(filePath, FileMode.Append, FileAccess.Write);

                                }

                                sw = new StreamWriter(aFile);
                                
                                switch (choice)
                                {
                                    case "Admin":
                                        sw.WriteLine(nextID + "~" + EnteredUser + "~" + EnteredPass + "~" + EnteredEmail + "~" + "ADMIN");
                                        break;
                                    case "Student":
                                        sw.WriteLine(nextID + "~" + EnteredUser + "~" + EnteredPass + "~" + EnteredEmail + "~" + "STUDENT");
                                        break;
                                }


                                sw.Close();
                                aFile.Close();

                                Console.WriteLine("New user has been added successfully", "Successful");

                            }
                            else
                            {
                                Console.WriteLine("Username already exists in system.", "Username error");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Username cannot be longer than 12 characters.", "Username too long");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Passwords entered are not the same", "Re-entry required.");
                    }
                }
                else
                {
                    Console.WriteLine("All fields must not be empty", "Missing data");

                }
            }


            catch (Exception ex)
            {
                Console.WriteLine("User failed to add", "Error occured");

            }

            Console.ReadKey();
            Console.Clear();
            QuizMenu();


        }        
      
        private static void LoginUser(string Username, string Password)
        {
            string pathForFile = Path.Combine(Directory.GetCurrentDirectory(), "Users.txt");

            if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
            {
                if (File.Exists(pathForFile))
                {
                    string[] users = File.ReadLines(pathForFile).ToArray();
                    bool studentFound = false;
                    bool adminFound = false;
                    string emailFound = "";
                    int IDFound = 0;

                    for (int i = 0; i < users.Length; i++)
                    {
                        string[] userDetails = users[i].Split('~');

                        IDFound = int.Parse(userDetails[0]);
                        emailFound = userDetails[3];

                        if (Username == userDetails[1] && Password == userDetails[2] && userDetails[4] == "ADMIN")
                        {
                            adminFound = true;
                            break;
                        }
                        else if (Username == userDetails[1] && Password == userDetails[2] && userDetails[4] == "STUDENT")
                        {
                            studentFound = true;
                            break;
                        }
                    }

                    // Disclosure: CHATGPT helped with lines 252-261

                    if (studentFound)
                    {                        
                        User loggedInStudent = new User(IDFound, Username, Password, emailFound, "STUDENT");
                        Console.WriteLine($"Welcome student {loggedInStudent.Username}!");
                    }
                    else if (adminFound)
                    {
                        User loggedInAdmin = new User(IDFound, Username, Password, emailFound, "ADMIN");
                        Console.WriteLine($"Welcome admin {loggedInAdmin.Username}!");
                    }

                    else
                    {
                        Console.WriteLine("User is not valid \n Please try again", "User not found");
                    }



                }
                else
                {
                    Console.WriteLine("No users have been registered", "No users found");
                }
            }

            else
            {
                Console.WriteLine("Username and password must not be empty", "Username or password missing");
            }

        }

    }
}
