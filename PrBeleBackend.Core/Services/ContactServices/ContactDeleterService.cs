using PrBeleBackend.Core.Domain.Entities;
using PrBeleBackend.Core.Domain.RepositoryContracts;
using PrBeleBackend.Core.ServiceContracts.ContactContracts;


namespace PrBeleBackend.Core.Services.ContactServices
{
    public class ContactDeleterService : IContactDeleterService
    {
        private readonly IContactRepository _contactRepository;
        public ContactDeleterService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task<bool> DeleteContact(int Id)
        {
            Contact? matchingContact = await _contactRepository.GetContactById(Id);

            if (matchingContact == null)
            {
                return false;
            }
            bool result = await _contactRepository.DeleteContactById(Id);
            return result;
        }
    }
}
