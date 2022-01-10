using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasks_managers.Models;
using Tasks_managers.Service;

namespace Tasks_managers.Controllers
{
    public class TaskController : Controller
    {
        ITaskService task;

        public TaskController(ITaskService _task)
        {

            task = _task;

        }
        public IActionResult Load_Tasks(int p=1)
        {
            vmtask vm = new vmtask();
            vm.liproject = task.LoadAllprojects();
            vm.liuser = task.LoadAllUsers();
            vm.litask = task.LoadAlltasks();
           
            

            const int pageSize = 10;
            if (p < 1)
            {
                p = 1;
            }

            int res = vm.litask.Count();

            var paging = new Paging(res, p, pageSize);

            int resSkip = (p - 1) * pageSize;

            var data = vm.litask.Skip(resSkip).Take(paging.PageSize).ToList();

            ViewBag.paging = paging;
            vm.litask = data;

            return View("Tasks",vm);
        }


        //public IActionResult Edit(int id)
        //{
            
        //    task.find_task(id);
        //    return RedirectToAction("Load_Tasks", "Task");
        //}

        public IActionResult Search()
        {
            vmtask vm = new vmtask();
            vm.liproject = task.LoadAllprojects();
            vm.liuser = task.LoadAllUsers();
            string name = Request.Form["Searchtxt"];
            int pro = Convert.ToInt32( Request.Form["ddlp"]);
            int us =Convert.ToInt32( Request.Form["ddlu"]);
            string comp = Request.Form["completedcheck"];
        

            if (name != "")
            {
                vm.litask = task.Searchbyname(name);
            }
            else if (pro != 0)
            {
                vm.litask = task.Searchbyproject(pro);
            }
            else if(us != 0)
            {
                vm.litask = task.Searchbyuser(us);
            }
            else if (comp == "All")
            {
                
                vm.litask = task.LoadAlltasks();
            }
            else if (comp == "Yes")
            {
                vm.litask = task.compltedtask();
            }
            else if(comp == "No")
            {
                vm.litask = task.uncompltedtask();
            }

           
            return View("Tasks", vm);


        }
    }
}
