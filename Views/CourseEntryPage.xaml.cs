using System;
using LocalDatabaseTutorial.Models;
using Xamarin.Forms;


namespace LocalDatabaseTutorial.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class CourseEntryPage : ContentPage
    {
        public string ItemId
        {
            set
            {
                LoadCourse(value);
            }
        }
        public CourseEntryPage()
        {
            InitializeComponent();

            // Set the BindingContext of the page to a new Course.
            BindingContext = new Course();

            // This should set the minimumdate to be a month prior the current date.
            CourseStart.MinimumDate = DateTime.Now.AddMonths(-1); 
        }

        async void LoadCourse(string itemId)
        {
            try
            {
                int id = Convert.ToInt32(itemId);

                // Retrieve the instructor and set it as the BindingContext of the page.
                Instructor instructor = await App.Database.GetInstructorAsync(id);
                BindingContext = instructor;

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
            course.Course_Name = CourseName.Text;
            course.Course_Status = CourseStatus.Text;
            course.Course_Start = CourseStart.Date;
            course.Course_End = CourseEnd.Date;
            course.Course_Description = CourseDescription.Text;

            var instructor = (Instructor)BindingContext;
            instructor.Instructor_Name = InstructorName.Text;
            instructor.Instructor_Email = InstructorEmail.Text;
            instructor.Instructor_Phone = InstructorPhone.Text;

            if (!string.IsNullOrWhiteSpace(course.Course_Name))
            {
                await App.Database.SaveCourseAsync(course);
                await App.Database.SaveInstructorAsync(instructor);
            }

            // Navigate To the assessments page editor
            await Shell.Current.GoToAsync($"{nameof(AssessmentPageEditor)}?{nameof(AssessmentPageEditor.ItemId)}={course.Course_Id.ToString()}");
        }  
        
        
        public void AddNoteClicked()
        {
           
            
        }

    }
}