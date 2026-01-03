using System;
using System.Collections.Generic;

namespace QuizProjectCOM326
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("QuizProjectCOM326");

            // Minimal run test (safe for coursework)
            var name = new LinkedList<string>(new[] { "Programming" });
            var desc = new LinkedList<string>(new[] { "Concepts of object-oriented programming" });

            var category = new Category(1, name, desc);
            var quiz = new Quiz("OOP Fundamentals", "Covers basics of OOP", category);

            Console.WriteLine(quiz.ToString());

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
} 
