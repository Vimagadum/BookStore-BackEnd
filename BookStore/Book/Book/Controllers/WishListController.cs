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
        public HttpResponseMessage AddAddress(WishlistModel wish)
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
    }
}
