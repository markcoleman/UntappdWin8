using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Untappd.Api.Models;

namespace Untappd.Api
{
    public class UntappdClient
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

        public async Task<UserInfoResponse> GetUserInfo()
        {
            return await GetObject < UserInfoResponse>("user/info");
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

        public async Task<TrendingResponse> GetTrending()
        {
            return await GetObject < TrendingResponse>("beer/trending");
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

        public async Task<AddOrRemoveFromWishListResponse> AddToWishList(int beerId)
        {
            const string userWishlistAdd = "user/wishlist/add";
            return await WishListAction(beerId, userWishlistAdd);
        }

        private async Task<AddOrRemoveFromWishListResponse> WishListAction(int beerId, string userWishlistAdd)
        {
            IDictionary<string, string> queryParams = new Dictionary<string, string>();

            queryParams.Add("bid", beerId.ToString(CultureInfo.InvariantCulture));


            return await GetObject<AddOrRemoveFromWishListResponse>(userWishlistAdd, queryParams);
        }

        public async Task<AddOrRemoveFromWishListResponse> RemovefromWishList(int beerId)
        {
            string userWishlistRemove = "user/wishlist/remove";
            return await WishListAction(beerId, userWishlistRemove);
        }

        public async Task<PendingFriendResponse> GetPendingFriends()
        {
            var s = await GetObject("user/pending");

            var o = JObject.Parse(s);


            return o.ToObject<PendingFriendResponse>();
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

        public async Task<NotificationsResponse> GetNotifications()
        {
            Dictionary<string, string> p = new Dictionary<string, string>();
            p.Add("client_id", "24B1A8A8AD25CD58E5FEE94F1351153982FB2171");
            p.Add("client_secret", "550ED8E016E29B9AECFBE1FA9F2D977D07B40AF5");


            string s = await GetObject("notifications", p);

            JToken jObject = JObject.Parse(s)["response"];


            return jObject.ToObject<NotificationsResponse>();
        }

        public async Task<string> FoursquareVenueLookup(int venueId)
        {
            return await GetObject("venue/foursquare_lookup/" + venueId);
        }


        private async Task<string> GetObject(string apiUrlAction, IEnumerable<KeyValuePair<string, string>> queryParams = null)
        {
            using (var client = new HttpClient())
            {
                string requestUri = string.Format("{0}{1}/?access_token={2}", UntappdApiUrl, apiUrlAction, _accessToken);

                if(queryParams != null)
                {
                    requestUri = queryParams.Aggregate(requestUri, (current, queryParam) => current + string.Format("&{0}={1}", queryParam.Key, queryParam.Value));
                }

                HttpResponseMessage response = await client.GetAsync(requestUri);

                return await response.Content.ReadAsStringAsync();
            }
        }

        private async Task<T> GetObject<T>(string apiUrlAction, IEnumerable<KeyValuePair<string, string>> queryParams = null)
        {
            using (var client = new HttpClient())
            {
                string requestUri = string.Format("{0}{1}/?access_token={2}", UntappdApiUrl, apiUrlAction, _accessToken);

                if (queryParams != null)
                {
                    requestUri = queryParams.Aggregate(requestUri, (current, queryParam) => current + string.Format("&{0}={1}", queryParam.Key, queryParam.Value));
                }

                HttpResponseMessage response = await client.GetAsync(requestUri);

                var s = await response.Content.ReadAsStringAsync();

                JToken o = JObject.Parse(s)["meta"];
                var meta = o.ToObject<Meta>();

                if(meta.Code == 500)
                {
                    throw new InvalidOperationException(string.Format("ErrorType: {0} Detail: {1}", meta.ErrorType, meta.ErrorDetail));
                }

                JToken jObject = JObject.Parse(s)["response"];
                return jObject.ToObject<T>();
            }
        }
    }
}