using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BCS.Directory.APP.Utilities
{
    public static class SessionExtensionMethods
    {
        public static void SetObject(this ISession session,
                           string key, object value)
        {
            string stringValue = JsonConvert.
                                 SerializeObject(value);
            session.SetString(key, stringValue);
        }

        public static T GetObject<T>(this ISession session,
                                     string key)
        {
            string stringValue = session.GetString(key);
            if (stringValue == null)
                stringValue = "";
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            T value = JsonConvert.DeserializeObject<T>(stringValue, settings);

            return value;
        }
    }
}
