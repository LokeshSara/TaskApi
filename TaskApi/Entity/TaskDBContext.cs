using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskApi.Entity
{
    public class TaskDBContext : DbContext
    {
        public TaskDBContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
   
    }
}
