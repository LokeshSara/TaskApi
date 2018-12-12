using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskApi.Entity
{
    public class TaskDBContext : DbContext
    {
        DbSet<Task> Tasks { get; set; }

        DbSet<ParentTask> ParentTask { get; set; }
    }
}
