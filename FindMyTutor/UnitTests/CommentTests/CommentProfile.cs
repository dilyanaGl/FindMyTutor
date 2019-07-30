using AutoMapper;
using FindMyTutor.Data.Models;
using FindMyTutor.Data.Services.DTO;

namespace UnitTests.CommentTests
{
    internal class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<CommentDTO, Comment>();
        }
    }
}