using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using SQLite;

namespace LocalDatabaseTutorial.Models
{
    [Table("Courses")]
    public class Course
    {

        [PrimaryKey, AutoIncrement]
        public int Course_Id { get; set; }
        public int Instructor_Id { get; set; }
        public int Assessment_Id { get; set; }
        public string Course_Name { get; set; }
        public string Course_Status { get; set; }
        public DateTime Course_Start { get; set; }
        public DateTime Course_End { get; set; }
        public string Course_Description { get; set; }
        public string Course_Notes { get; set; }
    
        public string Course_Date => ($"{Course_Start.ToString("M")} - {Course_End.ToString("M")}");
    }
}
