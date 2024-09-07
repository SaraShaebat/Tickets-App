using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayerSchool.Services
{
    public interface ICommentService
    {
        Task<Comment> GetByIdAsync(int id);
        Task AddAsync(Comment comment);
        Task UpdateAsync(Comment comment);
        Task DeleteAsync(int id);
    }

    public class CommentService : ICommentService
    {
        private readonly AppDbContext db_context;

        public CommentService(AppDbContext context)
        {
            db_context = context;
        }

        public async Task<Comment> GetByIdAsync(int id)
        {
            return await db_context.Comments.FindAsync(id);
        }

        public async Task AddAsync(Comment comment)
        {
            await db_context.Comments.AddAsync(comment);
            await db_context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Comment comment)
        {
            db_context.Comments.Update(comment);
            await db_context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var comment = await db_context.Comments.FindAsync(id);
            if (comment != null)
            {
                db_context.Comments.Remove(comment);
                await db_context.SaveChangesAsync();
            }
        }
    }
}
