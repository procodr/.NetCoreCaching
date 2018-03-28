using NCC.Domain.Contract;
using NCC.Domain.Entities;
using NCC.Services.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace NCC.Services.Application
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public IEnumerable<Person> GetPersons()
        {
            return _personRepository.GetAll();
        }
    }
}
