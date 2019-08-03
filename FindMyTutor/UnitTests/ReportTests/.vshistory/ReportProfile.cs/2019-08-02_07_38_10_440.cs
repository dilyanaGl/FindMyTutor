using AutoMapper;
using FindMyTutor.Data.Models;
using FindMyTutor.Data.Services.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.ReportTests
{
    public class ReportProfile : Profile
    {
        public ReportProfile()
        {
            CreateMap<ReportDTO, Report>();
        }
    }
}
