using NCC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCC.Infrustructure.Data.Context
{
    public static class DataInitializer
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();

            if (context.Persons.Any()) return;

            var Persons = new Person[]
            {
                new Person{FirstName = "AliReza", LastName = "Mahmudi"},
                new Person{FirstName = "AliReza", LastName = "Orumand"},
                new Person{FirstName = "Mehrdad", LastName = "Saheb"},
                new Person{FirstName = "Ali", LastName = "Sheykh Nezami"}
            };

            foreach (var customer in Persons) context.Persons.Add(customer);

            context.SaveChanges();
        }
    }
}
