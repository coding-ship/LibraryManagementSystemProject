using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApi.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public int Book_Id { get; set; }
        public string Book_Name { get; set; }
        public string Author { get; set; }
        public string Language { get; set; }
        public int No_of_pages { get; set; }
        public int Price { get; set; }
    }
}
