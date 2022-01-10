using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasks_managers.data;

namespace Tasks_managers.Service
{
   public interface ITaskService
    {
        List<user> LoadAllUsers();
        List<project> LoadAllprojects();

        List<task> LoadAlltasks();

        

        List<task> Searchbyname(string name);

        List<task> Searchbyproject(int val);
        List<task> Searchbyuser(int val);

        List<task> compltedtask();

        List<task> uncompltedtask();


    }
}
