using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Net.Http;
namespace AireLogic_TechTest.Model
{
    public class ModelBase
    { 
        public static async Task<HttpResponseMessage> GetResponse(HttpClient client, string query)
        {
            return await client.GetAsync(query);
        }

        public static async Task<T> Deserialize<T>(HttpResponseMessage response)
        {
            var result = await response.Content.ReadAsStringAsync();
            JavaScriptSerializer JSserializer = new JavaScriptSerializer();
            return JSserializer.Deserialize<T>(result);
        }

    }
}
