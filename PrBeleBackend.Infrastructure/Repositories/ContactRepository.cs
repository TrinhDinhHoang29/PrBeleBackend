using Microsoft.EntityFrameworkCore;
using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Infrastructure.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly BeleStoreContext _context;
        public ContactRepository(BeleStoreContext context)
        {
            _context = context;
        }
        public async Task<Contact> AddContact(Contact contact)
        {
            await _context.contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
            return contact;
        }

        public async Task<bool> DeleteContactById(int Id)
        {
            Contact? matchingContact = await _context
               .contacts
               .FirstAsync(c => c.Id == Id);
            matchingContact.Deleted = true;

            await _context.SaveChangesAsync();

            return matchingContact.Deleted;
        }

        public async Task<List<Contact>> GetAllContact()
        {
            List<Contact> contacts = await _context.contacts
                 .Where(a => a.Deleted == false)
                 .ToListAsync();
            return contacts;
        }

        public Task<Contact?> GetContactByEmail(string? Email)
        {
            throw new NotImplementedException();
        }

        public async Task<Contact?> GetContactById(int? Id)
        {
            Contact? contact = await _context.contacts
               .Where(a => a.Deleted == false)
               .FirstOrDefaultAsync(a => a.Id == Id);
            return contact;
        }

        public async Task<List<Contact>> GetFilteredContact(Expression<Func<Contact, bool>> predicate)
        {
            List<Contact> contacts = await _context.contacts
               .Where(predicate)
               .Where(c => c.Deleted == false)
              .ToListAsync();
            return contacts;
        }

        public async Task<Contact> UpdateContact(Contact contact)
        {
            Contact? matchingContact = await _context
               .contacts
               .FirstAsync(c => c.Id == contact.Id);

            matchingContact.Title = contact.Title;
            matchingContact.Email = contact.Email;
            matchingContact.Message = contact.Message;
            matchingContact.FullName = contact.FullName;
            matchingContact.PhoneNumber = contact.PhoneNumber;
            matchingContact.Status = contact.Status;
            

            await _context.SaveChangesAsync();

            return matchingContact;
        }
    }
}
