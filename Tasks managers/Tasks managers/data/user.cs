using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tasks_managers.data
{
    [Table("users")]
    public class user
    {

        public int id { get; set; }

        [Required]
        public string first_name { get; set; }

        [Required]
        public string last_name { get; set; }

        [Required]
        public string username { get; set; }

        [Required]
        
        [NotMapped]
        [DataType(DataType.Password)]
        public string ENCPassword { set; get; }
        public string password { get; set; }

        [EmailAddress]
        [Required]
        public string email { get; set; }

        public DateTime? last_login { get; set; }

        List<task> litask { set; get; }
    }
}
