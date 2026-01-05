// Done by Ryan Miller - B00986294 : COM326, QUIZ PROJECT

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
        protected int _ID;
        protected string _username;
        protected string _password;
        protected string _email;
        protected string _role;

        // Getting/setting variables
        public int ID
        {
            get { return _ID; }
            protected set { _ID = value; }
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

        // Default/blank constructor
        public User()
        {
        }

        // Constructor used to give template to both user types (admin/user)
        public User(int ID, string Username, string Password, string Email, string Role)
        {
            this.ID = ID;
            this.Username = Username;
            this.Password = Password;
            this.Email = Email;
            this.Role = Role;
        }
    }
}
