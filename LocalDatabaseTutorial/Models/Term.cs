using System;
using SQLite;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace c971_MobileApplication.Models
{
    public class Term
    {
        [PrimaryKey, AutoIncrement]
        public int Term_Id { get; set; }
        public string Term_Name { get; set; }
        public DateTime Term_Start { get; set; }
        public DateTime Term_End { get; set; }
      /*  public ObservableCollection<Course> CourseList { get; set; }*/
       
    }
}
