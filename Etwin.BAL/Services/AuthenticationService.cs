using EtwLogin.Models;
using EtwLogin.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Etwin.BAL.Services
{
    public class AuthenticationService
    {


        public readonly IAuthenticateLogin _repository;
        public AuthenticationService(IAuthenticateLogin repository)
        
        { 
        _repository= repository;
        }

        public async Task<Operators> AuthenticateUser(string username, string passcode)
        {
            var succeeded = await _repository.AuthenticateUser(username, passcode);
            return succeeded;
        }
        public async Task<bool> SendEmail(string email)
        {
            return await _repository.SendEmailAsync(email);
        }
    }
}
