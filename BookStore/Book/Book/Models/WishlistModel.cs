using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book.Models
{
    public class WishlistModel
    {
        public virtual int WishlistId { get; set; }
        public virtual int UserId { get; set; }
        [JsonIgnore]
        public virtual UserModel UserModels { get; set; }
        public virtual int bookId { get; set; }
        [JsonIgnore]
        public virtual BookModel BookModels { get; set; }
    }
}