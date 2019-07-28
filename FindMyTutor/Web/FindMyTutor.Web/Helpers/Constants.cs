using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindMyTutor.Web.Helpers
{
    public static class Constants
    {
        public static string[] Styles = new string[]
        {
            "success",
            "warning",
            "danger"

        };

        public static class Area
        {
            public const string Admin = "Admin";
        }

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

            public const string SuccessfulOfferDelete = "Успешно изтрихте оферта.";

            public static class OfferUpdate
            {
                public const string Success = "Успешно редактирахте оферта.";
                public const string Fail = "Промените не бяха запазени. Моля, опитайте отново.";
            }

            public static class OfferDelete
            {
                public const string Success = "Успешно изтрихте оферта.";
                public const string Fail = "Промените не бяха запазени. Моля, опитайте отново.";
            }


        }

        public static class ValidationState
        {
            public const string Error = "Error";
            public const string Success = "Success";
            public const string InvalidOffer = "InvalidOffer";
            public const string InvalidComment = "InvalidComment";

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
