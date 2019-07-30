using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FindMyTutor.Data.Models;

namespace FindMyTutor.Web.Helpers
{
    public class DescriptionBuilder : ILogDescriptionBuilder
    {
        public string BuildDescription(LogType logType)
        {
            // use Reflection to access the description attribute of the enumeration

            //get all MemberInfo[] of the LogType Enumeration
            MemberInfo[] memberInfos = typeof(LogType).GetMember(logType.ToString());

            //Access the memberInfo values of the current LogType
            MemberInfo memberInfo = memberInfos.FirstOrDefault(k => k.DeclaringType == typeof(LogType));

            //Access the Description attribute as object and cast it to DescriptionAttribute
            DescriptionAttribute attribute = (DescriptionAttribute)memberInfo.GetCustomAttributes(true)
            .FirstOrDefault(attr => attr.GetType() == typeof(DescriptionAttribute));

            //Set the model description value to the description, written in the DescriptionAttribute
            return attribute.Description;
        }
    }
}
