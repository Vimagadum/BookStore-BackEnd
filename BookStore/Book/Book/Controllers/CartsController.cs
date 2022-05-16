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
    public class CartsController : ApiController
    {
        ISession session = OpenSessionsss.OpenSession();

        [HttpPost]
        public HttpResponseMessage AddToCart(CartModel cart)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(cart);
                        transaction.Commit();
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, cart);
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
        public HttpResponseMessage DeleteBook(int id)
        {
            try
            {
                var cart = session.Get<CartModel>(id);
                if (cart != null)
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(cart);
                        transaction.Commit();
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, "cart deleted Successfully");
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
        //[Route("get")]
        [HttpGet]
        public List<CartModel> GetCartList()
        {
            List<CartModel> Cart = session.Query<CartModel>().ToList();
            return Cart;
        }

        //[Route("get")]
        [HttpGet]
        public CartModel getCart(int id)
        {
            var cart = session.Get<CartModel>(id);
            return cart;
        }
    }
}
