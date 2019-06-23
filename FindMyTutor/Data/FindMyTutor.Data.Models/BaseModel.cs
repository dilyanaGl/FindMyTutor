using System;
using System.Collections.Generic;
using System.Text;

namespace FindMyTutor.Data.Models
{
   public abstract class BaseModel<T>
    {
        public abstract T Id { get; set; }
    }
}
