using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskApi.Entity
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }

        public int ParentId { get; set; }
        public string TaskDesc { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Priority { get; set; }
        public int ProjectId { get; set; }
        public int Status { get; set; }


    }
}
