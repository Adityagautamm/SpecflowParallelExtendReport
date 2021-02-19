
using NUnit.Framework;
using RestSharp;
using SpecFlowProject1.Helper;
using SpecFlowProject1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Steps.ApiSteps
{
    [Binding]
    class ApiVerificationsteps
    {
      

        [Then(@"I verify api call (.*) with passenger (.*)")]
        public void ThenIVerifyApiCallWithPassenger(string endPoint, string passenger)
        {
            ApiHelper<VehicleRoot> apiHelper = new ApiHelper<VehicleRoot>() ;
            RestClient restClient = apiHelper.SetUrl(endPoint);
            RestRequest restRequest = apiHelper.CreateGetRequest();
            IRestResponse restResponse = apiHelper.GetResponse(restClient, restRequest);
            VehicleRoot vehicleRoot =  apiHelper.GetContent<VehicleRoot>(restResponse);
            Assert.IsTrue(vehicleRoot.results[0].passengers.Equals(passenger));


            //  RestRequest restRequest = ApiHelper<Vehicles>.CreateGetRequest();
            //  RestClient restClient = ApiHelper<Vehicles>.SetUrl(endPoint);
            //  IRestResponse restResponse = ApiHelper<Vehicles>.GetResponse(restClient, restRequest);
            //Vehicles vehicle =  ApiHelper<new Vehicles>.GetContent(restResponse);


        }

    }
}
