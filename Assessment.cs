using System;

namespace C971_MobileApp
{
    public class Assessment
    {
        public int assessment_id { get; set; }
        public string assessment_type { get; set; }
        public string assessment_name { get; set; }
        public DateTime assessment_start { get; set; }
        public DateTime assessment_end { get; set; }

        public Assessment(int assessment_id, string assessment_type, string assessment_name, DateTime assessment_start
               , DateTime assessment_end)
        {
            this.assessment_id = assessment_id;
            this.assessment_type = assessment_type;
            this.assessment_name = assessment_name;
            this.assessment_start = assessment_start;
            this.assessment_end = assessment_end;

        }

    }
}
