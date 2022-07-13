using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Net.Http;
using System.Net.Http.Headers;

namespace AireLogic_TechTest.Model
{
    public class ModelBase
    { 
      //  JavaScriptSerializer JSserializer { get; set; }
        public ModelBase()
        {
          //  JSserializer = new JavaScriptSerializer();
        }

        public static async Task<HttpResponseMessage> GetResponse(HttpClient client, string query)
        {
            return await client.GetAsync(query);
        }

        public static T Deserialize<T>(string result)
        {
            JavaScriptSerializer JSserializer = new JavaScriptSerializer();
            return JSserializer.Deserialize<T>(result);
        }

        public static async Task<T> Deserialize<T>(HttpResponseMessage response)
        {
            var result = await response.Content.ReadAsStringAsync();
            JavaScriptSerializer JSserializer = new JavaScriptSerializer();
            return JSserializer.Deserialize<T>(result);
        }

    }
}
