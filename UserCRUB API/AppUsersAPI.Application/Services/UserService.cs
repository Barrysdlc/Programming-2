using AppUsersAPI.Domain.Entities;
using AppUsersAPI.Domain.Repository;
using System;

namespace AppUsersAPI.Application.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task AddUser(Users user)
        {
            await _repo.AddUser(user);
            
        }

        public async Task UpdateUser(Users newUser, int id)
        {
            await _repo.UpdateUser(newUser, id);

            
        }

        public async Task<IEnumerable<Users>> GetUsers()
        {
            var users = await _repo.GetUsers();
            return users;
        }

        public async Task<Users> GetUser(int id)
        {
            var user = await _repo.GetUser(id);
            
            return user;
        }

        public async Task DeleteUser(int id)
        {
           await _repo.DeleteUser(id);
        }

        
    }
}
