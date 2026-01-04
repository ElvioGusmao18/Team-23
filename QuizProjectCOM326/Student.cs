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
    }
}
