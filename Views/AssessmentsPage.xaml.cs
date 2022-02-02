using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocalDatabaseTutorial.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LocalDatabaseTutorial.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class AssessmentsPage : ContentPage
    { 
        public string ItemId
        {
            set
            {
                LoadAssessments(value);
            }
        }

        public AssessmentsPage(string name)
        {
            InitializeComponent();

            CourseName.Text = name;
               
            // Set the BindingContext of the page to a new Course.
            BindingContext = new Assessment();
        }
     
        async void LoadAssessments(string itemId)
        {
            try
            {
                int id = Convert.ToInt32(itemId);
                // Retrieve the assessments and set it as the BindingContext of the page.
                Assessment assessment = await App.Database.GetAssesmentAsync(id);
                BindingContext = assessment;

            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load assessment.");
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Retrieve all the assessments from the database, and set them as the
            // data source for the CollectionView.
            AssessmentItems.ItemsSource = await App.Database.GetAssessmentsAsync();
        }

    }
}