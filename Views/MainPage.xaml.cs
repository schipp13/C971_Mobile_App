using System;
using LocalDatabaseTutorial.Views;
using LocalDatabaseTutorial.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LocalDatabaseTutorial.Views
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
                await Shell.Current.GoToAsync($"{nameof(MainPage)}?{nameof(MainPage.ItemId)}={term.Term_Id.ToString()}");
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
     
    }
}
