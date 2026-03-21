using AppUsersAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppUsersAPI.Domain.Repository
{
    public interface IUserService
    {
        Task<IEnumerable<Users>> GetUsers();
        Task<Users> GetUser(int id);
        Task AddUser(Users user);
        Task UpdateUser(Users user, int id);
        Task DeleteUser(int id);
    }
}
