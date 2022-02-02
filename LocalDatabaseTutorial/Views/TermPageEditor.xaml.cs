using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using c971_MobileApplication.Models;
using System.Windows.Input;

namespace c971_MobileApplication.Views
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
        async void OnSelectedItem(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                // Navigate to the CoursePage, passing the ID as a query parameter.
                Course course = (Course)e.CurrentSelection.FirstOrDefault();

                await Shell.Current.GoToAsync($"{nameof(CoursePageEditor)}?{nameof(CoursePageEditor.ItemId)}={course.Course_Id.ToString()}");
            }
        }

        async void OnDeleteCourseButtonClick(object sender, EventArgs e)
        {
            /*var course = (Course)BindingContext;*/
            
            ImageButton button = sender as ImageButton;
            var course = button.BindingContext as Course;



            await App.Database.DeleteCourseAsync(course);   
            await Shell.Current.GoToAsync(nameof(TermPageEditor));
        }

        
        private async void AddCourseHandler(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CoursePageEditor());
        }
    }
}



/*    async void DeleteCourseClick(object o)
    {
        // Check box must be clicked first before deleteing a course from the list
        Course courseBeingRemoved = o as Course;

        Console.WriteLine(courseBeingRemoved.Course_Name);
        *//*CourseItems.Remove(courseBeingRemoved);*//*
        await App.Database.DeleteCourseAsync(courseBeingRemoved);

        await Shell.Current.GoToAsync(nameof(MainPage));
    }*/

/*  private async void DeleteCourseClicked(object sender, EventArgs e)
  {
      // Deletes the selected course
      *//*ImageButton button = sender as ImageButton;*//*


      await App.Database.DeleteCourseAsync(course);
  }*/


