﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.ContactContracts
{
    public interface IContactDeleterService
    {
        public Task<bool> DeleteContact(int Id);
    }
}
