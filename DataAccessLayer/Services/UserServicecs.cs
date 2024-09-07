using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerSchool.Services
{
    public interface IUserService
    {
        Task<User> GetByIdAsync(int id);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
    }

    public class UserService : IUserService
    {
        private readonly AppDbContext db_context;

        public UserService(AppDbContext context)
        {
            db_context = context;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await db_context.Users.FindAsync(id);
        }

        public async Task AddAsync(User user)
        {
            await db_context.Users.AddAsync(user);
            await db_context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            db_context.Users.Update(user);
            await db_context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await db_context.Users.FindAsync(id);
            if (user != null)
            {
                db_context.Users.Remove(user);
                await db_context.SaveChangesAsync();
            }
        }
    }
}