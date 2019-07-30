using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using FindMyTutor.Common;
using FindMyTutor.Data.Models;

namespace FindMyTutor.Data.Services.Notifications
{
    public class NotificationService : INotificationService
    {
        private readonly IRepository<Notification> notifications;

        public NotificationService(IRepository<Notification> notifications)
        {
            this.notifications = notifications;
        }

        public async Task<int> Add(Notification notification)
        {
            await this.notifications.Add(notification);
            return await this.notifications.SaveChangesAsync();
        }

        public async Task<IEnumerable<Notification>> GetUnread(string userId)
        {
           var notifications = this.notifications.All()
                .Where(p => p.NotificationRecipientId == userId && !p.IsSeen)
                .ToArray();

            foreach (var notification in notifications)
            {
                notification.IsSeen = true;
            }

            await this.notifications.SaveChangesAsync();

            return notifications;
        }


        public IEnumerable<Notification> GetRead(string userId)
        {
            return this.notifications.All()
                .Where(p => p.NotificationRecipientId == userId && p.IsSeen)
                .ToArray();
        }
    }
}
