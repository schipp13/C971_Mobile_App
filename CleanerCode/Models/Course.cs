using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CleanerCode.Models
{
    public class Course
    {
        public int Course_Id { get; set; }
        public int Instructor_Id { get; set; }
        public string Course_Name { get; set; }
        public string Course_Status { get; set; }
        public DateTime Course_Start { get; set; }
        public DateTime Course_End { get; set; }
        public string Course_Description { get; set; }
        public string Course_Notes { get; set; }
        public int Assessment_Id { get; set; }
        public ObservableCollection<Assessment> AssessmentList { get; set; }
                
        public Course(string Course_Name, string Course_Status, int Instructor_Id, DateTime Course_Start, DateTime Course_End, string Course_Description, string Course_Notes, 
            int Assessment_Id)
        {
            this.Course_Name = Course_Name;
            this.Course_Status = Course_Status;
            this.Instructor_Id = Instructor_Id;
            this.Course_Start = Course_Start;
            this.Course_End = Course_End;
            this.Course_Description = Course_Description;
            this.Course_Notes = Course_Notes;
            this.Assessment_Id = Assessment_Id;
        }
    }
}
