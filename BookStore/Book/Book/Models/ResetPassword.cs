using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book.Models
{
    public class ResetPassword
    {
        public virtual string newPassword { get; set; }
        public virtual string confirmPassword { get; set; }

    }
}