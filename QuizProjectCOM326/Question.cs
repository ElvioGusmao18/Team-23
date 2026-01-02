//Eoin Morgan - COM326 - Quiz Project
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizProjectCOM326
{
    public class Question
    {

        //private fields
        private int QuestionID;
        private string QuestionText;
        private LinkedList<string> QuestionOptions;
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
        public LinkedList<string> questionOptions
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
        public Question(int qID, string qText, LinkedList<string> qOptions, string correctAnswers, string qDifficulty)
        {
            QuestionID = qID;
            QuestionText = qText;
            QuestionOptions = qOptions;
            CorrectOptionAnswers = correctAnswers;
            QuestionDifficulty = qDifficulty;
        }
        // default constructor
        public Question()
        {
            QuestionID = 0;
            QuestionText = "Default Question Text";
            QuestionOptions = new LinkedList<string>();
            CorrectOptionAnswers = "Default Correct Answer";
            QuestionDifficulty = "Easy";
        }

        // allow the admin to add an option to a question 
        //the method takes in the list of options for that question and the option to be added
        //then returns the updated list of options
        public LinkedList<string> addOption(string option, Boolean AdminCheck)
        {
            // add the given option to a list of for that question
            //then return the list
            
            if (AdminCheck == true)
            {
                questionOptions.AddLast(option);
            }
            return questionOptions;
        }
       

        // allow the admin to remove an option from a question
        // the method takes in the list of options for that question and the option to be removed
        // then returns the updated list of options
        public LinkedList<string> RemoveOption(string option, Boolean AdminCheck)
        {
            var descriptionExists = questionOptions.Contains(option);
            if (AdminCheck == true)
            {
                
                if (!descriptionExists)
                {
                   Console.WriteLine("Option not found.");
                }
                else
                {
                    questionOptions.Remove(option);
                }
            }
            return questionOptions;
        }



        // cheack the answers given by the user
        // the method takes in an array of answers given by the user
        // then returns an array of results indicating whether each answer is correct or incorrect
        public List<string> CheackAnswers(List<string> answers)
        {

            List<string> userresulst = new List<string>();
            for (int i = 0; i < answers.Count; i++)
            {
                if (answers[i] == correctOptionAnswers)
                {
                    userresulst.Add("Correct");
                }
                else
                {
                    userresulst.Add("Incorrect");
                }
            }

             

            return userresulst;
        }

        // allows the admin to set the correct answer for a question
        // the method takes in the correct answer and updates the correct answer for that question
        // then returns the updated correct answer
        public LinkedList<string> SetCorrectAnswer(String correctIn, LinkedList<string> CorrectAnswers, Boolean AdminCheck)
        {
            if (AdminCheck == true)
            {
                for (int i = 0; i < CorrectAnswers.Count; i++)
                {
                    if (CorrectAnswers.ElementAt(i) == correctIn)
                    {
                        Console.WriteLine("Answer already set as correct.");
                        break;
                    }
                    else
                    {
                        CorrectAnswers.AddLast(correctIn);
                    }
                } 
            }
            return CorrectAnswers;
        }
    }
    
}

