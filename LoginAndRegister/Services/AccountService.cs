﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using LoginAndRegister.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace LoginAndRegister.Services
{
    public class AccountService
    {
        private readonly AppDbContext db;

        public AccountService(AppDbContext db)
        {
            this.db = db;
        }

        public Person GetPerson(string username)
        {
            return db.Persons.Where(e => e.Username.ToUpper() == username.ToUpper()).SingleOrDefault();
        }

        public void AddPerson(Person person)
        {
            db.Persons.Add(person);
            db.SaveChanges();
        }

        public ClaimsIdentity Authenticate(string username, string password)
        {
            var person = this.GetPerson(username);
            if (person == null || person.Password != password)
            {
                return null;
            }

            var claims = new List<Claim>
            {
                new Claim("PersonId", person.PersonId.ToString()),
                new Claim(ClaimTypes.Name, person.Name),
                new Claim(ClaimTypes.NameIdentifier, person.Username)
            };

            if (person.IsAdmin)
            {
                claims.Add(new Claim("IsAdmin", "Yes"));
            }

            return new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}

