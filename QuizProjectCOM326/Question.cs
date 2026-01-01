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
        private LinkedList<string> QuestionOptions;
        private LinkedList<string> CorrectOptionAnswers;
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
        public LinkedList<string> correctOptionAnswers
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
        public Addption(int qID, string qText, LinkedList<string> qOptions, LinkedList<string> correctAnswers, string qDifficulty)
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
            QuestionOptions = new LinkedList<string>();
            CorrectOptionAnswers = new LinkedList<string>();
            QuestionDifficulty = "Easy";
        }

        // allow the admin to add an option to a question 
        //the method takes in the list of options for that question and the option to be added
        //then returns the updated list of options
        public LinkedList<string> addOption(LinkedList<string> QuestionOptions, string option, Boolean AdminCheck)
        {
            // add the given option to a list of for that question
            //then return the list
            LinkedList<string> optionsList = new LinkedList<string>(QuestionOptions);
            if (AdminCheck == true)
            {
                optionsList.AddLast(option);
                optionsList.OrderBy(x => x);
            }
            return optionsList;
        }
        //confirmation for the options added





        // allow the admin to remove an option from a question
        // the method takes in the list of options for that question and the option to be removed
        // then returns the updated list of options
        public LinkedList<string> RemoveOption(LinkedList<string> QuestionOptions, string option, Boolean AdminCheck)
        {
            LinkedList<string> optionsList = new LinkedList<string>(QuestionOptions);
            if (AdminCheck == true)
            {
                bool check = optionsList.Contains(option);
                if (check == true)
                {
                    optionsList.Remove(option);
                }
                else
                {
                    Console.WriteLine("Option not found.");

                }
            }
            return optionsList;
        }



        // cheack the answers given by the user
        // the method takes in an array of answers given by the user
        // then returns an array of results indicating whether each answer is correct or incorrect
        public List<string> CheackAnswers(List<string> answers)
        {

            List<string> userresulst = new List<string>();
            for (int i = 0; i < answers.Count; i++)
            {
                if (answers[i] == CorrectOptionAnswers.ElementAt(i))
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
                        CorrectAnswers.OrderBy(x => x);
                    }
                } 
            }
            return CorrectAnswers;
        }
    }
    
}

