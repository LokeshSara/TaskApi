using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskApi.Entity
{
    public class ParentTask
    {
        [Key]
        public int ParentId { get; set; }
        public string ParentTaskDesc { get; set; }

        public virtual Task Tasks { get; set; }
    }
}
