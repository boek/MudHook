using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime;
using System.Runtime.Caching;
using System.Web;
using System.Web.Caching;

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
    }
}
