using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Untappd.Api.Models;

namespace Untappd.Api
{
    internal class UntappdClient
    {
        private const string UntappdApiUrl = "http://api.untappd.com/v4/";
        private readonly string _accessToken;


        public UntappdClient(string accessToken)
        {
            _accessToken = accessToken;
        }

        public async Task<string> GetFriendFeed()
        {
            return await GetObject("checkin/recent");
        }

        public async Task<string> GetUserFeed(string userName = null, int? offSet = null, int count = 50)
        {
            IDictionary<string, string> queryParams = new Dictionary<string, string>();

            if(offSet != null)
            {
                queryParams.Add("offset", offSet.ToString());
            }

            queryParams.Add("count", count.ToString(CultureInfo.InvariantCulture));

            return await GetObject("user/checkins", queryParams);
        }

        public async Task<string> GetThePubFeed()
        {
            return await GetObject("thepub");
        }

        public async Task<string> GetVenueFeed(int venueId, int? offSet = null, int count = 50)
        {
            IDictionary<string, string> queryParams = new Dictionary<string, string>();

            if (offSet != null)
            {
                queryParams.Add("offset", offSet.ToString());
            }

            queryParams.Add("count", count.ToString(CultureInfo.InvariantCulture));

            return await GetObject("venue/checkins/" + venueId, queryParams);
        }

        public async Task<string> GetBeerFeed(int beerId)
        {
            return await GetObject("beer/info/" + beerId);
        }

        public async Task<string> GetBreweryCheckins(int breweryId, int? offSet = null, int count = 50)
        {
            IDictionary<string, string> queryParams = new Dictionary<string, string>();

            if (offSet != null)
            {
                queryParams.Add("offset", offSet.ToString());
            }

            queryParams.Add("count", count.ToString(CultureInfo.InvariantCulture));

            return await GetObject("brewery/checkings/" + breweryId, queryParams);
        }

        public async Task<string> GetBreweryInfo(int breweryId)
        {
            return await GetObject("brewery/info/" + breweryId);
        }

        public async Task<string> GetBeerInfo(int beerId)
        {
            return await GetObject("beer/info/" + beerId);
        }

        public async Task<string> GetVenueInfo(int venueId)
        {
            return await GetObject("venue/info/" + venueId);
        }

        public async Task<string> GetCheckinInfo(int checkinId)
        {
            return await GetObject("checkin/view/" + checkinId);
        }

        public async Task<string> GetUserInfo()
        {
            return await GetObject("");
        }

        public async Task<string> GetUserBadges(string userName, int? offSet = null)
        {
            IDictionary<string, string> queryParams = new Dictionary<string, string>();

            if (offSet != null)
            {
                queryParams.Add("offset", offSet.ToString());
            }

            return await GetObject("user/badges/" + userName, queryParams);
        }

        public async Task<string> GetUserFriends(string userName)
        {
            return await GetObject("user/friends/" + userName);
        }

        public async Task<string> GetUserWishList(string userName)
        {
            return await GetObject("user/wishlist/" + userName);
        }

        public async Task<string> GetUserDistinctBeers(string userName, UserSortOption? userSort = null, int? offSet = null)
        {
            IDictionary<string, string> queryParams = new Dictionary<string, string>();

            if (offSet != null)
            {
                queryParams.Add("offset", offSet.ToString());
            }
            if(userSort != null)
            {
                queryParams.Add("sort", userSort.ToString());
            }

            return await GetObject("user/beers/" + userName, queryParams);
        }

        public async Task<string> BrewerySearch(string searchTerm)
        {
            return await GetObject("search/brewwery?q=" + searchTerm);
        }

        public async Task<string> BeerSearch(string searchTerm, BeerSearchOption? beerSearchOption = null)
        {
            IDictionary<string, string> queryParams = new Dictionary<string, string>();

            if (beerSearchOption != null)
            {
                queryParams.Add("sort", beerSearchOption.ToString());
            }

            return await GetObject("search/beer?q=" + searchTerm);
        }

        public async Task<string> GetTrending()
        {
            return await GetObject("beer/trending");
        }

        public async Task<string> Checkin(CheckIn checkIn)
        {
            return await GetObject("checkin/add");
        }

        public async Task<string> AddComment(int checkInId, string comment)
        {
            IDictionary<string, string> queryParams = new Dictionary<string, string>();

            queryParams.Add("comment", comment);


            return await GetObject("checkin/addcomment/", queryParams);
        }

        public async Task<string> RemoveComment(int commentId)
        {
            return await GetObject("checkin/deletecomment/" + commentId);
        }

        public async Task<string> ToastRemoveToast(int checkInId)
        {
            return await GetObject("checkin/toast/" + checkInId);
        }

        public async Task<string> AddToWishList(int beerId)
        {
            return await GetObject("user/wishlist/add");
        }

        public async Task<string> RemovefromWishList(int beerId)
        {
            return await GetObject("user/wishlist/remove");
        }

        public async Task<string> GetPendingFriends()
        {
            return await GetObject("user/pending");
        }

        public async Task<string> AcceptFriends(int friendId)
        {
            return await GetObject("friend/accept/" + friendId);
        }

        public async Task<string> RejectFriends(int friendId)
        {
            return await GetObject("friend/reject/" + friendId);
        }

        public async Task<string> RemoveFriends(int friendId)
        {
            return await GetObject("friend/remove/" + friendId);
        }

        public async Task<string> GetRequestFriends(int friendId)
        {
            return await GetObject("friend/request/" + friendId);
        }

        public async Task<string> GetNotifications()
        {
            return await GetObject("notifications");
        }

        public async Task<string> FoursquareVenueLookup(int venueId)
        {
            return await GetObject("venue/foursquare_lookup/" + venueId);
        }


        private async Task<string> GetObject(string apiUrlAction, IEnumerable<KeyValuePair<string, string>> queryParams = null)
        {
            using (var client = new HttpClient())
            {
                string requestUri = string.Format("{0}{1}?accessToken={2}", UntappdApiUrl, apiUrlAction, _accessToken);

                if(queryParams != null)
                {
                    requestUri = queryParams.Aggregate(requestUri, (current, queryParam) => current + string.Format("&{0}={1}", queryParam.Key, queryParam.Value));
                }

                HttpResponseMessage response = await client.GetAsync(requestUri);

                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}