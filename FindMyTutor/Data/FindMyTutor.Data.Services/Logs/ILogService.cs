using FindMyTutor.Data.Models;
using FindMyTutor.Data.Services.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FindMyTutor.Data.Services.Logs
{
    public interface ILogService
    {
        IEnumerable<Log> GetAllLogs();

        Task<int> AddLog(Log dto);
    }
}
