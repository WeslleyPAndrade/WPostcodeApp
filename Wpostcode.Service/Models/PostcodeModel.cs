using System.Text.Json.Serialization;

namespace Wpostcode.Service.Models
{
    public class PostcodeModel
    {
        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("result")]
        public AddressModel? Result { get; set; }
    }
}
