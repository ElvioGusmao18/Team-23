using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizProjectCOM326
{
    internal class Student : User
    {
        private string status;

        // Default constructor
        public Student() : base()
        {
            status = "active";
            Role = "Student";
        }

        // Custom constructor
        public Student(int ID, string Username, string Password, string Email, string Status)
            : base(ID, Username, Password, Email, "Student")
        {
            if (Status == "active" || Status == "inactive")
            {
                status = Status;
            }
            else
            {
                status = "active";
            }
        }

        public string Status
        {
            get { return status; }
        }

        public bool IsActive()
        {
            return status == "active";
        }

        public void SetStatus(string newStatus)
        {
            if (newStatus == "active" || newStatus == "inactive")
            {
                status = newStatus;
            }
        }
    }
}
