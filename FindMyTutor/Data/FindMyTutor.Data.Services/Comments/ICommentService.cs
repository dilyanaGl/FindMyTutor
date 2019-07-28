using System;
using System.Collections.Generic;
using System.Text;
using FindMyTutor.Data.Models;

namespace FindMyTutor.Data.Services.Comments
{
    using DTO;
    using System.Threading.Tasks;

    public interface ICommentService
    {
        IEnumerable<Comment> GetAllCommentsForOffer(int offerId);

        void RemoveComment(int commentId);

        Task<int> AddComment(CommentDTO commentDTO);

        int GetOfferIdByCommentId(int commentId);

        string GetCommentAuthorId(int commentId);



    }
}
