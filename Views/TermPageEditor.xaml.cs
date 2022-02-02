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

        async void OnDeleteCourseButtonClick(object sender, EventArgs e)
        {
            //Try this to see if some of the code can be cleaned up.
            /*var course = sender as Course;*/

            ImageButton button = sender as ImageButton;
            var course = button.BindingContext as Course;
            await App.Database.DeleteCourseAsync(course);
            await Shell.Current.GoToAsync(nameof(TermPageEditor));
        }

        private async void AddCourseHandler(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CourseEntryPage());
        }

        private async void AddTermClicked(object sender, EventArgs e)
        {
            // Creates a new term
            var term = (Term)BindingContext;
            term.Term_Name = TermNameField.Text;
            term.Term_Start = TermDateStart.Date;
            term.Term_End = TermDateEnd.Date;

            if (!string.IsNullOrWhiteSpace(term.Term_Name))
            {
                await App.Database.SaveTermAsync(term);
            }

        }

    }
}