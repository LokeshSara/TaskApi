using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskApi.Model;

namespace TaskApi.repository
{
    public interface IUserRepository
    {
        List<UserDTO> GetAllUsers();

        UserDTO GetUserById(int id);

        List<UserDTO> SerachUser(UserSearchOption optn);

        void UpdateUser(Entity.User usr);

        void DeleteUser(int id);

        void AddUser(Entity.User tsk);
    }
}
