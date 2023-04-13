using System.Collections.Generic;
using System.Threading.Tasks;
using EtwLogin.Models;
namespace EtwLogin.Repository
{
    public interface IAuthenticateLogin 
    {
        Task<IEnumerable<Operators>> getuser();
        Task<Operators> AuthenticateUser(string username, string passcode);
        Task<bool> SendEmailAsync(string emailId);
    }

}
