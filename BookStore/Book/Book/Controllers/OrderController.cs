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
    public class OrderController : ApiController
    {
        ISession session = OpenSessionsss.OpenSession();
        //Get all Notes


        [Route("order")]
        [HttpPost]
        public HttpResponseMessage Order(OrderModel order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(order);
                        transaction.Commit();
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, order);
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
