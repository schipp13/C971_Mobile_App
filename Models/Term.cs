using System;
using SQLite;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace c971_MobileApplication.Models
{
    [Table("Terms")]
    public class Term
    {
        [PrimaryKey, AutoIncrement]
        public int Term_Id { get; set; }
        public string Term_Name { get; set; }
        public DateTime Term_Start { get; set; }
        public DateTime Term_End { get; set; }

        public string Term_Date => ($"{Term_Start.ToString("M")} - {Term_End.ToString("M")}");

    }
}
