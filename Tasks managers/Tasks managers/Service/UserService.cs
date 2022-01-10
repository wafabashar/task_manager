using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasks_managers.data;

namespace Tasks_managers.Service
{
    public class UserService : IUserService
    {
        Tasks_managers_Context context;
        public UserService(Tasks_managers_Context _context)
        {
            context = _context;
        }

        public user Checkuser(string name,string pass)
        {
            user userr = context.user.Where(u => u.email == name && u.password == pass).FirstOrDefault();
            
            return userr;
        
        }
    }
}
