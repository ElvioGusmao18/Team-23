using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizProjectCOM326
{
    public class Addption
    {
        // foren variables fake data
        String category = "Temp";
        Boolean AdminCheck = true;
        //private fields
        private int QuestionID;
        private string QuestionText;
        private string[] QuestionOptions;
        private string CorrectOptionAnswers;
        private string QuestionDifficulty;

        //public fields
        public int questionID
        {
            get { return QuestionID; }
            set { QuestionID = value; }
        }
        public string questionText
        {
            get { return QuestionText; }
            set { QuestionText = value; }
        }
        public string[] questionOptions
        {
            get { return QuestionOptions; }
            set { QuestionOptions = value; }
        }
        public string correctOptionAnswers
        {
            get { return CorrectOptionAnswers; }
            set { CorrectOptionAnswers = value; }
        }
        public string questionDifficulty
        {
            get { return QuestionDifficulty; }
            set { QuestionDifficulty = value; }

        }
        //constructor
        public Addption(int qID, string qText, string[] qOptions, string correctAnswers, string qDifficulty)
        {
            QuestionID = qID;
            QuestionText = qText;
            QuestionOptions = qOptions;
            CorrectOptionAnswers = correctAnswers;
            QuestionDifficulty = qDifficulty;
        }
        // default constructor
        public Addption()
        {
            QuestionID = 0;
            QuestionText = "Default Question Text";
            QuestionOptions = new string[4] { "Option 1", "Option 2", "Option 3", "Option 4" };
            CorrectOptionAnswers = "Option 1";
            QuestionDifficulty = "Easy";
        }

        // allow the admin to add a question
        public string[] addOption(string[] QuestionOptions,string option ,Boolean AdminCheck)
        {
            // add the given option to a list of for that question
            //then return the list
         if (AdminCheck == true)
            {
                for (int i = 0; i < QuestionOptions.Length; i++)
                {
                    if (QuestionOptions[i] == null)
                    {
                        QuestionOptions[i] = option;
                        break;
                    }
                }
            }
         for (int i = 0; i < QuestionOptions.Length; i++)
            {
                Console.WriteLine(QuestionOptions[i]);
            }

            return QuestionOptions;
        }

        // allow the admin to remove a question
        public string[] RemoveOption(string[] QuestionOptions, string option, Boolean AdminCheck)
        {
            // find the option by ID then 
            // remove the given option from the list of options for that question
            if (AdminCheck == true)
            {
                for (int i = 0; i < QuestionOptions.Length; i++)
                {
                    if (QuestionOptions[i] == option)
                    {
                        QuestionOptions[i] = null;
                        break;
                    }
                }
                for (int i = 0; i < QuestionOptions.Length; i++)
                {
                    Console.WriteLine(QuestionOptions[i]);
                }

            }
            return QuestionOptions;
        }
        // cheack the answers given by the user
        public string[] CheackAnswers(string[] answers)
        {
            string[] userresulst = new string[answers.Length];
            for (int i = 0; i < answers.Length; i++)
            {
                Console.WriteLine(answers[i]);

                if (answers[i] == CorrectOptionAnswers)
                {
                    userresulst[i] = "Correct";
                    
                }
                else
                {
                    userresulst[i] = "Incorrect"; 
                }
              
            }
            return userresulst;
        }
        // allows the admin to set the correct answer for a question
        public string SetCorrectAnswer(String colrrect, Boolean AdminCheck)
        {
            if (AdminCheck == true)
            {
                for (int i = 0; i < QuestionOptions.Length; i++)
                {
                    Console.WriteLine(QuestionOptions[i]);
                    if (QuestionOptions[i] == colrrect)
                    {
                        CorrectOptionAnswers = colrrect;
                        Console.WriteLine("Correct answer set to: " + colrrect);
                        break;
                    }
                        
                }

                
            }

            return CorrectOptionAnswers;
        }

    }
    
}

