using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizProjectCOM326
{
    public class User
    {
        // Variable declaration
        
        private static int _ID;
        public string _username;
        public string _password;
        public string _email;
        public string _role;


        // Getting and setting values
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }

        }

        public string Role
        {
            get { return _role; }
            set { _role = value; }
        }

        public User()
        {

        }

        // This constructor will be used to create a new user.
        public User(string Username, string Password, string Email)
        {
            this.Username = Username;
            this.Password = Password;
            this.Email = Email;
        }
    }
}
