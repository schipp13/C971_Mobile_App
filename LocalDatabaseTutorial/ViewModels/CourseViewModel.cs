using c971_MobileApplication.Models;
using c971_MobileApplication.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace c971_MobileApplication.ViewModels
{
    public class CourseViewModel
    {
        
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
            await Application.Current.MainPage.Navigation.PushAsync(new AssessmentPageEditor());
        });

    }
}
