using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskApi.Model
{
    public class ParentTaskDTO
    {
        public int ParentId { get; set; }
        public string ParentTaskDesc { get; set; }  
    }
}
