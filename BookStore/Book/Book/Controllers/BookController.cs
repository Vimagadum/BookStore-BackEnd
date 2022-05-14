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
    public class BookController : ApiController
    {
        ISession session = OpenSessionsss.OpenSession();

        [Route("AddBook")]
        [HttpPost]
        public HttpResponseMessage RegisterUser(BookModel bookModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(bookModel);
                        transaction.Commit();
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, bookModel);


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
