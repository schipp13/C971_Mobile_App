using System;
using System.Collections.Generic;
using System.Text;

namespace CleanerCode.Models
{
    public class Assessment
    {
        public int Assessment_Id { get; set; }
        public string Assessment_Name { get; set; }
        public string Assessment_Type { get; set; }
        public DateTime Assessment_Start { get; set; }
        public DateTime Assessment_End { get; set; }

        public Assessment(string Assessment_Name, string Assessment_Type, DateTime Assessment_Start, DateTime Assessment_End)
        {
            this.Assessment_Name = Assessment_Name;
            this.Assessment_Type = Assessment_Type;
            this.Assessment_Start = Assessment_Start;
            this.Assessment_End = Assessment_End;
        }
    }
}
