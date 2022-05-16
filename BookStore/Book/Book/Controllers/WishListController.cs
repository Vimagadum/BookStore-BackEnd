using Book.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Book.Controllers
{
    public class WishListController : ApiController
    {
        ISession session = OpenSessionsss.OpenSession();
        //Get all Notes


        [Route("AddWishList")]
        [HttpPost]
        public HttpResponseMessage AddToWishlist(WishlistModel wish)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(wish);
                        transaction.Commit();
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, wish);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error !");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpDelete]
        public HttpResponseMessage DeletefromWishlist(int id, int userId)
        {
            try
            {
                var wishlist = session.Get<WishlistModel>(id);

                if (wishlist.UserId == userId)
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(wishlist);
                        transaction.Commit();
                        return Request.CreateResponse(HttpStatusCode.OK, " deleted from wish list");
                    }

                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Error !");
                }
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpGet]
        public WishlistModel getwishlist(int id)
        {
            var wish = session.Get<WishlistModel>(id);
            return wish;
        }
    }
}
