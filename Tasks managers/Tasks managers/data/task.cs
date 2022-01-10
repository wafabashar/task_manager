using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Tasks_managers.data
{
    [Table("tasks")]
    public class task
    {

        public int id { get; set; }

        [Required]
        public string Task { get; set; }

        public DateTime added_date { get; set; }

        [Required]
        public bool completed { set; get; }

        [ForeignKey("User")]
        [Required]
        public int added_by { get; set; }
        public user User { set; get; }

        [ForeignKey("Propject")]
        [Required]
        public int project_id { get; set; }
        public project Propject { set; get; }

    }
}
