using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.Helper
{
    class ApiHelper<T>
    {

  
        public  RestRequest restRequest;
        public  string baseUrl = "https://swapi.dev/api/";

        public  RestClient SetUrl(string resourseUrl)
        {
            var url = Path.Combine(baseUrl, resourseUrl);
            var restClient = new RestClient(url);
            return restClient;
        }

        //public RestRequest CreatePostRequest(string jsonString)
        //{
        //    restRequest = new RestRequest(Method.POST);
        //    restRequest.AddHeader("accept", "application/json");
        //    restRequest.AddParameter("application/json", jsonString, ParameterType.RequestBody);
        //    return restRequest;        
        //}

        public  RestRequest CreateGetRequest()
        {
            restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("accept", "application/json");
            return restRequest;
        }

        public  IRestResponse GetResponse(RestClient restClient, RestRequest restRequest)
        {
           return restClient.Execute(restRequest);
        }

        public  DTO GetContent<DTO>(IRestResponse restResponse)
        {
            var content = restResponse.Content;
            DTO deserializeObject = JsonConvert.DeserializeObject<DTO>(content);
            return deserializeObject;
        }


        //public string Serialize(dynamic content)
        //{
        //    string serializeObject = JsonConvert.SerializeObject(content, Formatting.Indented);
        //    return serializeObject;
        //}

    }
}
