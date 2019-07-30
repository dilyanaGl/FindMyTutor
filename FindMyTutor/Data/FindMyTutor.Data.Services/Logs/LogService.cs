using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using FindMyTutor.Common;
using FindMyTutor.Data.Models;
using System.Threading.Tasks;
using FindMyTutor.Data.Services.DTO;
using AutoMapper;

namespace FindMyTutor.Data.Services.Logs
{
    public class LogService : ILogService
    {
        private readonly IRepository<Log> logs;
    

        public LogService(IRepository<Log> logs)
        {
            this.logs = logs;
           
        }

        public async Task<int> AddLog(Log log)
        {
           
            await this.logs.Add(log);

            return await this.logs.SaveChangesAsync();
        }

        public IEnumerable<Log> GetAllLogs()
        {
            return this.logs.All().ToList();
        }
    }
}
