using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MudHook.Core
{
    public class MudHookNotifications
    {
        public static void Set(Notification notification)
        {            
            HttpContext.Current.Session["Notification"] = notification;
        }

        public static Notification Get()
        {
            Notification notification = HttpContext.Current.Session["Notification"] != null ? HttpContext.Current.Session["Notification"] as Notification : new Notification();
            HttpContext.Current.Session.Remove("Notification");
            return notification;
        }
    }
    public class Notification
    {        
        public string Html { get; set; }

        public Notification()
        {
            this.Html = "";
        }
        public Notification(string type, string message)
        {
            this.Html = string.Format("<p class=\"notification {0}\">{1}</p>", type, message.Replace(",", "<br />"));
        }
    }
}
