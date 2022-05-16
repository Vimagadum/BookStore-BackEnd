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
    public class AddressController : ApiController
    {
        ISession session = OpenSessionsss.OpenSession();
        //Get all Notes

        
        [Route("AddAddress")]
        [HttpPost]
        public HttpResponseMessage AddAddress(AddressModel address)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(address);
                        transaction.Commit();
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, address);
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
        public HttpResponseMessage UpdateAddress(int AddressId, AddressModel addressModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var address = session.Get<AddressModel>(AddressId);
                    address.Address = addressModel.Address;
                    address.City = addressModel.City;
                    address.State = addressModel.State;
                    address.TypeId = addressModel.TypeId;
                    address.UserId = addressModel.UserId;



                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.SaveOrUpdate(address);
                        transaction.Commit();
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, address);
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
