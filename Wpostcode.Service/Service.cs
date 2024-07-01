using System.Text.Json;
using Wpostcode.Data.Models;
using Wpostcode.Service.Interfaces;

namespace Wpostcode.Service
{
    public class Service : IService
    {
        const string API_URL = "https://api.postcodes.io/postcodes/";

        private void SucessRequest(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode) throw new Exception("can't find postcode, service is not available.");
        }


        public async Task<AddressModel> CallPostcodeAPI(string postcode)
        {
            try
            {
                HttpClient httpClient = new HttpClient();

                var response = await httpClient.GetAsync($"{API_URL}{postcode}");

                SucessRequest(response);

                var jsonString = await response.Content.ReadAsStringAsync();

                var postCodeModel = JsonSerializer.Deserialize<PostcodeModel>(jsonString);

                if (postCodeModel != null && postCodeModel.Result != null)
                {
                    return postCodeModel.Result;
                }

                return new AddressModel();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
