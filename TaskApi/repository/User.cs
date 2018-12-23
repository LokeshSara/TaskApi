using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskApi.Entity;
using TaskApi.Model;

namespace TaskApi.repository
{
    public class User : IUserRepository
    {

        private TaskDBContext _context;

        public User(TaskDBContext context)
        {
            _context = context;
        }

        public void AddUser(Entity.User tsk)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public List<UserDTO> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public UserDTO GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public List<UserDTO> SerachUser(UserSearchOption optn)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(Entity.User usr)
        {
            throw new NotImplementedException();
        }
    }
}
