using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CleanerCode.Models
{
    public class Term
    {
        public int Term_Id { get; set; }
        public string Term_Name { get; set;}
        public DateTime Term_Start { get; set; }
        public DateTime Term_End { get; set; }        
        public ObservableCollection<Course> CourseList { get; set;}
        public Term(int Term_Id, string Term_Name, DateTime Term_Start, DateTime Term_End, ObservableCollection<Course> CourseList)
        {
            this.Term_Id = Term_Id;
            this.Term_Name = Term_Name;
            this.Term_Start = Term_Start;
            this.Term_End = Term_End;   
            this.CourseList = CourseList;
        }
    }
}
