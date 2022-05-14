using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book.Models
{
    public class BookModel
    {
        public virtual int BookId { get; set; }
        public virtual string BookName { get; set; }
        public virtual string AuthorName { get; set; }
        public virtual float Rating { get; set; }
        public virtual int RatingCount { get; set; }
        public virtual int DiscountPrice { get; set; }
        public virtual int ActualPrice { get; set; }
        public virtual string Description { get; set; }
        public virtual string BookImage { get; set; }
        public virtual int BookQuantity { get; set; }
    }
}