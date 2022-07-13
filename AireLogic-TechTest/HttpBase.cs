using AireLogic_TechTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AireLogic_TechTest
{
    internal class HttpBase : HttpClient
    {
        public HttpClient HttpClient { get; set; }
        public HttpBase(IHttpRequest httpRequest)
        {
            HttpClient = new HttpClient();
            HttpClient.BaseAddress = new Uri(httpRequest.BaseUrl);
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("TechTest", "0.0.1"));

        }


    }
}
