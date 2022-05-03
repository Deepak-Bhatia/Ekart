using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace E_Cart.Utility
{

    /// <summary>
    /// This class contains extention method
    /// </summary>
    public static class ExtentionMethods
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }


        public static object getObject (this ISession session, string key)
        {
            var value = session.GetString(key);
            return value;
        }

    }
}
