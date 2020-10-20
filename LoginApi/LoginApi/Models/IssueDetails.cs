using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginApi.Models
{
    public class IssueDetails
    {
        public int Id { get; set; }

        public int Book_Id { get; set; }
        public string Book_Name { get; set; }
        public string Book_Author { get; set; }

        public int User_Id { get; set; }
        public string User_Name { get; set; }
        public string Phone_Number { get; set; }
        public string Issue_Date { get; set; }
    }
}
