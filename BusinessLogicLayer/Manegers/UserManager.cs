using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using OpenQA.Selenium;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface IUserManager
    {
        Task<UserResource> GetByIdAsync(int id);
        Task<UserResource> AddAsync(UserDTO userDto);
        Task<UserResource> UpdateAsync(UserDTO userDto);
        Task DeleteAsync(int id);
    }
    public class UserManager : IUserManager
    {
        private readonly AppDbContext db_context;

        public UserManager(AppDbContext context)
        {
            db_context = context;
        }

        public async Task<UserResource> GetByIdAsync(int id)
        {
            var user = await db_context.Users.FindAsync(id);
            if (user == null)
            {
                return null;
            }

            return user.ToUserResource(); // Use mapper to convert to resource
        }

        public async Task<UserResource> AddAsync(UserDTO userDto)
        {
            var user = userDto.ToUserEntity(); // Use mapper to convert DTO to entity

            await db_context.Users.AddAsync(user);
            await db_context.SaveChangesAsync();

            return user.ToUserResource(); // Use mapper to convert to resource
        }

        public async Task<UserResource> UpdateAsync(UserDTO userDto)
        {
            var user = await db_context.Users.FindAsync(userDto.Id);
            if (user == null)
            {
                throw new NotFoundException("User not found!");
            }

            userDto.UpdateUserEntity(user); // Use mapper to update the existing entity

            db_context.Users.Update(user);
            await db_context.SaveChangesAsync();

            return user.ToUserResource(); // Use mapper to convert to resource
        }

        public async Task DeleteAsync(int id)
        {
            var user = await db_context.Users.FindAsync(id);
            if (user == null)
            {
                throw new NotFoundException("User not found!");
            }

            db_context.Users.Remove(user);
            await db_context.SaveChangesAsync();
        }
    }
}

