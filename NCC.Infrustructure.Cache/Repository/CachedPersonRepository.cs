using NCC.Domain.Contract;
using NCC.Domain.Entities;
using NCC.Infrustructure.Cache.Contract;
using NCC.Infrustructure.Data.Context;
using NCC.Infrustructure.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCC.Infrustructure.Cache.Repository
{
    public class CachedPersonRepository : IPersonRepository
    {
        private readonly PersonRepository _personRepository;
        private readonly ICacheAdapter _cacheAdapter;
        public CachedPersonRepository(PersonRepository personRepository, ICacheAdapter cacheAdapter)
        {
            _personRepository = personRepository;
            _cacheAdapter = cacheAdapter;
        }

        public void Add(Person person)
        {
            _personRepository.Add(person);
        }

        public Person Get(int id)
        {
            string personId = $"person{id}";
            if (_cacheAdapter.Exists(personId))
            {
                return _cacheAdapter.Get<Person>(personId);
            }
            Person person = _personRepository.Get(id);
            _cacheAdapter.Add(personId, person);
            return person;
        }

        public List<Person> GetAll()
        {
            string personId = $"person";
            if (_cacheAdapter.Exists(personId))
            {
                return _cacheAdapter.Get<List<Person>>(personId);
            }
            List<Person> persons = _personRepository.GetAll();
            _cacheAdapter.Add(personId, persons);
            return persons;
        }

        public bool isCached()
        {
            return true;
        }
    }
}
