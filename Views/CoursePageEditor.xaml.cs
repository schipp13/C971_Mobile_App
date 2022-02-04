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

            

            // This should set the minimumdate to be a month prior the current date.
            CourseStart.MinimumDate = DateTime.Now;
            CourseEnd.MinimumDate = DateTime.Now;
        }

        async void LoadCourse(string itemId)
        {
            try
            {
                int id = Convert.ToInt32(itemId);

                // Retrieve the instructor and set it as the BindingContext of the page.
                // Instructor instructor = await App.Database.GetInstructorAsync(id);
                // BindingContext = instructor;

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
            /*Term term = await App.Database.GetTermId(GlobalName);*/
            

            var course = (Course)BindingContext;
            course.Course_Name = CourseName.Text;
            course.Course_Status = CourseStatus.Text;
            course.Course_Start = CourseStart.Date;
            course.Course_End = CourseEnd.Date;
            course.Instructor_Name = InstructorName.Text;
            course.Instructor_Email = InstructorEmail.Text;
            course.Instructor_Phone = InstructorPhone.Text;
            course.Course_Description = CourseDescription.Text;
            /*course.Term_Id = term.Term_Id;*/


            if (!string.IsNullOrWhiteSpace(course.Course_Name))
            {
                await App.Database.SaveCourseAsync(course);
            }

            // Navigate To the assessments page editor
            await Shell.Current.GoToAsync($"{nameof(AssessmentPageEditor)}?{nameof(AssessmentPageEditor.ItemId)}={course.Course_Id.ToString()}");
        }

    }
}
