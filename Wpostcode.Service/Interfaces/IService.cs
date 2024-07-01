using Wpostcode.Data.Models;

namespace Wpostcode.Service.Interfaces
{
    public interface IService
    {
        Task<AddressModel> CallPostcodeAPI(string postcode);
    }
}
