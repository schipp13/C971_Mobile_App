using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace LocalDatabaseTutorial.Models
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
