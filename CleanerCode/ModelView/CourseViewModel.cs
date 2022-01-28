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
    public class CourseViewModel
    {
        public Course course { get; set; }
        public Instructor instructor { get; set; }


        // This command creates new notes for the course
        public ICommand AddNotesCommand => new Command(AddNotes);
        void AddNotes()
        {

        }

        // This command shares the notes
        public ICommand ShareNotesCommand => new Command(ShareNotes);
        void ShareNotes()
        {

        }

        // This command allows the notes to be deleted
        public ICommand DeleteNotesCommand => new Command(DeleteNote);
        void DeleteNote()
        {

        }

        // This command creates the new course and new instructor
        // for the course before navigating to the Assessments Page Ediotor
        public ICommand NavigateToAssessmentsCommand => new Command(async () =>
        {
            instructor = new Instructor("Name", "Email", "Phone");
            
            course = new Course("Name", "Status", instructor.Instructor_Id, DateTime.Now, DateTime.Now, "Description", "Notes", 1);

            await Application.Current.MainPage.Navigation.PushAsync(new AssessmentPageEditor());
        });
       
    }
}
