using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasks_managers.data;

namespace Tasks_managers.Service
{
    public class TaskService : ITaskService
    {

        Tasks_managers_Context context;

        public TaskService(Tasks_managers_Context _context)
        {
            context = _context;
        }

       

     
        public List<project> LoadAllprojects()
        {
            List<project> liproject = context.project.ToList();
            return liproject;
        }

        public List<task> LoadAlltasks()
        {
            List<task> litask = context.task.Include("User").Include("Propject").ToList();
            return litask;
        }

        public List<user> LoadAllUsers()
        {
            List<user> liuser = context.user.ToList();
            return liuser;
        }

        public List<task> Searchbyname(string name)
        {
            List<task> ta = context.task.Where(t => t.Task == name).Include("User").Include("Propject").ToList();
            return ta;
        }

        public List<task> Searchbyproject(int val)
        {
            List<task> ta = context.task.Where(t => t.project_id == val).Include("User").Include("Propject").ToList();
            return ta;
        }

        public List<task> Searchbyuser(int val)
        {
            List<task> ta = context.task.Where(t => t.added_by == val).Include("User").Include("Propject").ToList();
            return ta;
        }

        public List<task> compltedtask()
        {
            List<task> ta = context.task.Where(t => t.completed == true).Include("User").Include("Propject").ToList();
            return ta;
        }

        public List<task> uncompltedtask()
        {
            List<task> ta = context.task.Where(t => t.completed ==false).Include("User").Include("Propject").ToList();
            return ta;
        }
    }
}
