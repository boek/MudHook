using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime;
using System.Runtime.Caching;
using System.Web;
using System.Web.Caching;
using System.Reflection;

namespace MudHook.Core
{        
    public class MetaData
    {        
        public static string SiteName
        {
            get
            {
                if (IsExpired("SiteName"))
                    ReloadCache("SiteName");

                return (string)HttpRuntime.Cache["SiteName"];
            }
            
        }
        public static string SiteDescription
        {
            get
            {
                if (IsExpired("SiteDescription"))
                    ReloadCache("SiteDescription");

                return (string)HttpRuntime.Cache["SiteDescription"];
            }
        }
        public static string TwitterAccount
        {
            get
            {
                if (IsExpired("Twitter"))
                    ReloadCache("Twitter");

                return (string)HttpRuntime.Cache["Twitter"];
            }
        }
        public static string PostsPage
        {
            get
            {           
                if (IsExpired("PostsPage"))
                    ReloadCache("PostsPage");

                return (string)HttpRuntime.Cache["PostsPage"];            
            }
        }
        public static string HomePage
        {
            get
            {
                if (IsExpired("HomePage"))
                    ReloadCache("HomePage");

                return (string)HttpRuntime.Cache["HomePage"];
            }
        }
        public static string AutoPublishComments
        {
            get
            {
                if (IsExpired("AutoPublishComments"))
                    ReloadCache("AutoPublishComments");

                return (string)HttpRuntime.Cache["AutoPublishComments"];
            }
        }
        public static int PostsPerPage
        {
            get
            {
                if (IsExpired("PostsPerPage"))
                    ReloadCache("PostsPerPage");

                return Convert.ToInt32(HttpRuntime.Cache["PostsPerPage"]);
            }
        }
        public static string Theme
        {
            get
            {
                if (IsExpired("Theme"))
                    ReloadCache("Theme");

                return (string)HttpRuntime.Cache["Theme"];
            }
        }

        private static bool IsExpired(string key)
        {
            return (HttpRuntime.Cache[key] == null);
        }
        private static void ReloadCache(string key)
        {
            MudHookRepository repo = new MudHookRepository();            
            string value = repo.GetMeta(key).Value;
            HttpRuntime.Cache.Insert(key, value, null, DateTime.Now.AddMinutes(60), Cache.NoSlidingExpiration);
        }
        
        public static void Update(MetadataModel model)
        {
            MudHookRepository repo = new MudHookRepository();

            if(string.IsNullOrEmpty(model.SiteName))
                throw new ArgumentException("You need a site sitename");
            if (string.IsNullOrEmpty(model.SiteDescription))
                throw new ArgumentException("You need a site description");
            if (string.IsNullOrEmpty(model.SiteName))
                throw new ArgumentException("You need a theme");

            bool updateRoutes = model.HomePage!= MetaData.HomePage;

            foreach (PropertyInfo property in model.GetType().GetProperties())
            {
                repo.SetMeta(property.Name, property.GetValue(model, null).ToString());
                HttpRuntime.Cache.Remove(property.Name);
            }

            if (updateRoutes)
            {
                MudHookRoutes.UpdateRouteRegistration();
            }
        }

    }
}
