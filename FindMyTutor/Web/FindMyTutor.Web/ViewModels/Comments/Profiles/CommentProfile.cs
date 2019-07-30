using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FindMyTutor.Data.Services.DTO;
using FindMyTutor.Data.Models;

namespace FindMyTutor.Web.ViewModels.Comments.Profiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<AddCommentViewModel, CommentDTO>();
            CreateMap<CommentDTO, Comment>();
            CreateMap<Comment, CommentViewModel>();
            CreateMap<CommentReportViewModel, ReportedCommentDTO>();
        }
    }
}
