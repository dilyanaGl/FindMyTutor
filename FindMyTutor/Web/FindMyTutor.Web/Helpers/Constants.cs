using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindMyTutor.Web.Helpers
{
    public static class Constants
    {
        public static string[] ButtonStyles = new string[]
        {
            "btn btn-primary"  ,
            "btn btn-secondary",
            "btn btn-success",
            "btn btn-danger",
            "btn btn-warning",
            "btn btn-info",
            "btn btn-light",
            "btn btn-dark"

        };

        public static class Role
        {
            public const string Tutor = "Tutor";
            public const string Admin = "Admin";
            public const string Creator = "Creator";
        }

        public static class Policy
        {
            public const string CheckRolePermission = "CheckRolePermission";
            public const string MessageRequirement = "MustBeSenderOrReceiver";
            public const string MustBeTutor = "MustBeTutor";
            public const string MustBeCreator = "MustBeCreator";
            public const string MessageType = "Message";
            public const string CreatorType = "Creator";
            public const string RoleType = "Role";


        }

        public static class Path
        {
            public const string AccessDeniedPath = "/Identity/Account/AccessDenied";
        }

      public static class Message
        {
            public const string InvalidOffer = "Невалидна оферта";
            public const string SuccessfulMessage = "Съобщението беше изпратено успешно";
            public const string SuccessfulReport = "Докладването беше изпратено успешно на администраторите.";
            public const string SuccessfulComment = "Успешно коментирахте оферта.";
 

        }

        public static class Notifications
        {
            public const string AddedAComment = "Вашата оферта беше коментирана.";
            public const string ReportedYourOffer = "Потребител докладва вашата оферта.";
            public const string ReportedYourComment = "Потребител докладва вашия коментар.";
            public const string AdminDeletedYourOffer = "Администраторът изтри Вашата оферта.";      
            public const string AdminDeletedYourComment = "Администраторът изтри Вашият коментар.";
        }
    }
}
