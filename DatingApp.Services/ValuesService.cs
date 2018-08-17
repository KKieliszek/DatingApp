using DatingApp.Entities.Models;
using DatingApp.Interfaces.Repository;
using DatingApp.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Services
{
    public class ValuesService : IValueService
    {
        private readonly IValueRepo _valueRepository;

        public ValuesService(IValueRepo valueRepository)
        {
            _valueRepository = valueRepository;
        }

        public async Task<IEnumerable<Value>> GetValues()
        {
            var values = await _valueRepository.GetValues();

            return values;
        }

        public async Task<Value> GetValue(int id)
        {
            var value = await _valueRepository.GetValue(id);

            return value;
        }
    }
}
