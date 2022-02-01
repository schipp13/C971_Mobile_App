using System;
using c971_MobileApplication.Models;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace c971_MobileApplication.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class CoursePageEditor : ContentPage
    {
        public string ItemId
        {
            set
            {
                LoadCourse(value);
            }
        }
        public CoursePageEditor()
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
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load course.");
            }
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var course = (Course)BindingContext;
         // course.Course_Name = CourseName.Text;
            course.Course_Status = CourseStatus.SelectedItem.ToString();
            course.Course_Start = CourseStart.Date;
            course.Course_End = CourseEnd.Date;
            course.Course_Description = CourseDescription.Text;

            if (!string.IsNullOrWhiteSpace(course.Course_Name))
            {
                await App.Database.SaveCourseAsync(course);
            }

            // Navigate backwards
           // await Shell.Current.GoToAsync("..");
        }
    }
}
