using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using FlurlExamples.Constants;
using FlurlExamples.Model;

namespace FlurlExamples
{
    public class FlurlRequestHandler : IRequestHandler
    {
        private static string _admin="Front-end";
        private static string _adminPassword="Front-end";
        //private static string _adminToken;

        public FlurlRequestHandler()
        {
            //keeping sensitive information in environment variables
            //never, ever leave secret information in the code or it might end up in some public repo
            //_admin = Environment.GetEnvironmentVariable("user");
            //_adminPassword = Environment.GetEnvironmentVariable("password");
            //_adminToken = Environment.GetEnvironmentVariable("TOKEN");
        }

        public async Task<List<User>> GetUsers()
        {
            var result = await RequestConstants.BaseUrl
                .AppendPathSegments("users")
                .WithHeader(RequestConstants.UserAgent, RequestConstants.UserAgentValue)
                .WithBasicAuth(_admin, _adminPassword)
                //.WithOAuthBearerToken(_adminToken) //alternative way of logging in with token
                .GetJsonAsync<List<User>>();

            return result;
        }

        public async Task<User> CreateUser(string username, string email, string password)
        {
            var repo = new User
            {
                userName=username,
                email=email,
                password= password
            };

            var result = await RequestConstants.BaseUrl
                .AppendPathSegments("users")
                .WithHeader(RequestConstants.UserAgent, RequestConstants.UserAgentValue)
                 .WithBasicAuth(_admin, _adminPassword)
                //.WithOAuthBearerToken(_adminToken)
                .PostJsonAsync(repo)
                .ReceiveJson<User>();

            return result;
        }

        public async Task<User> UpdateUser(int id, string mail)
        {
            var temp = new User
            {
                id=id,
                email=mail
            };

            var result = await RequestConstants.BaseUrl
                .AppendPathSegments($"users/{id}")
                .WithHeader(RequestConstants.UserAgent, RequestConstants.UserAgentValue)
                .WithBasicAuth(_admin, _adminPassword)
                //.WithOAuthBearerToken(_adminToken)
                .PostJsonAsync(temp)
                .ReceiveJson<User>();

            return result;
        }

        public async Task<HttpResponseMessage> DeleteUser(int id, int reassign)
        {
            var result = await RequestConstants.BaseUrl
                .AppendPathSegments($"users/{id}?force=true&reassign={reassign}")
                .WithHeader(RequestConstants.UserAgent, RequestConstants.UserAgentValue)
                .WithBasicAuth(_admin, _adminPassword)
                //.WithOAuthBearerToken(_adminToken)
                .DeleteAsync();

            return result;
        }
    }
}