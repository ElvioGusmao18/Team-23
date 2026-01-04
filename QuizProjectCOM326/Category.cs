//Eoin Morgan - COM326 - Quiz Project
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizProjectCOM326
{
    internal class Category
    {
        //private fields
        private int CategoryID;
        private LinkedList<string> CategoryName;
        private LinkedList<string> CategoryDescription;
        //public fields
        public int categoryID
        {
            get { return CategoryID; }
            set { CategoryID = value; }
        }
        public LinkedList<string> categoryName
        {
            get { return CategoryName; }
            set { CategoryName = value; }
        }
        public LinkedList<string> categoryDescription
        {
            get { return CategoryDescription; }
            set { CategoryDescription = value; }
        }
        // constructor
        public Category(int cID, LinkedList<string> cName, LinkedList<string> cDescription)
        {
            CategoryID = cID;
            CategoryName = cName;
            CategoryDescription = cDescription;
        }
        // default constructor
        public Category()
        {
            CategoryID = 0;
            CategoryName = new LinkedList<string>();
            CategoryDescription = new LinkedList<string>();
        }

        //method will take in the old name and new name to update the category name
        //then return a string message to confirm the update
        public string UpdateCategoryName(string newName , string oldName)
        {
            var descriptionExists = CategoryName.Contains(oldName);
            if (!descriptionExists)
            {
                return "Description not found.";
                
            } else
            {
                CategoryName.Remove(oldName);
                CategoryName.AddAfter(CategoryName.Last, newName);
               
            }
            return "Category updated successfully.";
        }

        // method will take in the old description and new description to update the category description
        // then return a string message to confirm the update
        public string UpdateCategoryDescription(string newDescription, string oldDescription)
        {
            var descriptionExists = CategoryDescription.Contains(oldDescription);
            if (!descriptionExists)
            {
                return "Description not found.";
            }
            else
            {
                CategoryDescription.Remove(oldDescription);
                CategoryDescription.AddAfter(CategoryDescription.Last, newDescription);
                
            }
            return "Category description updated successfully.";
        }

    }
    
}
