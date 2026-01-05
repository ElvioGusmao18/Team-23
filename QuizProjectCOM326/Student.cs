// Joint effort by Ryan Miller - B00986294 and Elvio Gusmao - B00XXXXXX : COM326, QUIZ PROJECT

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizProjectCOM326
{
    public class Student : User
    {
<<<<<<< HEAD

        public string _status;

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        // Default/blank constructor
        public Student()
        {

        }
        
        // Constructor used to build all users who are type student, includes "status" attribute
        
        public Student(int id, string username, string password, string email, string status)
        {
            ID = id;
            Username = username;
            Password = password;
            Email = email;
            Status = status;
            Role = "STUDENT";

            if (status == "inactive")
            {
                Status = "inactive";
            }
            else
            {
                Status = "active";
            }
        }

        // isActive method is used when we check to see if a disabled account is trying to log in.

        public bool isActive()
        {
            if (Status == "active")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // SetStatus gives admin functionality

        public void SetStatus(string updatedStatus)
        {
            if (updatedStatus == "active" || updatedStatus == "inactive")
            {
                Status = updatedStatus;
            }
        }

=======
       
        private string status;

        // Default constructor
        public Student() : base()
        {
            status = "active";
            Role = "Student";
        }

        // Custom constructor
        public Student(int id, string username, string password, string email, string status)
            : base(id, username, password, email, "Student")
        {
            if (status == "active" || status == "inactive")
            {
                this.status = status;
            }
            else
            {
                this.status = "active";
            }
        }

        
        public bool IsActive()
        {
            return status == "active";
        }

        
        public void StartQuiz(Quiz quiz)
        {
            if (!IsActive())
            {
                Console.WriteLine("Student is inactive and cannot start the quiz.");
                return;
            }

            Console.WriteLine("Quiz started.");
        }

        
        public void SubmitQuiz(Quiz quiz)
        {
            Console.WriteLine("Quiz submitted.");
        }

       
        public void ViewQuizResults()
        {
            Console.WriteLine("Viewing quiz results.");
        }
>>>>>>> origin/main
    }
}
