using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FindMyTutor.Data.Models;
using FindMyTutor.Data.Services.Notifications;
using FindMyTutor.Web.ViewModels.Notifications;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FindMyTutor.Web.Controllers
{
    public class NotificationsController : Controller
    {
        private readonly INotificationService notificationService;
        private readonly UserManager<FindMyTutorUser> userManager;
        private readonly IMapper mapper;

        public NotificationsController(INotificationService notificationService, UserManager<FindMyTutorUser> userManager, IMapper mapper)
        {
            this.notificationService = notificationService;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public IActionResult All()
        {
            var userId = this.userManager.GetUserId(HttpContext.User);
            var notifications = this.notificationService.GetUnread(userId)
                .Result
                .Select(p =>
                {
                    var model = mapper.Map<Notification, NotificationViewModel>(p);
                    return model;
                });
            return View(notifications);
        }
    }
}