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
    public partial class AssessmentPageEditor : ContentPage
    {
        int courseId;
        string ThisCourseName;
        bool editmode;

        public AssessmentPageEditor(string name, int id, bool editModeOn)
        {   // Needs to be set to pass to refresh the page.       
            ThisCourseName = name;
            editmode = editModeOn;

            if (editModeOn)
            {
                InitializeComponent();
                LoadAssessment(id);
                courseId = id;
            }
            else
            {
                InitializeComponent();     
                
                // Retrieve the assessment and set it as the BindingContext of the page.
                courseId = id;
                BindingContext = new Assessment();
                LoadAssessment(courseId);
            }

            CourseName.Text = name;

            // This should set the minimumdate to be a month prior the current date.
            AssessmentStart.Date = DateTime.Now;
            AssessmentEnd.Date = DateTime.Now;
        }

        async void LoadAssessment(int id)
        {
            try
            {                              
                // Retrieve the assessment and set it as the BindingContext of the page.
                Assessment assessment = await App.Database.GetAssesmentAsync(id);
                BindingContext = assessment;
                courseId = id;
                AssessmentItems.ItemsSource = await App.Database.GetAssociatedAssessments(id);

            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load assessment.");
            }
        }

        async void CreateAssessmentButtonClick(object sender, EventArgs e)
        {
            if (AssessmentStart.Date > AssessmentEnd.Date)
            {
                //Popup error
                await DisplayAlert("Alert", "The start date is after the end date. Please set the start date prior to the end date.", "OK");
            }
            else
            {
                var assessment = new Assessment();
                assessment.Course_Id = courseId;
                assessment.Assessment_Name = AssessmentName.Text;
                assessment.Assessment_Type = AssessmentType.Text;
                assessment.Assessment_Start = AssessmentStart.Date;
                assessment.Assessment_End = AssessmentEnd.Date;

                if (!string.IsNullOrWhiteSpace(assessment.Assessment_Name))
                {
                    await App.Database.SaveAssessmentAsync(assessment);
                }

                var CurrentPage = new AssessmentPageEditor(ThisCourseName, courseId, editmode);
                Navigation.InsertPageBefore(CurrentPage, this);

                await Navigation.PopAsync();
            }
        }

        async void OnDeleteAssessmentClicked(object sender, EventArgs e)
        {
            ImageButton button = sender as ImageButton;
            var assessment = button.BindingContext as Assessment;
            await App.Database.DeleteAssessmentAsync(assessment);

            var CurrentPage = new AssessmentPageEditor(ThisCourseName, courseId, editmode);
            Navigation.InsertPageBefore(CurrentPage, this);
            await Navigation.PopAsync();

        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PopToRootAsync();
        }
    }
}