using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tasks_managers.data
{
    [Table("projects")]
    public class project
    {
        public int id { get; set; }

        [Required]
        public string project_name { get; set; }

        List<task> litask { set; get; }
    }
}
