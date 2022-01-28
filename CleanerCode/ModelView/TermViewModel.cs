using CleanerCode.Models;
using CleanerCode.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CleanerCode.ModelView
{
    public class TermViewModel
    {
        public ObservableCollection<Course> Courses { get; set; }
        public Term Term { get; set; }


        // This Command creates a new term 
        public ICommand AddTermCommand => new Command(AddTerm);
        void AddTerm()
        {
            Term newTerm = new Term(1, "Name", DateTime.Now, DateTime.Now, Courses);

        }

        // This Command edits the currently selected term
        public ICommand EditTermCommand => new Command(EditTerm);
        void EditTerm(Object o)
        {

        }

        // This Command deletes the currently selected term
        public ICommand DeleteTermCommand => new Command(DeleteTerm);
        void DeleteTerm(Object o)
        {

        }

        // This Command navigates to the Course Page Editor
        public ICommand AddCourseCommand => new Command(async () => {
            await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
        });

        // This Command navigates to the selected Course Page Editor
        public ICommand NavigateToCoursePage => new Command(NavigateCoursePage);
        void NavigateCoursePage()
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
            Course selectedCourse = o as Course;
            Courses.Remove(selectedCourse);
        }

    }
}
