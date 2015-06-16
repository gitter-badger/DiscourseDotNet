using Newtonsoft.Json;

namespace DiscourseDotNet.Request
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
