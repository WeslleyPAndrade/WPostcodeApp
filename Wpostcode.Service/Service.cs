using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Wpostcode.Service.Interfaces;
using Wpostcode.Service.Models;

namespace Wpostcode.Service
{
    public class Service : IService
    {
        const string API_URL = "https://api.postcodes.io/postcodes/";

        public Service()
        {
           //adicionar IConfiguration
        }

        public async Task<string> CallPostcodeAPI(string postcode)
        {
            try
            {
                //HttpClient httpClient = new HttpClient();
                //var response = await httpClient.GetAsync($"{API_URL}{postcode}");
                //var jsonString = await response.Content.ReadAsStringAsync();

                //PostcodeModel postcodeObject = JsonSerializer.Deserialize<PostcodeModel>(jsonString);

                //if (postcodeObject.Status != 200) 
                //{
                //    return postcodeObject.Result;
                //}
            }
            catch (Exception)
            {

                throw;
            }

           

            //var response = new GenericResponse<AddressModel>();

            //var request = new HttpRequestMessage(HttpMethod.Get, $"{API_URL}{postcode}");

            //using (var client = new HttpClient())
            //{
            //    var responsePostcodeApi = await client.SendAsync(request);
            //    var contentResponse = await responsePostcodeApi.Content.ReadAsStringAsync();
            //    //var objResponse = JsonSerializer.Deserialize<PostcodeModel>(contentResponse);

            //    if (responsePostcodeApi.StatusCode != 200)
            //    {
            //        //response.StatusCode = responsePostcodeApi.StatusCode;
            //        //response.ResponseData = objResponse?.Result;
            //    }
            //    else
            //    {
            //        response.StatusCode = responsePostcodeApi.StatusCode;
            //        response.ResponseError = JsonSerializer.Deserialize<ExpandoObject>(contentResponse);
            //    }
            //}


            return string.Empty;
        }
    }
}
