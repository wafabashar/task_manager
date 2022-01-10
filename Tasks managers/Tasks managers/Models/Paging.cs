using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tasks_managers.Models
{
    public class Paging
    {
        public int TotalItems { get; set; }
        public int Currentpage { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public int StartPage { get; set; }

        public int EndPage { get; set; }

        public Paging()
        {

        }

        public Paging(int totalitems,int page,int pagesize=10)
        {
            int totalpages = (int)Math.Ceiling((decimal)totalitems / (decimal)pagesize);
            int currentpage = page;

            int startpage = currentpage - 2;
            int endpage = currentpage + 1;

            if (startpage <= 0)
            {
                endpage = endpage - (startpage - 1);
                startpage = 1;
            }

            if (endpage > totalpages)
            {
                endpage = totalpages;
                if (endpage > 10)
                {
                    startpage = endpage - 9;
                }
            }

            TotalItems = totalitems;
            Currentpage = currentpage;
            PageSize = pagesize;
            TotalPages = totalpages;
            StartPage = startpage;
            EndPage = endpage;

        }
    }
}
