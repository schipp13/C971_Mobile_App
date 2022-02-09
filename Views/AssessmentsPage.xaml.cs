using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using c971_MobileApplication.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace c971_MobileApplication.Views
{
    
    public partial class AssessmentsPage : ContentPage
    {
        int itemId;
        public AssessmentsPage(int id, string name)
        {
            InitializeComponent();

            CourseName.Text = name;

            // Set the BindingContext of the page to a new Course.
            BindingContext = new Assessment();
            itemId = id;
            LoadAssessments(id);
        }

        async void LoadAssessments(int itemId)
        {
            try
            {
                Assessment assessment = await App.Database.GetAssesmentAsync(itemId);
                BindingContext = assessment;

                // Retrieve the assessments and set it as the BindingContext of the page.
                AssessmentItems.ItemsSource = await App.Database.GetAssociatedAssessments(itemId);

            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load assessment.");
            }
        }

    }
}