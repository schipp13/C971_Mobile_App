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
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Retrieve all the courses from the database, and set them as the
            // data source for the CollectionView.
            CourseItems.ItemsSource = await App.Database.GetCoursesAsync();
        }

        /*  
           async void OnAddClicked(object sender, EventArgs e)
           {
               // Navigate to the NoteEntryPage.
               await Shell.Current.GoToAsync(nameof(CoursePage));
           }
        */

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
