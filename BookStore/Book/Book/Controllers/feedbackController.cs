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
    public class feedbackController : ApiController
    {
        ISession session = OpenSessionsss.OpenSession();
        //Get all Notes


        [Route("feedback")]
        [HttpPost]
        public HttpResponseMessage Order(feedbackModel feed)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(feed);
                        transaction.Commit();
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, feed);
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
        [HttpPut]
        public HttpResponseMessage UpdateBook(int FeedbackId, feedbackModel feed)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var feedback = session.Get<feedbackModel>(FeedbackId);
                    feedback.Comment = feed.Comment;
                    feedback.Rating = feed.Rating;
                    feedback.UserId = feed.UserId;
                    feedback.BookId = feed.BookId;

                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(feedback);
                        transaction.Commit();
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, feedback);


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
