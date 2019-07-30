using AutoMapper;
using FindMyTutor.Data.Services.DTO;
using FindMyTutor.Web.ViewModels.Message;
using FindMyTutor.Data.Models;

namespace FindMyTutor.Web.ViewModels.Messages.Profiles
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<CreateMessageViewModel, MessageDTO>()
                .ForMember(dest => dest.OfferId, opt => opt.MapFrom(src => src.OfferId));

            CreateMap<MessageDTO, Data.Models.Message>();

            CreateMap<Data.Models.Message, MessageViewModel>();

            CreateMap<MailMessageDTO, SenderViewModel>();

            
        }
    }
}
