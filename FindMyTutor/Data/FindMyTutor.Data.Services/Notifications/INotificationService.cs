using FindMyTutor.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FindMyTutor.Data.Services.Notifications
{
    public interface INotificationService
    {
        Task<IEnumerable<Notification>> GetUnread(string userId);

        IEnumerable<Notification> GetRead(string userId);

        Task<int> Add(Notification notification);
    }
}
