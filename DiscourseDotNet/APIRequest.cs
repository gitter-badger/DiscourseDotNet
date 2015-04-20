using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DiscourseDotNet
{
    internal abstract class APIRequest
    {
        public override string ToString()
        {
            var settings = new JsonSerializerSettings
            {
                DateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind,
                DateFormatHandling = DateFormatHandling.IsoDateFormat
            };

            return JsonConvert.SerializeObject(this, settings);
        }
    }
}
