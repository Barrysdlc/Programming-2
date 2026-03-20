using AppUsersAPI.Domain.Entities;
using AppUsersAPI.Domain.Repository;
using AppUsersAPI.Infrastructure.Data;
using AppUsersAPI.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace AppUsersAPI.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _app;

        public UserRepository(AppDbContext app)
        {
            _app = app;
        }

        public async Task AddUser(Users user)
        {
            var newUser = new UsersModel
            {
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                Password = user.Password,
                Address = user.Address
            };

            await _app.Users.AddAsync(newUser);
            await SAVE();
        }

        public async Task UpdateUser(Users newUser, int id)
        {
            var user = await _app.Users.Where(u => u.Id == id).FirstOrDefaultAsync();

            if (user is null)
            {
                return;
            }

            user.Name = newUser.Name ?? user.Name;
            user.Email = newUser.Email ?? user.Email;
            user.Phone = newUser.Phone ?? user.Phone;
            user.Password = newUser.Password ?? user.Password;
            user.Address = newUser.Address ?? user.Address;

            await SAVE();
        }

        public async Task<IEnumerable<Users>> GetUsers()
        {
            var users = await _app.Users.AsTracking().ToListAsync();

            return users.Select(u => new Users
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                Phone = u.Phone,
                Password = u.Password,
                Address = u.Address
            }).ToList();
        }

        public async Task<Users> GetUser(int id)
        {
            var user = await _app.Users
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();

            if (user is null)
            {
                Console.WriteLine("User not found");
                return null!;
            }

            var userEntity = new Users
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                Password = user.Password,
                Address = user.Address
            };

            return userEntity;
        }

        public async Task DeleteUser(int id)
        {
            var user = await _app.Users.FindAsync(id);

            if (user is null)
            {
                return;
            }

            _app.Users.Remove(user);
            await SAVE();
        }

        public async Task SAVE()
        {
            await _app.SaveChangesAsync();
        }
    }
}