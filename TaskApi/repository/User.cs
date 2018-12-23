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

        public void AddUser(Entity.User usr)
        {
            _context.Add(usr);
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var usr = _context.Users.Where(a => a.UserId == id).FirstOrDefault();
            _context.Remove(usr);
            _context.SaveChanges();
        }

        public List<UserDTO> GetAllUsers()
        {
            var users = _context.Users.ToList().Select(t => new UserDTO
            {
                UserId = t.UserId,
                EmployeeId = t.EmployeeId,
                FirstName = t.FirstName,
                LastName = t.LastName
            });

            return users.ToList();
        }

        public UserDTO GetUserById(int id)
        {
            var user = _context.Users.ToList().Where(t => t.UserId == id).
               Select(t => new UserDTO
               {
                   UserId = t.UserId,
                   EmployeeId = t.EmployeeId,
                   FirstName = t.FirstName,
                   LastName = t.LastName
               });



            return user.FirstOrDefault();
        }

        public List<UserDTO> SerachUser(UserSearchOption optn)
        {
            var items = _context.Users.Where(s => s.FirstName.Contains(optn.SearchKey));

            var result = items.Select(t => new UserDTO
            {
                EmployeeId = t.EmployeeId,
                FirstName = t.FirstName,
                LastName = t.LastName
            });

            return result.ToList();
        }

        public void UpdateUser(Entity.User usr)
        {
            _context.Update(usr);
            _context.SaveChanges();
        }
    }
}
