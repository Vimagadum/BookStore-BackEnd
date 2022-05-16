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

        [Route("Add")]
        [HttpPost]
        public HttpResponseMessage AddBook(BookModel bookModel)
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
        [Route("Update")]
        [HttpPut]
        public HttpResponseMessage UpdateBook(int bookId,BookModel bookModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var book = session.Get<BookModel>(bookId);
                    book.BookName = bookModel.BookName;
                    book.AuthorName = bookModel.AuthorName;
                    book.ActualPrice = bookModel.ActualPrice;
                    book.Rating = bookModel.Rating;
                    book.RatingCount = bookModel.RatingCount;
                    book.Description = bookModel.Description;
                    book.ActualPrice = bookModel.ActualPrice;
                    book.DiscountPrice = bookModel.DiscountPrice;
                    book.BookImage = bookModel.BookImage;
                    book.BookQuantity = bookModel.BookQuantity;
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(book);
                        transaction.Commit();
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, book);


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
        [Route("delete")]
        [HttpDelete]
        public HttpResponseMessage DeleteBook(int id)
        {
            try
            {
                var book = session.Get<BookModel>(id);
                if (book != null)
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(book);
                        transaction.Commit();
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, "Book deleted Successfully");
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
        [Route("get")]
        public List<BookModel> GetBookList()
        {
            List<BookModel> Books = session.Query<BookModel>().ToList();
            return Books;
        }

        [Route("get/id")]
        [HttpGet]
        public BookModel GetBookByBookId(int id)
        {
            var book = session.Get<BookModel>(id);
            return book;
        }
    }
}
