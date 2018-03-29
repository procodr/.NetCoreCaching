using NCC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NCC.Services.Contract
{
    public interface IPersonService
    {
        IEnumerable<Person> GetPersons();
        string GetStatus();
    }
}
