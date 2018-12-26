using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKlubas.Core.Extensions
{
    public static class JsonExtensions
    {
        public static string ToJson(this object obj)
        {
            if (obj == null) return null;

            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
        }

        public static T ToObject<T>(this object obj)
        {
            if (obj == null) return default(T);

            return JsonConvert.DeserializeObject<T>(obj.ToString());
        }
    }
}
