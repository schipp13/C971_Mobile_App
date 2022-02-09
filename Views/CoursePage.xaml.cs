using System;
using c971_MobileApplication.Models;
using Xamarin.Forms;


namespace c971_MobileApplication.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]

    public partial class CoursePage : ContentPage
    {
        int courseId;
        public string ItemId
        {
            set
            {
                LoadCourse(value);
            }
        }
        public CoursePage()
        {
            InitializeComponent();

            // Set the BindingContext of the page to a new Course.
            BindingContext = new Course();
        }

        async void LoadCourse(string itemId)
        {
            try
            {
                int id = Convert.ToInt32(itemId);
                // Retrieve the course and set it as the BindingContext of the page.
                Course course = await App.Database.GetCourseAsync(id);
                BindingContext = course;
                courseId = course.Course_Id;

                Term term = await App.Database.GetTermAsync(course.Term_Id);   
                
                TermName.Text = term.Term_Name;
                TermDate.Text = term.Term_Date;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load course.");
            }
        }

        private async void NavigateHandler(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AssessmentsPage(courseId,CourseName.Text));
          
        }

    }
}
