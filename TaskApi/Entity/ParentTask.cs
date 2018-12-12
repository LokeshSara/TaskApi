using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskApi.Entity
{
    public class ParentTask
    {
        public int TaskId { get; set; }
        public int ParentId { get; set; }
    }
}
