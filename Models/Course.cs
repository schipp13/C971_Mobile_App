using System;
using SQLite;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace c971_MobileApplication.Models
{
    [Table("Course")]
    public class Course
    {
        [PrimaryKey, AutoIncrement]
        public int Course_Id { get; set; }
        public int Term_Id { get; set; }
        public int Assessment_Id { get; set; }
        public string Course_Name { get; set; }
        public string Course_Status { get; set; }
        public DateTime Course_Start { get; set; }
        public DateTime Course_End { get; set; }
        public string Course_Description { get; set; }
        public string Course_Notes { get; set; }

        public string Instructor_Name { get; set; }
        public string Instructor_Email { get; set; }
        public string Instructor_Phone { get; set; }

        public string Course_Date => $"{Course_Start.ToString("M")} - {Course_End.ToString("M")}";


    }
}
