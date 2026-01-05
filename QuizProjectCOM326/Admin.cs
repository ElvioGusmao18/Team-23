// Done by Ryan Miller - B00986294 - COM326, QUIZ PROJECT

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizProjectCOM326
{
    public class Admin : User
    {
        public DateTime _loginDate
        {
            get; set;
        }

        // Default constructor
        
        public Admin()
        {

        }

        // This constructor helps give the extra "date/time" feature required.

        public Admin(int ID, string Username, string Password, string Email)
        {
            _ID = ID;
            _username = Username;
            _password = Password;
            _email = Email;
            Role = "ADMIN";

            _loginDate = DateTime.Now;

        }
    }

}
