using System;
using System.Collections.Generic;

namespace C971_MobileApp
{
    public class Course
    {
        public List<Assessment> CourseAssessments = new List<Assessment>();

        public int course_id { get; set; }
        public int course_instructor_id { get; set; }
        public int assessment_id { get; set; }
        public string courseName { get; set; }
        public string courseStatus { get; set; }
        public string courseDescription { get; set; }
        public string courseNotes { get; set; }
        public DateTime courseStartDate { get; set; }
        public DateTime courseEndDate { get; set; }
        public string courseDate => $"{courseStartDate} - {courseEndDate}";

        public Course(int course_id, int course_instructor_id, int assessment_id, string courseName,
                string courseStatus, string courseDescription, string courseNotes, DateTime courseStartDate, DateTime courseEndDate)
        {
            this.course_id = course_id;
            this.course_instructor_id = course_instructor_id;
            this.assessment_id = assessment_id;
            this.courseName = courseName;
            this.courseStatus = courseStatus;
            this.courseDescription = courseDescription;
            this.courseNotes = courseNotes;
            this.courseStartDate = courseStartDate;
            this.courseEndDate = courseEndDate;

        }


    }
}
