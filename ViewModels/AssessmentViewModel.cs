using c971_MobileApplication.Models;
using c971_MobileApplication.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace c971_MobileApplication.ViewModels
{
    public class AssessmentViewModel
    { 

        // This command creates a new assessment
        public ICommand AddAssessmentCommand => new Command(AddAssessment);
        void AddAssessment()
        {

        }

        // This command saves the changes and goes back to the term page.
        public ICommand SaveChangesCommand => new Command(async () =>
       {
           await Application.Current.MainPage.Navigation.PopToRootAsync();
       });

        // This command deletes the selected assessment
        public ICommand DeleteAssessmentCommand => new Command(DeleteAssessment);
        void DeleteAssessment(Object o)
        {


        }
    }
}
