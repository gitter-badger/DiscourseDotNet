using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscourseDotNet.Extensions
{
    public static class WebExtensions
    {
        public static Uri AttachParameters(this Uri uri, NameValueCollection parameters)
        {
            var stringBuilder = new StringBuilder();
            var str = "?";
            for (var index = 0; index < parameters.Count; ++index)
            {
                stringBuilder.Append(str + parameters.AllKeys[index] + "=" + parameters[index]);
                str = "&";
            }
            return new Uri(uri + stringBuilder.ToString());
        }
    }
}
