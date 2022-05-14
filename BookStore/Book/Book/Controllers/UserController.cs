using Book.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NHibernate;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Web.Http;

namespace Book.Controllers
{
    public class UserController : ApiController
    {
        ISession session = OpenSessionsss.OpenSession();

        [Route("registerUser")]
        [HttpPost]
        public HttpResponseMessage RegisterUser(UserModel User)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(User);
                        transaction.Commit();
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, User);


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

        [Route("loginUser")]
        [HttpPost]
        public HttpResponseMessage login(UserLogin login)
        {
            try
            {
                string token = "";
                if (ModelState.IsValid)
                {
                    List<UserModel> Users = session.Query<UserModel>().ToList();
                    foreach (var user in Users)
                    {
                        if (user.Password == login.Password)
                        {
                            if (user.Email == login.Email)
                            {
                                token = jwt.GenerateJWTToken(user.Email, user.UserId);
                                break;
                            }
                            break;
                        }
                    }

                    return Request.CreateResponse(HttpStatusCode.OK, token);
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
        [Route("forgotpassword")]
        [HttpPost]
        public HttpResponseMessage ForgotPassword(ForgotPasswordModel forgotPasswordModel)
        {
            try
            {
                string token = "";
                if (ModelState.IsValid)
                {
                    List<UserModel> Users = session.Query<UserModel>().ToList();
                    foreach (var user in Users)
                    {
                        if (user.Email == forgotPasswordModel.Email)
                        {
                            token = jwt.GenerateJWTToken(user.Email, user.UserId);
                            new MSMQ().Sender(token);
                            break;

                        }
                    }

                    return Request.CreateResponse(HttpStatusCode.OK, token);
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
        //[Route("ResetPassword")]
        //[HttpPost]
        //[Authorize]
        //public HttpResponseMessage ResetPassword(ResetPassword resetPass)
        //{
        //    try
        //    {
        //        var userId = int.Parse(JSToken.Class.FirstOrDefault(x => x.Type == "Email").Value);


        //        if (ModelState.IsValid)
        //        {
        //            List<UserModel> Users = session.Query<UserModel>().ToList();


        //            if (resetPass.newPassword == resetPass.confirmPassword)
        //            {
        //                 user.Password = resetPass.confirmPassword;

        //            }


        //            return Request.CreateResponse(HttpStatusCode.OK, "password reset successful");
        //        }
        //        else
        //        {
        //            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error !");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //}
    }
}
