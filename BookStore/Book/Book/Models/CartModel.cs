using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book.Models
{
    public class CartModel
    {
        public virtual int? CartId { get; set; }
        public virtual int OrderQuantity { get; set; }
        public virtual int UserId { get; set; }
        [JsonIgnore]
        public virtual ISet<UserModel> UserModels { get; set; }
        public virtual int BookId { get; set; }
        [JsonIgnore]
        public virtual ISet<BookModel> BookModels { get; set; }

    }
}