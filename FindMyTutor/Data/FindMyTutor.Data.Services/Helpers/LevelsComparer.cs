using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FindMyTutor.Data.Services.Helpers
{
    internal class LevelsComparer : IEqualityComparer<SelectListItem>
    {
        public bool Equals(SelectListItem x, SelectListItem y)
        {
            //int first = x.GetHashCode();
            //int second = y.GetHashCode();
            return x.Value.Equals(y.Value);
        }

        public int GetHashCode(SelectListItem obj)
        {
            return 0;
        }
    }
}