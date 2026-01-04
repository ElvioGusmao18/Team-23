using System;
using System.Collections.Generic;

namespace QuizProjectCOM326
{
    internal class Quiz
    {
        private static int _nextId = 1;
        private readonly List<Question> _quizQuestions = new List<Question>();

        public int QuizID { get; }  // read-only 
        public string QuizTitle { get; private set; }
        public string QuizDescription { get; private set; }
        public Category QuizCategory { get; private set; }
        public DateTime QuizDate { get; private set; }

        // QuizQuestions is a list
        public IReadOnlyList<Question> QuizQuestions => _quizQuestions;

        public Quiz(string title, string description, Category category)
        {
            QuizID = _nextId++;
            QuizTitle = title ?? "";
            QuizDescription = description ?? "";
            QuizCategory = category ?? throw new ArgumentNullException(nameof(category));
            QuizDate = DateTime.Now;
        }

        public void AddQuestion(Question question)
        {
            if (question == null) throw new ArgumentNullException(nameof(question));
            _quizQuestions.Add(question);
        }

        public bool RemoveQuestion(Question question)
        {
            if (question == null) return false;
            return _quizQuestions.Remove(question);
        }

        public int GetTotalQuestions()
        {
            return _quizQuestions.Count;
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

        public override string ToString()
        {
            return $"{QuizTitle} - {GetTotalQuestions()} questions";
        }
    }
}
