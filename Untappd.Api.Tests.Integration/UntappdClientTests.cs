using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Untappd.Api.Tests.Integration
{
    [TestClass]
    public class UntappdClientTests
    {
        const string AccessToken = "716709B5F5EF67657B298A546F85CA62923687F3";

        [TestMethod]
        public async Task GetNotifications_ReturnsListOfNotifications()
        {
            
            var client = new UntappdClient(AccessToken);

            var notifications = await client.GetNotifications();

            Assert.IsNotNull(notifications);
        }

        [TestMethod]
        public async Task AddToWishList_AddsBeerToWishList()
        {
            var client = new UntappdClient(AccessToken);

            var wishListResponse = await client.AddToWishList(101);

            Assert.IsNotNull(wishListResponse);
        }

        [TestMethod]
        public async Task RemoveFromWishList_RemovesItem()
        {
            var client = new UntappdClient(AccessToken);


            //Responds with 200 but doesnt seem to do anything??
            var notifications = await client.RemovefromWishList(101);

            Assert.IsNotNull(notifications);
        }

        [TestMethod]
        public async Task GetTrending_ReturnsTrendingBeers()
        {
            var client = new UntappdClient(AccessToken);

            var trendingResponse = await client.GetTrending();

            Assert.IsNotNull(trendingResponse);
        }

        [TestMethod]
        public async Task GetUserInfo_ReturnsUserInfo()
        {
            var client = new UntappdClient(AccessToken);

            var userInfoResponse = await client.GetUserInfo();

            Assert.IsNotNull(userInfoResponse);
        }
    }
}
