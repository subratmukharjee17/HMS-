using EtwLogin.Models;
using System.Threading.Tasks;

namespace EtwLogin.Repository
{
    public interface IMailService
    {
       void SendEmailAsync(string mailRequest);
    }
}
