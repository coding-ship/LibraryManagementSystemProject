using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserApi.Models
{
    public class Usercredentials
    {
        public int Id { get; set; }

        [Required]
        public int User_Id { get; set; }
        [Required]
        public string User_Name { get; set; }

        [Required]
        public string Password { get; set; }

        public int Age { get; set; }
        public string Address { get; set; }
        public string Phone_no { get; set; }
    }
}
