using System;
using c971_MobileApplication.Models;
using Xamarin.Forms;


namespace c971_MobileApplication.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class CoursePage : ContentPage
    {
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
                
                // Retrieve the term
                Term term = await App.Database.GetTermAsync(course.Term_Id);
                // TODO: Set the term values for the page versus setting the BindingContext.
                BindingContext = term;

            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load course.");
            }
        }

        // TODO: Get the associated asseessments to appear for the course.
        private async void NavigateHandler(object sender, EventArgs e)
        {
            string courseName = CourseName.Text;
            await Application.Current.MainPage.Navigation.PushAsync(new AssessmentsPage(courseName));

            /* // Navigate to the CoursePage, passing the ID as a query parameter.
             Course course = (Course)e.CurrentSelection.FirstOrDefault();
             await Shell.Current.GoToAsync($"{nameof(CoursePage)}?{nameof(CoursePage.ItemId)}={course.Course_Id.ToString()}");
 */
        }

    }
}
