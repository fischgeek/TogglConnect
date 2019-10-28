using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace SharedLibrary
{
    public static class WebCall
    {
        public static string GetRequest(string url)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            var response = client.Get(request);
            return response.Content;
        }
        public static string GetRequestCacheFree(string url)
        {
            var client = new RestClient(url);
            client.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
            var request = new RestRequest(Method.GET);
            var response = client.Get(request);
            return response.Content;
        }
        public static WebResult GetRequestWithErrorHandling(string url, string basicAuth = "")
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            if (!basicAuth.JFIsNull()) {
                request.AddHeader("Authorization", $"Basic {basicAuth}");
            }
            var response = client.Get(request);
            return new WebResult() {
                IsSuccessful = response.IsSuccessful
                , CallWasSuccessful = response.ResponseStatus == ResponseStatus.Completed
                , ErrorMessage = response.ErrorMessage
                , Data = response.Content
            };
        }

        public static string PutRequest(string url, object objParams = null, string basicAuth = "")
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.PUT);
            if (objParams != null) {
                request.AddJsonBody(objParams);
            }
            if (!basicAuth.JFIsNull()) {
                request.AddHeader("Authorization", $"Basic {basicAuth}");
            }
            var response = client.Put(request);
            return response.Content;
        }

        public static string PostRequest(string url, object postParams)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(postParams);
            var response = client.Post(request);
            return response.Content;
        }

        public static WebResult PostRequestWithErrorHandling(string url, object postParams, string basicAuth = "")
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            if (!basicAuth.JFIsNull()) {
                request.AddHeader("Authorization", $"Basic {basicAuth}");
            }
            request.AddJsonBody(postParams);
            var response = client.Post(request);
            return new WebResult() {
                IsSuccessful = response.IsSuccessful
                , CallWasSuccessful = response.ResponseStatus == ResponseStatus.Completed
                , ErrorMessage = response.ErrorMessage
                , Data = response.Content
            };
        }

        public static WebResult HeadRequest(string url)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.HEAD);
            request.Parameters.Clear();
            request.AddHeader("Accept", "*/*");
            var response = client.Head(request);
            return new WebResult() {
                IsSuccessful = response.IsSuccessful
                , CallWasSuccessful = response.ResponseStatus == ResponseStatus.Completed
                , ErrorMessage = response.ErrorMessage
                , Data = response.Content
            };
        }

        public static bool URLIsValid(string url) => HeadRequest(url).IsSuccessful;

        public static WebResult DeleteRequest(string url)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.DELETE);
            var response = client.Delete(request);
            return new WebResult() {
                IsSuccessful = response.IsSuccessful
                , CallWasSuccessful = response.ResponseStatus == ResponseStatus.Completed
                , ErrorMessage = response.ErrorMessage
                , Data = response.Content
            };
        }
    }
}
