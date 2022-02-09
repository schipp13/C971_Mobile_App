using System;
using c971_MobileApplication.Models;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.Generic;
using Xamarin.Essentials;
using System.Windows.Input;

namespace c971_MobileApplication.Views
{

    public partial class CoursePageEditor : ContentPage
    {
        // Used globally to store the passed TermId from the TermPageEditor
        int termId;
        bool inEditMode = false;

        public CoursePageEditor(int id, bool editModeOn)
        {
            if (editModeOn)
            {
                InitializeComponent();

                LoadCourse(id);
                inEditMode = editModeOn;

            }
            else
            {
                InitializeComponent();

                // Set the BindingContext of the page to a new Course.
                BindingContext = new Course();

                // This should set the minimumdate to be a month prior the current date.
                CourseStart.MinimumDate = DateTime.Now;
                CourseEnd.MinimumDate = DateTime.Now;

                termId = id;
            }
            List<string> StatusList = new List<string>();
            StatusList.Add("Not Enrolled");
            StatusList.Add("Enrolled");
            StatusList.Add("Completed");
            StatusList.Add("Failed");

            CourseStatus.ItemsSource = StatusList;
            NotesTextEditor.IsEnabled = false;
        }

        async void LoadCourse(int id)
        {
            try
            {
                // Retrieve the course and set it as the BindingContext of the page.
                Course course = await App.Database.GetCourseAsync(id);
                BindingContext = course;
                termId = course.Term_Id;
                CourseStatus.SelectedItem = course.Course_Status;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load course.");
            }
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            if (CourseStart.Date > CourseEnd.Date)
            {
                //Popup error
                await DisplayAlert("Alert", "The start date is after the end date. Please set the start date prior to the end date.", "OK");
            }
            else
            {
                if (InstructorName.Text == null || InstructorName.Text == "" || InstructorEmail.Text == null ||
                    InstructorEmail.Text == "" || InstructorPhone.Text == null || InstructorPhone.Text == "")
                {
                    //Popup error
                    await DisplayAlert("Alert", "Instructor Name, Email, or Phone is empty. Please enter the correct information.", "OK");

                }
                else
                {
                    var course = (Course)BindingContext;
                    course.Course_Name = CourseName.Text;
                    course.Course_Status = CourseStatus.SelectedItem.ToString();
                    course.Course_Start = CourseStart.Date;
                    course.Course_End = CourseEnd.Date;
                    course.Instructor_Name = InstructorName.Text;
                    course.Instructor_Email = InstructorEmail.Text;
                    course.Instructor_Phone = InstructorPhone.Text;
                    course.Course_Description = CourseDescription.Text;
                    course.Term_Id = termId;

                    if (!string.IsNullOrWhiteSpace(course.Course_Name))
                    {
                        await App.Database.SaveCourseAsync(course);
                    }

                    // Navigate To the assessments page editor
                    await Application.Current.MainPage.Navigation.PushAsync(new AssessmentPageEditor(course.Course_Name, course.Course_Id, inEditMode));

                }
            }
        }

        // Create a new note instance and add it to the CourseNotesList
        public void OnAddNotesClick(object sender, EventArgs e)
        {
            NotesTextEditor.IsEnabled = true;
        }      
        async void ShareNotes(object sender, EventArgs e)
        {
            var courseNotes = (Course)BindingContext;
            courseNotes.Course_Notes = NotesTextEditor.Text;

            await Share.RequestAsync(new ShareTextRequest
            {
                Text = courseNotes.Course_Notes,
                Title = "Sharing Notes"
            });
        }
              
    }
}