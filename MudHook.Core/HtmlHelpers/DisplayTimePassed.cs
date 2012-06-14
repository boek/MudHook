using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace System.Web.Mvc.Html
{    
    public static class HtmlHelpers
    {
        public static string DisplayTimePassed(this HtmlHelper helper, DateTime dateTime)
        {
            DateTime now = DateTime.Now;
            if (DateTime.Compare(now, dateTime) >= 0)
            {
                TimeSpan ts = now.Subtract(dateTime);                

                //return string.Format("{0} days, {1} hours, {2} minutes, {3} seconds",
                //    ts.Days, ts.Hours, ts.Minutes, ts.Seconds);
                if (ts.Days > 0)
                {
                    return string.Format("{0} days",
                    ts.Days);
                }
                else if (ts.Hours > 0)
                {
                    return string.Format("{0} hours",
                    ts.Hours);
                }
                else if (ts.Minutes > 0)
                {
                    return string.Format("{0} minutes",
                    ts.Minutes);
                }
                else
                {
                    return string.Format("{0} seconds",
                    ts.Seconds);
                }                
            }
            else
                return "Not valid";
        }
    }
}
