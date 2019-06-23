using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using FindMyTutor.Data.Models;
using FindMyTutor.Common;
using FindMyTutor.Data.Services.DTO;

namespace FindMyTutor.Data.Services.Comments
{
    public class CommentService : ICommentService
    {
        private readonly IRepository<Comment> comments;

        public CommentService(IRepository<Comment> comments)
        {
            this.comments = comments;
        }

        public void AddComment(CommentDTO commentDTO)
        {
            
        }

        public IEnumerable<Comment> GetAllCommentsForOffer(int offerId)
        {
            return this.comments.All()
                .Where(p => p.OfferId == offerId)
                .ToArray(); 
            
        }

        public void RemoveComment(int commentId)
        {
            var comment = this.comments.All().FirstOrDefault(p => p.Id == commentId);
            this.comments.Remove(comment);
        }
    }
}
