using c971_MobileApplication.Models;
using c971_MobileApplication.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace c971_MobileApplication.ViewModels
{
    public class TermViewModel
    {
        public TermViewModel()
        {

        }

        // This Command creates a new term 
        public ICommand AddTermCommand => new Command(AddTerm);
        void AddTerm()
        {
           
        }
                
        // This Command deletes the currently selected term
        public ICommand DeleteTermCommand => new Command(DeleteTerm);
        void DeleteTerm(Object o)
        {

        }
               
        // This command opens the course page editor to be edited
        public ICommand EditCourseCommand => new Command(EditCourse);
        void EditCourse()
        {

        }

        // This Command Deletes the selected course
        public ICommand DeleteCourseCommand => new Command(DeleteCourse);
        void DeleteCourse(Object o)
        {
           
        }

    }
}
