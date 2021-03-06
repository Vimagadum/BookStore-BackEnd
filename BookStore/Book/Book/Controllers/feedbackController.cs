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
        public HttpResponseMessage Updatefeedback(int FeedbackId, feedbackModel feed)
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
        [HttpDelete]
        public HttpResponseMessage Deletefeedback(int FeedbackId, int userId)
        {
            try
            {
                var feedbacklist = session.Get<feedbackModel>(FeedbackId);

                if (feedbacklist.UserId == userId)
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(feedbacklist);
                        transaction.Commit();
                        return Request.CreateResponse(HttpStatusCode.OK, " deleted feed back");
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
        public List<feedbackModel> getfeedbacklist(int BookId)
        {
            List<feedbackModel> newfeedbacklist = new List<feedbackModel>();
            List<feedbackModel> feedbackLists = session.Query<feedbackModel>().ToList();
            foreach (var feedback in feedbackLists)
            {
                if (feedback.BookId == BookId)
                {
                    newfeedbacklist.Add(feedback);
                }
            }

            return newfeedbacklist;
        }
    }
}
