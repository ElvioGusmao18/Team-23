using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizProjectCOM326
{
    public class Addption
    {
        // foren variables
        String category = "Temp";   
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

    // allow the admin to add a question
    public class AddQuestion(String option)
    {
        
    }
    // allow the admin to remove a question
    public class RemoveQuestion(String option)
    {

    }
    // cheack the answers given by the user
    public class CheckAnswers(String answers)
    {

    }
    // allows the admin to set the correct answer for a question
    public class SetCorrectAnswer(String colrrect)
    {

    }



}}

