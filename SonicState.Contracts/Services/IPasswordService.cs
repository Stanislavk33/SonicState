using System;
using System.Collections.Generic;
using System.Text;

namespace SonicState.Contracts.Services
{
   public interface IPasswordService
    {
        string CreateHash(string password);
    }
}
