using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book.Models
{
    public class OpenSessionsss
    {
        public static ISession OpenSession()
        {
            var configuration = new Configuration();

            var configurationPath = HttpContext.Current.Server.MapPath(@"~\DAL\nh.configuration.xml");

            configuration.Configure(configurationPath);

            var UserConfigurationFile = HttpContext.Current.Server.MapPath(@"~\DAL\user.mapping.xml");

            configuration.AddFile(UserConfigurationFile);
            

            ISessionFactory sessionFactory = configuration.BuildSessionFactory();

            return sessionFactory.OpenSession();
        }
    }
}