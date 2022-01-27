using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace C971_MobileApp
{
    public class CourseViewModel
    {
        public ObservableCollection<Test> CourseItems { get; set; }

        public CourseViewModel()
        {
            CourseItems = new ObservableCollection<Test>();

        }

        public ICommand AddCourseCommand => new Command(AddCourse);

        // Create new course
       // public string NewCourseName { get; set; }

        void AddCourse()
        {
            //TODO: Add the courses to the list here
        }

        public ICommand RemoveCourseCommand => new Command(RemoveCourse);
        void RemoveCourse(Object o)
        {
            // Check box must be clicked first before deleteing a course from the list
            Test courseBeingRemoved = o as Test;
            CourseItems.Remove(courseBeingRemoved);
        }

    }
}
