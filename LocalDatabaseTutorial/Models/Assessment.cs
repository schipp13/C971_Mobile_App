using System;
using System.Collections.Generic;
using SQLite;
using System.Text;


namespace LocalDatabaseTutorial.Models
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
