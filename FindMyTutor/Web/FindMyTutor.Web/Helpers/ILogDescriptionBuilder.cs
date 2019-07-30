using FindMyTutor.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindMyTutor.Web.Helpers
{
    public interface ILogDescriptionBuilder
    {
        string BuildDescription(LogType logType);
        
    }
}
