using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Services.CredentialsValidator
{
    internal interface ICredentialsValidatorService
    {

        User GetUser(string username, string password);     
    }
}
