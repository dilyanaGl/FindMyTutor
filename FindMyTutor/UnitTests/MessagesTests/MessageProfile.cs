using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using FindMyTutor.Data.Models;
using FindMyTutor.Data.Services.DTO;

namespace UnitTests.MessagesTests
{
    class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<MessageDTO, Message>();
        }
    }
}
