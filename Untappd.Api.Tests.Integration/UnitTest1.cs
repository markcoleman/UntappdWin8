using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Untappd.Api.Tests.Integration
{
    [TestClass]
    public class UnitTest1
    {
        const string AccessToken = "716709B5F5EF67657B298A546F85CA62923687F3";

        [TestMethod]
        public void TestMethod1()
        {
            
            var client = new UntappdClient(AccessToken);

            var notifications = client.GetNotifications().Result;

            Assert.IsNotNull(notifications);
        }

        [TestMethod]
        public void AddWishList()
        {
            var client = new UntappdClient(AccessToken);

            var wishListResponse = client.AddToWishList(101).Result;

            Assert.IsNotNull(wishListResponse);
        }

        [TestMethod]
        public void RemoveWishList()
        {
            var client = new UntappdClient(AccessToken);


            //Responds with 200 but doesnt seem to do anything??
            //var notifications = client.RemovefromWishList(101).Result;

            //Assert.IsNotNull(notifications);
        }

        [TestMethod]
        public void Trending()
        {
            var client = new UntappdClient(AccessToken);

            var trendingResponse = client.GetTrending().Result;

            Assert.IsNotNull(trendingResponse);
        }

        [TestMethod]
        public void UserInfo()
        {
            var client = new UntappdClient(AccessToken);

            var userInfoResponse = client.GetUserInfo().Result;

            Assert.IsNotNull(userInfoResponse);
        }
    }
}
