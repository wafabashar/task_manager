using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Tasks_managers.data
{
    public class Tasks_managers_Context:DbContext
    {
        IConfiguration configuration;

        public Tasks_managers_Context(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public Tasks_managers_Context()
        {
            
        }


        public DbSet<user> user { set; get; }

        public DbSet<project> project { set; get; }

        public DbSet<task> task { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("taskconnectionstring"));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
