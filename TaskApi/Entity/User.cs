using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskApi.Entity
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public int TaskId { get; set; }
    }
}
