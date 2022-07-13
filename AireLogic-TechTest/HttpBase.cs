using AireLogic_TechTest.Interfaces;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

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
