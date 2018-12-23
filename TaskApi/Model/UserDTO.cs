using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskApi.Model
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public int TaskId { get; set; }
    }

    public class UserSearchOption
    {
        public string SearchKey { get; set; }
    }
}
