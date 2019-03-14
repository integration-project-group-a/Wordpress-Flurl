using System.Net.Http;
using Flurl;
using Flurl.Http.Testing;
using FlurlExamples;
using FlurlExamples.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlurlTests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void GetUser_ShouldHaveBeenCalled_AtLeastOnce()
        {
            using (var httpTest = new HttpTest())
            {
                var flurlRequestHandler = new FlurlRequestHandler();
                var result = flurlRequestHandler.GetUsers();

                httpTest.ShouldHaveCalled(Url.Combine(RequestConstants.BaseUrl, "users"))
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
            }
        }

        [TestMethod]
        public void CreateUser_ShouldHaveBeenCalled_AtLeastOnce()
        {
            using (var httpTest = new HttpTest())
            {
                var flurlRequestHandler = new FlurlRequestHandler();
                var result = flurlRequestHandler.CreateUser("testUsername", "test@gmail.com", "password");

                httpTest.ShouldHaveCalled(Url.Combine(RequestConstants.BaseUrl, "testUsername", "test@gmail.com", "password"))
                    .WithVerb(HttpMethod.Post)
                    .Times(1);
            }
        }

        [TestMethod]
        public void UpdateUser_ShouldHaveBeenCalled_AtLeastOnce()
        {
            using (var httpTest = new HttpTest())
            {
                var flurlRequestHandler = new FlurlRequestHandler();
                var result = flurlRequestHandler.UpdateUser(2,"test@gmail.com");

                httpTest.ShouldHaveCalled(Url.Combine(RequestConstants.BaseUrl, "2", "test@gmail.com"))
                    .WithVerb(new HttpMethod("PATCH"))
                    .Times(1);
            }
        }

        [TestMethod]
        public void DeleteUser_ShouldHaveBeenCalled_AtLeastOnce()
        {
            using (var httpTest = new HttpTest())
            {
                var flurlRequestHandler = new FlurlRequestHandler();
                var result = flurlRequestHandler.DeleteUser(2,1);

                httpTest.ShouldHaveCalled(Url.Combine(RequestConstants.BaseUrl, "user", "2", "1"))
                    .WithVerb(HttpMethod.Delete)
                    .Times(1);
            }
        }
    }
}
