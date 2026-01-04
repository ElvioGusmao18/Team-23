using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace QuizProjectCOM326
{
    // Must be internal because Category is internal 
    internal class Quiz
    {
        
        
        
        private static int _nextId = 1;

        // Storing questions internally this encapsulates the list
        private readonly List<Question> _quizQuestions = new List<Question>();

        
        // Properties lined out in UML
        public int QuizID { get; }                 // read-only
        public string QuizTitle { get; private set; }
        public string QuizDescription { get; private set; }
        public Category? QuizCategory { get; private set; }
        public DateTime QuizDate { get; private set; }

        // Read-only access to the question list
        public IReadOnlyList<Question> QuizQuestions => _quizQuestions.AsReadOnly();

        // Constructors that are the base of the quiz

        // Main Constructor - default values
        public Quiz()
        {
            QuizID = _nextId++;
            QuizTitle = "";
            QuizDescription = "";
            QuizCategory = null;
            QuizDate = DateTime.Now;
        }

        // Custom Constructors - with parameters
        public Quiz(string title, string description, Category category, DateTime? quizDate = null)
        {
            QuizID = _nextId++;
            QuizTitle = title ?? "";
            QuizDescription = description ?? "";
            QuizCategory = category;
            QuizDate = quizDate ?? DateTime.Now;
        }


        // Methods outlined in UML


        // Add a question to the Quiz
        public void AddQuestion(Question question)
        {
            if (question == null)
                throw new ArgumentNullException(nameof(question));

            // If the question has an ID we can read, stop duplicates
            int? newId = TryGetQuestionId(question);
            if (newId.HasValue)
            {
                bool exists = _quizQuestions.Any(q => TryGetQuestionId(q) == newId.Value);
                if (exists)
                    throw new InvalidOperationException($"Question with ID {newId.Value} already exists in this quiz.");
            }

            _quizQuestions.Add(question);
        }

        // Remove a question by ID 
        public bool RemoveQuestion(int questionID)
        {
            if (questionID <= 0)
                throw new ArgumentOutOfRangeException(nameof(questionID), "Question ID must be greater than 0.");

            // Find the first question where we can read an ID that matches
            for (int i = 0; i < _quizQuestions.Count; i++)
            {
                int? id = TryGetQuestionId(_quizQuestions[i]);
                if (id.HasValue && id.Value == questionID)
                {
                    _quizQuestions.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        public void UpdateTitle(string newTitle)
        {
            if (string.IsNullOrWhiteSpace(newTitle))
                throw new ArgumentException("Title cannot be empty.", nameof(newTitle));

            QuizTitle = newTitle.Trim();
        }

        public void UpdateDescription(string newDescription)
        {
            if (string.IsNullOrWhiteSpace(newDescription))
                throw new ArgumentException("Description cannot be empty.", nameof(newDescription));

            QuizDescription = newDescription.Trim();
        }

        public void SetCategory(Category category)
        {
            QuizCategory = category ?? throw new ArgumentNullException(nameof(category));
        }

        public int GetTotalQuestions()
        {
            return _quizQuestions.Count;
        }

        public override string ToString()
        {
            return $"{QuizTitle} - {GetTotalQuestions()} questions";
        }

        
        //  method:
        // Tries to read the Question ID without assuming it is public.
        
        private static int? TryGetQuestionId(Question question)
        {
            if (question == null) return null;

            Type t = question.GetType();

            // Try common property names first
            PropertyInfo? prop =
                t.GetProperty("QuestionID", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic) ??
                t.GetProperty("questionID", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic) ??
                t.GetProperty("QuestionId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            if (prop != null && prop.PropertyType == typeof(int))
                return (int)prop.GetValue(question)!;

            // Try common field names if no property was found
            FieldInfo? field =
                t.GetField("QuestionID", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic) ??
                t.GetField("questionID", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic) ??
                t.GetField("_questionID", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            if (field != null && field.FieldType == typeof(int))
                return (int)field.GetValue(question)!;

            // If we cannot read an ID, return null (still allows quiz to work)
            return null;
        }
    }
}
