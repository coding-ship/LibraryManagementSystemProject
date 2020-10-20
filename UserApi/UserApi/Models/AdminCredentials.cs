using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserApi.Models
{
    public class AdminCredentials
    {
        public int Id { get; set; }
        [Required]
        public int User_Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string password { get; set; }
    }
}
