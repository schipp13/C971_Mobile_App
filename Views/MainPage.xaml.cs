using c971_MobileApplication.Views;
using c971_MobileApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Plugin.LocalNotifications;

namespace c971_MobileApplication.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class MainPage : ContentPage
    {
        public string ItemId
        {
            set
            {
                LoadTerm(value);
            }
        }
        public MainPage()
        {
            InitializeComponent();

            // Set the BindingContext of the page to a new Term.
            BindingContext = new Term();

            // Populate DB
            PopulateDB();

            TermName.Text = "Select a Term";
            TermDate.Text = $"{DateTime.Now.ToString("M")} - {DateTime.Now.ToString("M")}";
            
        }

        async void PopulateDB()
        {
            
            var termList = await App.Database.GetTermsAsync();
            var courseList = await App.Database.GetCoursesAsync();
            var assessmentList = await App.Database.GetAssessmentsAsync();

            // Populate the Term Table
            if (termList.Count() == 0)
            {
                await App.Database.PopulateTermsTable();
            }

            // Populate the Course Table
            if (courseList.Count() == 0)
            {
                await App.Database.PopulateCourseTable();
            }
            // Populate the Assessments Table
            if (assessmentList.Count() == 0)
            {
                await App.Database.PopulateAssessmentsTable();
                await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
                await Application.Current.MainPage.Navigation.PopToRootAsync();
            }

           

        }

        async void LoadTerm(string itemId)
        {
            try
            {
                int id = Convert.ToInt32(itemId);

                // Retrieve the term and set it as the BindingContext of the page.
                Term term = await App.Database.GetTermAsync(id);
                BindingContext = term;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load term.");
            }
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();           

            // Retrieve all the terms from the database, and set them as the
            // data source for the CollectionView.
            TermItems.ItemsSource = await App.Database.GetTermsAsync();
            GetNotifications();
        }

        async void OnTermSelectionChanged(object sender, SelectionChangedEventArgs e)
       {
            if (e.CurrentSelection != null)
            {
                // Navigate to another term, passing the ID as a query parameter.
                Term term = (Term)e.CurrentSelection.FirstOrDefault();
                TermName.Text = term.Term_Name;
                TermDate.Text = term.Term_Date;

                CourseItems.ItemsSource = await App.Database.GetAssociatedCourseAsync(term.Term_Id);
                
            }
        }
         
        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                // Navigate to the CoursePage, passing the ID as a query parameter.
                Course course = (Course)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(CoursePage)}?{nameof(CoursePage.ItemId)}={course.Course_Id.ToString()}");
            }
        }
        private async void EditTermHandler(Object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new TermPageEditor());
        }


        private async void RefreshTermHandler (Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
            await Navigation.PopToRootAsync();
        }

        public async void GetNotifications()
        {
            // Find course that has start date of current date
            DateTime currentDate = DateTime.Today;

            var courseList = await App.Database.GetCoursesAsync();
           
            foreach (var course in courseList)
            {
                if(course.Course_Start.Date.ToString("M") == currentDate.ToString("M"))
                {
                    // Display notification
                    CrossLocalNotifications.Current.Show("Course Started", $"{course.Course_Name} has started today!");
                }
                else if(course.Course_End.Date.ToString("M") == currentDate.ToString("M"))
                {
                    // Display notification
                    CrossLocalNotifications.Current.Show("Course Ended", $"{course.Course_Name} has ended today!");
                }
            }
            
             var assessmentList = await App.Database.GetAssessmentsAsync();
            foreach (var assessment in assessmentList)
            {
                if (assessment.Assessment_Start.Date.ToString("M") == currentDate.ToString("M"))
                {
                    // Display notification
                    CrossLocalNotifications.Current.Show("Assessment Started", $"{assessment.Assessment_Name} has started today!");
                }
                else if (assessment.Assessment_End.Date.ToString("M") == currentDate.ToString("M"))
                {
                    // Display notification
                    CrossLocalNotifications.Current.Show("Assessment Ended", $"{assessment.Assessment_Name} has ended today!");
                }
            }


        }
    }
}