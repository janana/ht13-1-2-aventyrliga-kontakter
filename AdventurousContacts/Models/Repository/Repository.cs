using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AdventurousContacts.Models.Repository
{
    public class Repository : IRepository
    {
        private DataModels.AdventureWorksEntities _entities = new DataModels.AdventureWorksEntities();
        
        public void Add(Contact contact)
        {
            _entities.Contacts.Add(contact);
        }
        public void Delete(Contact contact)
        {
            _entities.Contacts.Remove(contact);
        }
        public IQueryable<Contact> FindAllContacts() // ?
        {
            return _entities.Contacts.AsQueryable();
        }
        public Contact GetContactByID(int contactID)
        {
            return _entities.Contacts.Find(contactID);
        }
        public List<Contact> GetLastContacts(int count = 20)
        {
            return _entities.Contacts.OrderByDescending(c => c.ContactID).Take(count).ToList();
        }
        public void Save()
        {
            _entities.SaveChanges();
        }
        public void Update(Contact contact)
        {
            _entities.Entry(contact).State = EntityState.Modified;
        }
        

        // IDisposable
        private bool _disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _entities.Dispose();
                }
            }
            _disposed = true;
        }
    }
}