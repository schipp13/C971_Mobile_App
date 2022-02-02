using System;
using c971_MobileApplication.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace c971_MobileApplication.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class AssessmentPageEditor : ContentPage
    {
        public string ItemId
        {
            set
            {
                LoadAssessment(value);
            }
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Retrieve all the courses from the database, and set them as the
            // data source for the CollectionView.
            AssessmentItems.ItemsSource = await App.Database.GetAssessmentsAsync();
        }


        public AssessmentPageEditor()
        {
            InitializeComponent();

            BindingContext = new Course();
            // Retrieve the assessment and set it as the BindingContext of the page.
            BindingContext = new Assessment();
        }

        async void LoadAssessment(string itemId)
        {
            try
            {
                int id = Convert.ToInt32(itemId);

                // Retrieve the assessment and set it as the BindingContext of the page.
                Assessment assessment = await App.Database.GetAssesmentAsync(id);
                BindingContext = assessment;

            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load assessment.");
            }
        }
    }
}