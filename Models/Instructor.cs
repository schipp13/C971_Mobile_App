using System;
using SQLite;
using System.Collections.Generic;
using System.Text;

namespace c971_MobileApplication.Models
{
    public class Instructor
    {
        [PrimaryKey, AutoIncrement]
        public int Instructor_Id { get; set; }
        public string Instructor_Name { get; set; }
        public string Instructor_Email { get; set; }
        public string Instructor_Phone { get; set; }

      
    }
}
