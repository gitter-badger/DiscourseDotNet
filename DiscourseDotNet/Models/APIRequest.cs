using Newtonsoft.Json;

namespace DiscourseDotNet.Models
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
