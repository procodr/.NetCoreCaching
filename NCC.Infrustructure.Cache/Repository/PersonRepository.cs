using NCC.Domain.Contract;
using NCC.Domain.Entities;
using NCC.Infrustructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCC.Infrustructure.Cache.Repository
{
    public class PersonRepository : IPersonRepository
    {
        public readonly DataContext _context;
        public PersonRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Person person)
        {
            _context.Add(person);
            _context.SaveChanges();
        }

        public Person Get(int id)
        {
            return _context.Persons.Find(id);
        }

        public List<Person> GetAll()
        {
            return _context.Persons.ToList();
        }
    }
}
