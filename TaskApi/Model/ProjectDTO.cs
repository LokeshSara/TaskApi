using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskApi.Model
{
    public class ProjectDTO
    {
        public int ProjectId { get; set; }
        public string ProjectDesc { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Priority { get; set; }
    }

    public class ProjectSearchOptions
    {
        public string SearchKey { get; set; }
    }
}
