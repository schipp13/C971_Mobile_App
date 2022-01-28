using CleanerCode.Models;
using CleanerCode.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CleanerCode.ModelView
{
    public class AssessmentViewModel
    {
        public Assessment assessment { get; set; }

        // This command creates a new assessment
        public ICommand AddAssessmentCommand => new Command(AddAssessment);
        void AddAssessment()
        {
            
        }

        // This command saves the changes and goes back to the term page.
        public ICommand SaveChangesCommand => new Command(SaveChanges);
        void SaveChanges()
        {

        }

        // This command deletes the selected assessment
        public ICommand DeleteAssessmentCommand => new Command(DeleteAssessment);
        void DeleteAssessment(Object o)
        {
            Assessment removeAssessment = o as Assessment;

        }
    }
}
