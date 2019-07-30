using AutoMapper;
using FindMyTutor.Data.Models;
using FindMyTutor.Data.Services.DTO;
using FindMyTutor.Web.Areas.Admin.Models.Reports;
using FindMyTutor.Web.ViewModels.Offers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FindMyTutor.Web.Areas.Admin.Models.Profiles
{
    public class ReportProfile : Profile
    {
        public ReportProfile()
        {
            CreateMap<ReportDTO, FindMyTutor.Data.Models.Report>()
                .ForMember(dest => dest.ResourceCreatorId,
                opt => opt.MapFrom(
                    src => src.CreatorId));

            CreateMap<ReportOfferViewModel, ReportedOfferDTO>();

            CreateMap<FindMyTutor.Data.Models.ReportedOffer, ReportViewModel>();

            CreateMap<FindMyTutor.Data.Models.ReportedComment, ReportedCommentDTO>();

            //CreateMap<FindMyTutor.Data.Models.Report, ReportCommentViewModel>()
            //    .ForMember(dest => dest.ResourceId, opt => opt.MapFrom(src => src.ResourceId));


            CreateMap<ReportedCommentDTO, ReportedComment>();
            CreateMap<ReportedOfferDTO, ReportedOffer>();



        }
    }
}
