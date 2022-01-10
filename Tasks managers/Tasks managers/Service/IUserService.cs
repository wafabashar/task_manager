using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasks_managers.data;

namespace Tasks_managers.Service
{
  public  interface IUserService
    {
        user Checkuser(string name,string pass);
    }
}
