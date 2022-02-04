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

            TermName.Text = "Select a Term";
            TermDate.Text = $"{DateTime.Now.ToString("M")} - {DateTime.Now.ToString("M")}";
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

            // Retrieve all the courses from the database, and set them as the
            // data source for the CollectionView.
            CourseItems.ItemsSource = await App.Database.GetCoursesAsync();
        }


         async void OnTermSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                // Navigate to another term, passing the ID as a query parameter.
                Term term = (Term)e.CurrentSelection.FirstOrDefault();
                TermName.Text = term.Term_Name;
                TermDate.Text = term.Term_Date;

                /*await Shell.Current.GoToAsync($"{nameof(MainPage)}?{nameof(MainPage.ItemId)}={term.Term_Id.ToString()}");*/

                CourseItems.ItemsSource = await App.Database.GetAssociatedCourseAsync(term.Term_Id);

                Console.WriteLine(term.Term_Id);

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

        private  void LoadTermClick(object sender, EventArgs e)
        {
            Console.WriteLine("Term button clicked");
            
        }
    }
}