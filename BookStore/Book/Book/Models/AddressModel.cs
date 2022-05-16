using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book.Models
{
    public class AddressModel
    {
        public virtual int? AddressId { get; set; }
        public virtual string Address { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual int TypeId { get; set; }
        [JsonIgnore]
        public virtual AddressTypeModel AddresstypeModels { get; set; }
        public virtual int UserId { get; set; }
        [JsonIgnore]
        public virtual UserModel UserModels { get; set; }
    }
}