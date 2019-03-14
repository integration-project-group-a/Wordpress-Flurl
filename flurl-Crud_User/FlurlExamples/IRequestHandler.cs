using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FlurlExamples.Model;

namespace FlurlExamples
{
    public interface IRequestHandler
    {
        Task<List<User>> GetUsers();
        Task<User> CreateUser(string username, string email, string password);
        Task<User> UpdateUser(int id, string mail);
        Task<HttpResponseMessage> DeleteUser(int id, int reassign);
    }
}