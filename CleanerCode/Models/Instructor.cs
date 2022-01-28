using System;
using System.Collections.Generic;
using System.Text;

namespace CleanerCode.Models
{
    public class Instructor
    {
        public int Instructor_Id { get; set; }
        public string Instructor_Name { get; set; }
        public string Instructor_Email { get; set; }
        public string Instructor_Phone { get; set; }

        public Instructor(string Instructor_Name, string Instructor_Email, string Instructor_Phone)
        {
            this.Instructor_Name = Instructor_Name;
            this.Instructor_Email = Instructor_Email;
            this.Instructor_Phone=Instructor_Phone;
        }
    }
}
