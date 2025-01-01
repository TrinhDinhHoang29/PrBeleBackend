using PrBeleBackend.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Domain.RepositoryContracts
{
    public interface IContactRepository
    {
        public Task<List<Contact>> GetAllContact();

        public Task<List<Contact>> GetFilteredContact(Expression<Func<Contact, bool>> predicate);

        public Task<Contact?> GetContactById(int? Id);
        public Task<Contact?> GetContactByEmail(string? Email);

        public Task<Contact> AddContact(Contact contact);

        public Task<Contact> UpdateContact(Contact contact);

        public Task<bool> DeleteContactById(int Id);
    }
}
