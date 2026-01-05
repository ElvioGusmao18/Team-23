// Majority of this (750+ lines) done by Ryan Miller - B00986294 -COM326, QUIZ PROJECT

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizProjectCOM326
{
    public class QuizSystem
    {
        
        public static void Main(String[] args)
        {
            QuizMenu();
        }

        
        public static void QuizMenu()
        {
            // Welcome message + main menu instructions for our user.
            // We read the choice made in and use a case/switch to send them to the correct area.
            
            Console.WriteLine("\t\tQUIZ SYSTEM");

            Console.WriteLine("\t\tWelcome to the Quiz! \nPlease type: ");
            Console.WriteLine();
            Console.WriteLine("'1' to Login");
            Console.WriteLine("'2' to Register");
            Console.WriteLine("'3' to Update Details");
            Console.WriteLine("'0' to Exit");


            try
            {            
               int selection = Convert.ToInt32(Console.ReadLine());
                
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
                    case 3:
                        UpdateDetails();
                        break;
                    default:
                        Console.WriteLine("Invalid number selected");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid choice made, please type a valid number");
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
            }
        }

        
        // This method is where we capture the necessary info from our user to register them with the system, be that as an admin or a student.
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

            if (passwordEntered != secondPasswordEntered)
            {
                Console.WriteLine("Passwords didn't match, please try again!");
                Console.ReadKey();
                Console.Clear();
                RegisterPathway();
            }

            Console.Clear();

            RegisterUser(usernameEntered, passwordEntered, secondPasswordEntered, emailEntered);
        }

        // This method is where we capture the necessary info from our user to log them in with the system, be that as an admin or a student.
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

        //RegisterUser method
       // Detailed commenting done on the Login method in lieu of repeating myself. Unique coding practices will be commented.
        private static void RegisterUser(string EnteredUser, string EnteredPass, string EnteredSecondPass, string EnteredEmail)
        {
            string AuthCode = "G23";
            
            Console.WriteLine("What type of user are you registering? Please type 'Admin' or 'Student'.");
            string choice = Console.ReadLine();

            try
            {
                // This is some basic authentication to ensure that only specific people can sign up as an Admin, provided they have the code
                
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
               // Checks done: Any empty fields, both passwords entered are the same, username less than 12 characters and if said username exists already.
                
                if (!string.IsNullOrEmpty(EnteredUser) && !string.IsNullOrEmpty(EnteredPass) && !string.IsNullOrEmpty(EnteredSecondPass) && !string.IsNullOrEmpty(EnteredEmail))
                {
                    if (EnteredPass == EnteredSecondPass)
                    {
                        if (EnteredUser.Length < 12)
                        {
                            // Very simple ID system. Just increment by one more than the length of the file (think 3 users entered, next ID will be 4, default is 1 assuming 0 users)
                            
                            int nextID = 1;
                            bool fileExists = File.Exists(filePath);

                            if (fileExists)
                            {
                                nextID = File.ReadAllLines(filePath).Length + 1;
                            }

                            bool UsernameExistsAlready = false;

                            if (fileExists)
                            { 
                                
                                // A general summary of this code is that we, using the StreamReader, read into the file
                                // and take the entered data (username, password), split this data using the tilde '~',
                                // finally checking to see if the user is equal to the entered username.
                                // If so, it's a dupe, so we flag that as an error.

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


                            // Check to see if a username exists already in the file since we can't register the same username twice.
                            
                            if (UsernameExistsAlready == false)
                            {
                                if (!File.Exists(filePath))
                                {
                                    // If the file doesn't exist, create it.

                                    aFile = new FileStream(filePath, FileMode.Create, FileAccess.Write);

                                }
                                else
                                {
                                    // If the file does exist, write to it.
                                    
                                    aFile = new FileStream(filePath, FileMode.Append, FileAccess.Write);

                                }

                                // StreamWriter actually allows us to write text to the file. Below is how we'll store our data in the Users.txt file in plaintext.
                                
                                sw = new StreamWriter(aFile);
                                
                                switch (choice)
                                {
                                    case "Admin":
                                        sw.WriteLine(nextID + "~" + EnteredUser + "~" + EnteredPass + "~" + EnteredEmail + "~" + "ADMIN" + "~" + "n/a");
                                        break;
                                    case "Student":
                                        sw.WriteLine(nextID + "~" + EnteredUser + "~" + EnteredPass + "~" + EnteredEmail + "~" + "STUDENT" + "~" + "active");
                                        break;
                                }

                                // Close both our streamwriter and our filestream classes. Can't tell you exactly why, but it's good practice.

                                sw.Close();
                                aFile.Close();

                                // Print success message to user (plus their ID so they don't forget it!)

                                Console.WriteLine("New user has been added successfully");
                                Console.WriteLine("Your ID is: " + nextID);
                                Console.WriteLine("Don't forget this!");

                            }
                            else
                            {
                                Console.WriteLine("Username already exists in system.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Username cannot be longer than 12 characters.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Passwords entered are not the same");
                    }
                }
                else
                {
                    Console.WriteLine("All fields must not be empty");

                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("User failed to add");

            }

            Console.ReadKey();
            Console.Clear();
            QuizMenu();


        } 
       
        // LoginUser method:
        // Method helps us login a user by passing their username + password from the LoginGateway method.
        // If successful, the user should be able to log into the system.

        private static void LoginUser(string Username, string Password)
        {
            // Grabs the current file path for where "Users.txt" is (usually in the .bin folder)
            
            string pathForFile = Path.Combine(Directory.GetCurrentDirectory(), "Users.txt");

            // Checks to see if either field has been left null/empty. If so, error message is displayed
            
            if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
            {
                // Check to see if the Users.txt file actually exists or not. If not, error message is shown
                
                if (File.Exists(pathForFile))
                {
                    // Variable declaration. The most important is our users[] array which will be how we store the data read from the Users.txt file.
                    // This is helping us match the username/password to a current account.
                    
                    string[] users = File.ReadLines(pathForFile).ToArray();
                    bool studentFound = false;
                    bool adminFound = false;
                    string emailFound = "";
                    string statusFound = "";
                    int IDFound = 0;

                    // For each slot in our users array, read in data from our file...
                    
                    for (int i = 0; i < users.Length; i++)
                    {
                        
                        // ...and split each array value with a tilde '~'. This helps us pick out the data we need.
                        
                        string[] userDetails = users[i].Split('~');

                        // This is how we determine if a user is an admin or student. The 5th array slot (userDetails[4]) tells us the role of the user, and we can branch them off accordingly.
                        // (also checks to see if their username and password provided are correct, of course)

                        if (Username == userDetails[1] && Password == userDetails[2] && userDetails[4] == "ADMIN")
                        {
                            IDFound = Convert.ToInt32(userDetails[0]);
                            emailFound = userDetails[3];
                            adminFound = true;
                            break;
                        }
                        else if (Username == userDetails[1] && Password == userDetails[2] && userDetails[4] == "STUDENT")
                        {
                            IDFound = Convert.ToInt32(userDetails[0]);
                            emailFound = userDetails[3];
                            statusFound = userDetails[5];
                            studentFound = true;
                            break;
                        }
                    }

                    // Allows us to create instances of our Admin and Student class for the respective Admin and Student.

                    if (studentFound)
                    {
                        Student loggedInStudent = new Student(IDFound, Username, Password, emailFound, statusFound);

                        if (!loggedInStudent.isActive())
                        {
                            Console.WriteLine("Your account is inactive, please let an administrator know");
                            Console.ReadKey();
                            Console.Clear();
                            QuizMenu();
                            return;
                        }

                        Console.WriteLine("Welcome student!");
                        Console.ReadKey();

                        Console.Clear();
                        StudentMenu(loggedInStudent);
                        return;
                    }
                    else if (adminFound)
                    {
                        Admin loggedInAdmin = new Admin(IDFound, Username, Password, emailFound);
                        Console.WriteLine("Welcome admin! Press any key to continue");
                        Console.ReadKey();
                        
                        Console.Clear();
                        AdminMenu(loggedInAdmin);

                        return;
                    }
                    else
                    {
                        Console.WriteLine("User is not valid \n Please try again");
                        Console.ReadKey();
                        Console.Clear();
                        QuizMenu();
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("No users have been registered");
                }
            }

            else
            {
                Console.WriteLine("Username and password must not be empty");
            }

        }


        private static void UpdateDetails()
        {
            string pathForFile = Path.Combine(Directory.GetCurrentDirectory(), "Users.txt");
            string[] users = File.ReadLines(pathForFile).ToArray();

            try
            {
                Console.WriteLine("Please enter your ID that corresponds with your account:");
                int IDChosen = Convert.ToInt32(Console.ReadLine());

                bool foundYet = false;

                for (int i = 0; i < users.Length; i++)
                {
                    string[] userDetails = users[i].Split('~');

                    int IDFound = Convert.ToInt32(userDetails[0]);

                    if (IDChosen == IDFound)
                    {
                        foundYet = true;
                        
                        // Present user with a menu to choose what details they'd like to edit.
                        
                        Console.WriteLine("ID Found. Please select what you wish to update, 1 for Email and 2 for Password: ");

                        try
                        {
                            int choiceMade = Convert.ToInt32(Console.ReadLine());

                            switch (choiceMade)
                            {
                                case 1:
                                    UpdateEmail(IDFound);
                                    Console.Clear();
                                    break;
                                case 2:
                                    UpdatePassword(IDFound);
                                    Console.Clear();
                                    break;
                                default:
                                    Console.WriteLine("Invalid choice made");
                                    break;
                            }
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Invalid input");
                            Console.ReadKey();
                            Console.Clear();

                        }
                    }
                }

                if (!foundYet)
                {
                    Console.WriteLine("ID not found");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static void UpdatePassword(int IDToUpdate)
        {
            string pathForFile = Path.Combine(Directory.GetCurrentDirectory(), "Users.txt");
            string[] users = File.ReadAllLines(pathForFile);

            int userIndex = -1;
            string[] userDetails = null;

            for (int i = 0; i < users.Length; i++)
            {
                string[] ids = users[i].Split('~');

                if (Convert.ToInt32(ids[0]) == IDToUpdate)
                {
                    userIndex = i;
                    userDetails = ids;
                    break;
                }
            }
            
            // If after going through the file we don't find the ID, (t/f userIndex never gets changed from -1), we can print this error to the user

            if (userIndex == -1)
            {
                Console.WriteLine("ID was not found.");
                return;
            }

            // I've given the user 3 tries at remembering their password. If I were to advance further than this:
            // I could make a flag on their account (userDetails[7] for eg) that wouldn't allow them to log in until an admin changed it.
            
            int attempts = 3;

            while (attempts > 0)
            {
                Console.WriteLine("Please provide your current password. You have " + attempts + " attempts left.");
                string passGuess = Console.ReadLine();

                if (passGuess == userDetails[2])
                {
                    Console.WriteLine("Correct password provided. Enter new password:");
                    string newPass1 = Console.ReadLine();

                    Console.WriteLine("Please retype the password you just entered:");
                    string newPass2 = Console.ReadLine();

                    if (newPass1 == newPass2)
                    {
                        userDetails[2] = newPass1;
                        users[userIndex] = string.Join("~", userDetails);

                        File.WriteAllLines(pathForFile, users);
                        Console.WriteLine("Password updated successfully.");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Passwords did not match.");
                    }
                }
                else
                {
                    attempts--;
                }
            }
            // Really basic authentication to try and stop repeated attempts at guessing passwords.

            Console.WriteLine("3 attempts tried. Exiting...");
            Console.ReadKey();
            Console.Clear();
            QuizMenu();
        }

        // The UpdateEmail method is essentially a rehash of the UpdatePassword method, without the retries + updated userDetails array position (2 -> 3) to reflect where the email is stored.

        private static void UpdateEmail(int IDToUpdate)
        {
            string pathForFile = Path.Combine(Directory.GetCurrentDirectory(), "Users.txt");
            string[] users = File.ReadAllLines(pathForFile);

            int userIndex = -1;
            string[] userDetails = null;

            for (int i = 0; i < users.Length; i++)
            {
                string[] ids = users[i].Split('~');

                if (Convert.ToInt32(ids[0]) == IDToUpdate)
                {
                    userIndex = i;
                    userDetails = ids;
                    break;
                }
            }

            if (userIndex == -1)
            {
                Console.WriteLine("ID was not found.");
                return;
            }

            Console.WriteLine("Please provide your current email");
            string emailAttempt = Console.ReadLine();

            if (emailAttempt == userDetails[3])
            {
                Console.WriteLine("Correct email provided. Enter new email:");
                string newEmail1 = Console.ReadLine();

                Console.WriteLine("Please retype the email you just entered:");
                string newEmail2 = Console.ReadLine();

                if (newEmail1 == newEmail2)
                {
                    userDetails[3] = newEmail1;
                    users[userIndex] = string.Join("~", userDetails);

                    File.WriteAllLines(pathForFile, users);
                    Console.WriteLine("Email updated successfully.");
                    return;
                }
                else
                {
                    Console.WriteLine("Emails did not match.");
                }
            }
            else
            {
                Console.WriteLine("Wrong email provided");
                Console.ReadKey();
            }
        }

        private static void StudentMenu(Student loggedInStudent)
        {
            Console.WriteLine("\t\tSTUDENT MENU");
            Console.WriteLine("Welcome");
            Console.WriteLine();
            Console.WriteLine("1 - Play the quiz ");
            Console.WriteLine("0 - Logout");

            try
            {
                int selection = Convert.ToInt32(Console.ReadLine());

                switch (selection)
                {
                    case 1:
                        BeginQuiz(loggedInStudent);
                        Console.Clear();
                        StudentMenu(loggedInStudent);
                        break;
                    case 0:
                        Console.Clear();
                        QuizMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid choice made");
                        Console.ReadKey();
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Invalid input");
                Console.ReadKey();
            }
        }

        #region Admin Things
        private static void AdminMenu(Admin loggedInAdmin)
        {
                Console.WriteLine("\t\tADMIN MENU");
                Console.WriteLine("Welcome");
                Console.WriteLine("Login time: " + loggedInAdmin._loginDate.ToString("dd/MM/yyyy HH:mm:ss")); // ChatGPT helped with this line in particular (see the date formatting), since I didn't know how to display this.
                Console.WriteLine();
                Console.WriteLine("1 - Change Student Status");
                Console.WriteLine("2 - Update User Password");
                Console.WriteLine("0 - Logout");

                try
                {
                    int selection = Convert.ToInt32(Console.ReadLine());

                    switch (selection)
                    {
                        case 1:
                            UpdateStudentStatus();
                            Console.Clear();
                            AdminMenu(loggedInAdmin);
                            break;
                        case 2:
                            Console.WriteLine("Enter the ID of the user: ");
                            int IDChosen = Convert.ToInt32(Console.ReadLine());
                            UpdatePassword(IDChosen);
                            Console.ReadKey();
                            Console.Clear();
                            AdminMenu(loggedInAdmin);
                            break;
                        case 0:
                            Console.Clear();
                            QuizMenu();
                            break;
                        default:
                            Console.WriteLine("Invalid choice made");
                            Console.ReadKey();
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid input");
                    Console.ReadKey();
                }
            }
        

        private static void UpdateStudentStatus()
        {
            string pathForFile = Path.Combine(Directory.GetCurrentDirectory(), "Users.txt");
            string[] users = File.ReadLines(pathForFile).ToArray();

            try
            {
                Console.WriteLine("Please enter the ID of the student:");
                int IDChosen = Convert.ToInt32(Console.ReadLine());

                bool foundYet = false;

                for (int i = 0; i < users.Length; i++)
                {
                    string[] userDetails = users[i].Split('~');

                    int IDFound = Convert.ToInt32(userDetails[0]);

                    if (IDChosen == IDFound)
                    {
                        foundYet = true;

                        if (userDetails[4] != "STUDENT")
                        {
                            Console.WriteLine("That ID doesn't belong to a student.");
                            Console.ReadKey();
                            return;
                        }

                        Console.WriteLine("Current status: " + userDetails[5]);
                        Console.WriteLine("Enter new status (active/inactive):");
                        string newStatus = Console.ReadLine();

                        if (newStatus != "active" && newStatus != "inactive")
                        {
                            Console.WriteLine("Invalid status entered.");
                            Console.ReadKey();
                            return;
                        }

                        userDetails[5] = newStatus;
                        users[i] = string.Join("~", userDetails);

                        File.WriteAllLines(pathForFile, users);

                        Console.WriteLine("Student status updated successfully!");
                        Console.ReadKey();
                        return;
                    }
                }

                if (!foundYet)
                {
                    Console.WriteLine("ID not found.");
                    Console.ReadKey();
                }
            }
            catch
            {
                Console.WriteLine("Invalid input");
                Console.ReadKey();
            }
        }
        #endregion

        // CAN SOMEONE PLEASE LOOK AT THIS AND CHANGE IT HOWEVER YOU FANCY TO INTEGRATE WITH THE QUIZ/QUESTIONS/CATEGORIES? THANKS - RYAN
        // THIS METHOD BELOW IS AI'ED FOR YOUR CONVENIENCE
        //  PLACEHOLDER, PLEASE CHANGE
        private static void BeginQuiz(Student loggedInStudent)
        {
            Console.Clear();
            Console.WriteLine("QUIZ STARTING...");
            Console.WriteLine();

            // TEMP: Replace this later with your real Quiz/Question list
            string question = "Which keyword is used to create an object in C#?";
            string[] options = { "new", "class", "void", "using" };
            int correctIndex = 1; // 1-based

            Console.WriteLine(question);
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine((i + 1) + " - " + options[i]);
            }

            Console.WriteLine();
            Console.WriteLine("Enter your answer (1-4):");
            int answer = Convert.ToInt32(Console.ReadLine());

            if (answer == correctIndex)
            {
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine("Incorrect. Correct answer was: " + options[correctIndex - 1]);
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to return to the Student Menu.");
            Console.ReadKey();
        }

    }



}
