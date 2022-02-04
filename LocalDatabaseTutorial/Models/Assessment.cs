using System;
using SQLite;
using System.Collections.Generic;
using System.Text;

namespace c971_MobileApplication.Models
{
    public class Assessment
    {
        [PrimaryKey, AutoIncrement]
        public int Assessment_Id { get; set; }
        public int Course_Id { get; set; }
        public string Assessment_Name { get; set; }
        public string Assessment_Type { get; set; }
        public DateTime Assessment_Start { get; set; }
        public DateTime Assessment_End { get; set; }

      
    }
}
