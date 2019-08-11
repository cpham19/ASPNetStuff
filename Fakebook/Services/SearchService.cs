﻿using System.Collections.Generic;
using System.Linq;
using Fakebook.Models;

// Used for searching people
namespace Fakebook.Services
{
    public class SearchService
    {
        private readonly AppDbContext db;

        public SearchService(AppDbContext db)
        {
            this.db = db;
        }

        // Getting a list of people excluding user
        public List<Person> GetPersons(int id)
        {
            return db.Persons.Where(p => p.PersonId != id).ToList();
        }

        // Getting a list of people based on the name parameter
        public List<Person> GetPersonsBasedOnName(int id, string name)
        {
            if (name == null || name == "")
            {
                return db.Persons.Where(p => p.PersonId != id).ToList();
            } 
            else
            {
                return db.Persons.Where(p => p.Name.ToUpper() == name.ToUpper()).ToList();
            }
        }
    }
}

