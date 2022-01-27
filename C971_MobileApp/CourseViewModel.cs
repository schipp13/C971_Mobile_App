using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace C971_MobileApp
{
    public class CourseViewModel
    {
        public ObservableCollection<Course> CourseItems { get; set; }
        public Course Course { get; set; }
        public Assessment Test { get; set; }
        
        public CourseViewModel()
        {
            CourseItems = new ObservableCollection<Course>();
        }

        // This should navigate to the assessments page after adding the course to the course list
        public ICommand AddCourseCommand => new Command(async () => {

            Course = new Course(1, 1, Test.assessment_id, "Course Name", "Enrolled", "Course Description", "Course Notes",
                           DateTime.Now, DateTime.Now);


            CourseItems.Add(Course);

            await Application.Current.MainPage.Navigation.PushAsync(new AssessmentPage_Editor());
             });

        // This should navigate to the main page after adding the assessments to the associated course
        public ICommand SaveCourse => new Command(async () => {
            // Get values to store into assessment

            Course.CourseAssessments.Add(new Assessment(1, Test.assessment_name, Test.assessment_type
                ,DateTime.Now, DateTime.Now));

            await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
        });

        public ICommand AddAssessmentCommand => new Command(AddAssessment);

        void AddAssessment()
        {
            // Create new assessment box

        }

        public ICommand RemoveCourseCommand => new Command(RemoveCourse);
        void RemoveCourse(Object o)
        {
            // Check box must be clicked first before deleteing a course from the list
            Course courseBeingRemoved = o as Course;
            CourseItems.Remove(courseBeingRemoved);
        }

    }
}

// Create new course
// public string NewCourseName { get; set; }

/* void AddCourse()
 {
     //TODO: Add the courses to the list here
     CourseItems.Add(new Course(1, 1, 1, "Course Name", "Enrolled", "Course Description", "Course Notes",
                     DateTime.Now, DateTime.Now));

 }*/
