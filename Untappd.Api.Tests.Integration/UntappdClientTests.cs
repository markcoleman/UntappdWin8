using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Untappd.Api.Models;

namespace Untappd.Api.Tests.Integration
{
    [TestClass]
    public class UntappdClientTests
    {
        private const string AccessToken = Configuration.AccessToken;

        [TestMethod]
        public async Task GetNotifications_ReturnsListOfNotifications()
        {
            var client = new UntappdClient(AccessToken);

            NotificationsResponse notifications = await client.GetNotifications();

            Assert.IsNotNull(notifications);
        }

        [TestMethod]
        public async Task AddToWishList_AddsBeerToWishList()
        {
            var client = new UntappdClient(AccessToken);

            AddOrRemoveFromWishListResponse wishListResponse = await client.AddToWishList(101);

            Assert.IsNotNull(wishListResponse);
        }

        [TestMethod]
        public async Task RemoveFromWishList_RemovesItem()
        {
            var client = new UntappdClient(AccessToken);


            //Responds with 200 but doesnt seem to do anything??
            AddOrRemoveFromWishListResponse notifications = await client.RemovefromWishList(101);

            Assert.IsNotNull(notifications);
        }

        [TestMethod]
        public async Task GetTrending_ReturnsTrendingBeers()
        {
            var client = new UntappdClient(AccessToken);

            TrendingResponse trendingResponse = await client.GetTrending();

            Assert.IsNotNull(trendingResponse);
        }

        [TestMethod]
        public async Task GetUserInfo_ReturnsUserInfo()
        {
            UntappdClient client = GetClient();

            UserInfoResponse userInfoResponse = await client.GetUserInfo();

            Assert.IsNotNull(userInfoResponse);
        }

        private static UntappdClient GetClient()
        {
            return new UntappdClient(AccessToken);
        }

        [TestMethod]
        public async Task BeerSearch_WithQuery()
        {
            UntappdClient client = GetClient();

            BeerSearchResponse beers = await client.BeerSearch("Stillwater artisanal");

            Assert.IsNotNull(beers);
        }

        [TestMethod]
        public async Task Checkin_With()
        {
            UntappdClient client = GetClient();

            var checkIn = new CheckIn
                              {
                                  BeerId = 107931,
                                  GmtOffset = -5,
                                  TimeZone = "EST",
                                  Rating = BeerRating.ThreeStars
                              };
            CheckinResponse r = await client.Checkin(checkIn);

            Assert.IsNotNull(r);
        }

        [TestMethod]
        public async Task GetFriendFeed()
        {
            UntappdClient client = GetClient();

            var r = await client.GetFriendFeed();

            Assert.IsNotNull(r);
        }

        [TestMethod]
        public async Task GetUserFeed()
        {
            UntappdClient client = GetClient();

            var r = await client.GetUserFeed();

            Assert.IsNotNull(r);
        }

        [TestMethod]
        public async Task GetPubFeed()
        {
            UntappdClient client = GetClient();

            var r = await client.GetThePubFeed();

            Assert.IsNotNull(r);
        }

        [TestMethod]
        public async Task GetVenueFeed()
        {
            UntappdClient client = GetClient();

            var r = await client.GetVenueFeed(25423);

            Assert.IsNotNull(r);
        }

        [TestMethod]
        public async Task GetBeerFeed()
        {
            UntappdClient client = GetClient();

            var r = await client.GetBeerFeed(9257);

            Assert.IsNotNull(r);
        }

        [TestMethod]
        public async Task GetBreweryCheckins()
        {
            UntappdClient client = GetClient();

            var r = await client.GetBreweryCheckins(1658);

            Assert.IsNotNull(r);
        }
    }
}