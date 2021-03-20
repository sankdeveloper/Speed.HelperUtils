using System;
using System.Collections.Specialized;
using System.Web;

namespace Speed.HelperUtils.Extensions
{
    public static class QueryStringExtension
    {
        // get entire querystring name/value collection
        public static NameValueCollection QueryString(this Uri url)
        {
            return HttpUtility.ParseQueryString(url.Query);
        }

        // get single querystring value with specified key
        public static string QueryString(this Uri url, string key)
        {
            return url.QueryString()[key];
        }

        // get entire querystring name/value collection
        public static NameValueCollection QueryString(this string url)
        {
            return HttpUtility.ParseQueryString(new Uri(url).Query);
        }

        // get single querystring value with specified key
        public static string QueryString(this string url, string key)
        {
            return new Uri(url).QueryString()[key];
        }
    }
}
