using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Lab5.Models;
using System.Diagnostics;

namespace Lab5.Services
{
    public interface IContactService
    {
        List<Contact> GetContacts();
        Contact GetContact(int id);
        void AddContact(Contact contact);
        void AddField(int id, string NewPropName, string NewPropValue);
    }

    public class ContactService : IContactService
    {
        private readonly AppDbContext db;

        public ContactService(AppDbContext db)
        {
            this.db = db;
        }

        public List<Contact> GetContacts()
        {
            return db.Contacts.OrderBy(c => c.Name).ToList();
        }
        public Contact GetContact(int id)
        {
            return db.Contacts.Where(c => c.ContactId == id).SingleOrDefault();
        }

        public void AddContact(Contact contact)
        {
            db.Contacts.Add(contact);
            db.SaveChanges();
        }

        public void AddField(int id, string NewPropName, string NewPropValue)
        {
            var query1 = from c in db.Contacts
                         where c.ContactId == id
                         select c;

            var person = query1.FirstOrDefault();

            PropertyInfo pi = person.GetType().GetProperty(NewPropName);
            pi.SetValue(person, NewPropValue, null);
            db.SaveChanges();
        }  
    }
    
}
