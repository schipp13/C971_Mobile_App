using System;
using System.Collections.Generic;
using LocalDatabaseTutorial.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Windows.Input;

namespace LocalDatabaseTutorial.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TermPageEditor : ContentPage
    {
        public TermPageEditor()
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
        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                // Navigate to the CoursePage, passing the ID as a query parameter.
                Course course = (Course)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(CourseEntryPage)}?{nameof(CourseEntryPage.ItemId)}={course.Course_Id.ToString()}");
            }
        }

        private async void DeleteCourseClicked(object sender, EventArgs args)
        {
                // Deletes the selected course
                 
        }
   
        private async void AddCourseHandler(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CourseEntryPage());
        }

      
        
    }
}
