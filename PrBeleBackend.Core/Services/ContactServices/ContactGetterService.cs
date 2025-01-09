using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.DTO.AccountDTOs;
using PrBeleBackend.Core.DTO.ContactDTOs;
using PrBeleBackend.Core.ServiceContracts.ContactContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.Services.ContactServices
{
    public class ContactGetterService : IContactGetterSerivce
    {
        private readonly IContactRepository _contactRepository;
        public ContactGetterService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task<List<ContactResponse>> GetAllContact()
        {
            List<Contact> contactResponses = await _contactRepository.GetAllContact();
            return contactResponses.Select(contact => contact.ToContactResponse()).ToList();
        }

        public async Task<ContactResponse?> GetContactById(int Id)
        {
            Contact? contact = await _contactRepository.GetContactById(Id);
            if (contact == null)
            {
                return null;
            }
            return contact.ToContactResponse();
        }

        public async Task<List<ContactResponse>> GetFilteredContact(string searchBy, string? searchString)
        {
            List<Contact> contacts = await _contactRepository.GetAllContact();

            if (searchBy == string.Empty || searchString == string.Empty)
            {
                return contacts.Select(a => a.ToContactResponse()).ToList();
            }
            switch (searchBy)
            {
                case nameof(Contact.FullName):
                    return contacts.Where(a => a.FullName.ToLower().Contains(searchString.ToLower()))
                        .Select(a => a.ToContactResponse()).ToList();
                case nameof(Contact.Email):
                    return contacts.Where(a => a.Email.ToLower().Contains(searchString.ToLower()))
                        .Select(a => a.ToContactResponse()).ToList();
                case nameof(Contact.PhoneNumber):
                    return contacts.Where(a => a.PhoneNumber.Contains(searchString))
                        .Select(a => a.ToContactResponse()).ToList();
                default:
                    return contacts.Select(a => a.ToContactResponse()).ToList();
            }
        }
    }
}
