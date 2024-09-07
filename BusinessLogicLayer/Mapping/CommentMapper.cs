using BusinessLogicLayer.Resources;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Mapping
{
    public static class CommentMapper
    {
        //public static CommentDTO ToCommentDTO(this Comment commentModel)
        //{
        //    return new CommentDTO
        //    {
        //        Id = commentModel.Id,
        //        CommentText = commentModel.CommentText

        //    };
        //}

        public static Comment ToCommentEntity(this CommentDTO commentDto)
        {
            return new Comment
            {
                TicketId = commentDto.TicketId,
                CommentText = commentDto.CommentText

            };
        }

        public static void ToCommentEntity(this CommentDTO commentDto, Comment comment)
        {
            comment.TicketId = commentDto.TicketId;
            comment.CommentText = commentDto.CommentText;

        }

        public static CommentResource ToCommentResource(this Comment comment)
        {
            return new CommentResource
            {
                Id = comment.Id,
                TicketId = comment.TicketId,
                CommentText = comment.CommentText
            };
        }
    }

}
