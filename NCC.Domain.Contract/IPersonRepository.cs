using NCC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NCC.Domain.Contract
{
    public interface IPersonRepository
    {
        void Add(Person person);
        Person Get(int id);
        List<Person> GetAll();
    }
}
