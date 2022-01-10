using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasks_managers.data;

namespace Tasks_managers.Models
{
    public class vmtask
    {
        public task task { set; get; }
        public List<task> litask { get; set; }
        public List<project> liproject { get; set; }
        public List<user> liuser { get; set; }
    }
}
