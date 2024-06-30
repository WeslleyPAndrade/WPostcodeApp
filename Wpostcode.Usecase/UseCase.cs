using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpostcode.Repository.Interfaces;
using Wpostcode.Service.Interfaces;
using Wpostcode.Usecase.Interfaces;

namespace Wpostcode.Usecase
{
    public class UseCase : IUseCase
    {
        private readonly IService _service;
        private readonly IRepository _repository;

        public UseCase(IService service, IRepository repository)
        {
            _service = service;
            _repository = repository;
        }

        public List<string> GetAddressByPostcode(string postcode)
        {
            var response = _service.CallPostcodeAPI(postcode);

            return _repository.Save(response);
        }
    }
}
