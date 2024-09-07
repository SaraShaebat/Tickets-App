using BusinessLogicLayer.Mapping;
using BusinessLogicLayer.Resources;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface ICommentManager
    {
        Task<CommentResource> GetByIdAsync(int id);
        Task<CommentResource> AddAsync(CommentDTO commentDto);
        Task<CommentResource> UpdateAsync(CommentDTO commentDto);
        Task DeleteAsync(int id);
    }

    public class CommentManager : ICommentManager
    {
        private readonly AppDbContext db_context;

        public CommentManager(AppDbContext context)
        {
            db_context = context;
        }

        public async Task<CommentResource> GetByIdAsync(int id)
        {
            var comment = await db_context.Comments.FindAsync(id);

            if (comment == null)
            {
                return null;
            }

            return comment.ToCommentResource();
        }

        public async Task<CommentResource> AddAsync(CommentDTO commentDto)
        {
            var comment = commentDto.ToCommentEntity(); // Using a mapping method to map DTO to entity

            await db_context.Comments.AddAsync(comment);
            await db_context.SaveChangesAsync();

            return comment.ToCommentResource(); // Mapping entity to resource
        }

        public async Task<CommentResource> UpdateAsync(CommentDTO commentDto)
        {
            var comment = await db_context.Comments.FindAsync(commentDto.Id);

            if (comment == null)
            {
                throw new NotFoundException("Comment not found!");
            }

            // Mapping DTO to the existing entity
            commentDto.ToCommentEntity(comment);

            db_context.Comments.Update(comment);
            await db_context.SaveChangesAsync();

            return comment.ToCommentResource(); // Mapping entity to resource
        }

        public async Task DeleteAsync(int id)
        {
            var comment = await db_context.Comments.FindAsync(id);

            if (comment == null)
            {
                throw new NotFoundException("Comment not found!");
            }

            db_context.Comments.Remove(comment);
            await db_context.SaveChangesAsync();
        }
    }
}
