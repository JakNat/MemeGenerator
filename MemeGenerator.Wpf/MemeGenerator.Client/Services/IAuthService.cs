using System.Net.Http;
using System.Threading.Tasks;

namespace MemeGenerator.Client.Services
{
    public interface IAuthService : IService
    {
        Task<HttpResponseMessage> Login(string email, string password);
        Task<HttpResponseMessage> Register(string userName, string password);
    }
}