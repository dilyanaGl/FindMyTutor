using System;
using System.Collections.Generic;
using System.Text;
using FindMyTutor.Data.Models;

namespace FindMyTutor.Data.Services.Comments
{
    using DTO;

    public interface ICommentService
    {
        IEnumerable<Comment> GetAllCommentsForOffer(int offerId);

        void RemoveComment(int commentId);

        void AddComment(CommentDTO commentDTO);



    }
}
