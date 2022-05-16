using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book.Models
{
    public class OrderModel
    {
        public virtual int OrdersId { get; set; }
        public virtual int TotalPrice { get; set; }

        public virtual int OrderBookQuantity { get; set; }

        public virtual DateTime OrderDate { get; set; }

        public virtual int UserId { get; set; }
        [JsonIgnore]
        public virtual UserModel UserModels { get; set; }
        public virtual int BookId { get; set; }
        [JsonIgnore]
        public virtual BookModel BookModels { get; set; }
        public virtual int AddressId { get; set; }
        [JsonIgnore]
        public virtual AddressModel AddressModel { get; set; }
    }
}