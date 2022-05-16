using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book.Models
{
    public class UserModel
    {
        public virtual int UserId { get; set; }
        public virtual string FullName { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual string MobileNumber { get; set; }
       
    }
}