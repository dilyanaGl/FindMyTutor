using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using FindMyTutor.Data.Models;
using FindMyTutor.Common;
using FindMyTutor.Data.Services.DTO;
using System.Threading.Tasks;
using AutoMapper;

namespace FindMyTutor.Data.Services.Comments
{
    public class CommentService : ICommentService
    {
        private readonly IRepository<Comment> comments;
        private readonly IMapper mapper;

        public CommentService(IRepository<Comment> comments, IMapper mapper)
        {
            this.comments = comments;
            this.mapper = mapper;
        }

        public async Task<int> AddComment(CommentDTO commentDTO)
        {
            var comment = mapper.Map<CommentDTO, Comment>(commentDTO);
           await this.comments.Add(comment);

           return await this.comments.SaveChangesAsync();
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
