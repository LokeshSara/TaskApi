using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskApi.Model
{
    public class TaskDTO
    {
        public int TaskId { get; set; }
        public int? ParentId { get; set; }
        public string ParentDesc { get; set; }
        public string TaskDesc { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Priority { get; set; }
    }
}
