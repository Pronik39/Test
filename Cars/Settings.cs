using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using Cars.Data;

namespace Cars
{
    public static class Settings
    {
        public static string ConectionString
        {
            get { return ConfigurationManager.AppSettings["ConnectionString"]; }
        }

        public static readonly IDataProvider DataProvider = new SqlDataProvider();
    }
}