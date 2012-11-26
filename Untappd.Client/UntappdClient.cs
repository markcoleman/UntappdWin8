using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
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

        public async Task<CheckinFeedResponse> GetFriendFeed()
        {
            return await GetObject<CheckinFeedResponse>("checkin/recent");
        }

        public async Task<CheckinFeedResponse> GetUserFeed(string userName = null, int? offSet = null, int count = 25)
        {
            IDictionary<string, string> queryParams = new Dictionary<string, string>();

            if (offSet != null)
            {
                queryParams.Add("offset", offSet.ToString());
            }

            if (!string.IsNullOrEmpty(userName))
            {
                queryParams.Add("userName", userName);
            }

            queryParams.Add("limit", count.ToString(CultureInfo.InvariantCulture));

            return await GetObject<CheckinFeedResponse>("user/checkins", queryParams);
        }

        public async Task<CheckinFeedResponse> GetThePubFeed(PublicFeedQuery query = null)
        {
            IDictionary<string, string> queryParams = new Dictionary<string, string>();
            if (query != null)
            {
                if (query.Offset.HasValue)
                {
                    queryParams.Add("offset", query.Offset.ToString());
                }

                if (query.Count.HasValue)
                {
                    queryParams.Add("limit", query.Count.ToString());
                }
                if (query.Since.HasValue)
                {
                    queryParams.Add("since", query.Since.ToString());
                }
                if (query.Radius.HasValue)
                {
                    queryParams.Add("radius", query.Radius.ToString());
                }
                if (query.Latitude.HasValue && query.Longitude.HasValue)
                {
                    queryParams.Add("lng", query.Longitude.ToString());
                    queryParams.Add("lat", query.Latitude.ToString());
                }
            }
            return await GetObject<CheckinFeedResponse>("thepub", queryParams);
        }

        public async Task<CheckinFeedResponse> GetVenueFeed(int venueId, int? since = null, int? offSet = null, int count = 25)
        {
            IDictionary<string, string> queryParams = new Dictionary<string, string>();

            if (offSet != null)
            {
                queryParams.Add("offset", offSet.ToString());
            }

            if (since != null)
            {
                queryParams.Add("since", since.ToString());
            }
            queryParams.Add("count", count.ToString(CultureInfo.InvariantCulture));

            return await GetObject < CheckinFeedResponse>("venue/checkins/" + venueId, queryParams);
        }

        public async Task<string> GetBeerFeed(int beerId, int? since = null, int? offSet = null, int count = 25)
        {
            IDictionary<string, string> queryParams = new Dictionary<string, string>();

            if (offSet != null)
            {
                queryParams.Add("offset", offSet.ToString());
            }

            if (since != null)
            {
                queryParams.Add("since", since.ToString());
            }
            queryParams.Add("count", count.ToString(CultureInfo.InvariantCulture));

            return await GetObject("beer/info/" + beerId, queryParams);
           
        }

        public async Task<string> GetBreweryCheckins(int breweryId, int? since = null, int? offSet = null, int count = 25)
        {
            IDictionary<string, string> queryParams = new Dictionary<string, string>();

            if (offSet != null)
            {
                queryParams.Add("offset", offSet.ToString());
            }

            if (since != null)
            {
                queryParams.Add("since", since.ToString());
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
            return await GetObject<UserInfoResponse>("user/info");
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

        public async Task<string> GetUserDistinctBeers(string userName, UserSortOption? userSort = null,
                                                       int? offSet = null)
        {
            IDictionary<string, string> queryParams = new Dictionary<string, string>();

            if (offSet != null)
            {
                queryParams.Add("offset", offSet.ToString());
            }
            if (userSort != null)
            {
                queryParams.Add("sort", userSort.ToString());
            }

            return await GetObject("user/beers/" + userName, queryParams);
        }

        public async Task<string> BrewerySearch(string searchTerm)
        {
            return await GetObject("search/brewwery?q=" + searchTerm);
        }

        public async Task<BeerSearchResponse> BeerSearch(string searchTerm, BeerSearchOption? beerSearchOption = null)
        {
            var queryParams = new Dictionary<string, string>();


            if (beerSearchOption != null)
            {
                queryParams.Add("sort", beerSearchOption.ToString());
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                queryParams.Add("q", searchTerm);
            }


            return await GetObject<BeerSearchResponse>("search/beer", queryParams);
        }

        public async Task<TrendingResponse> GetTrending()
        {
            return await GetObject<TrendingResponse>("beer/trending");
        }

        public async Task<CheckinResponse> Checkin(CheckIn checkIn)
        {
            var queryParams = new Dictionary<string, string>
                                  {
                                      {
                                          "gmt_offset",
                                          checkIn.GmtOffset.ToString(
                                              CultureInfo.InvariantCulture)
                                      },
                                      {"timezone", checkIn.TimeZone},
                                      {
                                          "bid",
                                          checkIn.BeerId.ToString(CultureInfo.InvariantCulture)
                                      }
                                  };

            if (!string.IsNullOrEmpty(checkIn.FourSquareId))
            {
                queryParams.Add("foursquare_id", checkIn.FourSquareId);
            }

            if (checkIn.GeoLat.HasValue && checkIn.GeoLng.HasValue)
            {
                queryParams.Add("geolat", checkIn.GeoLat.ToString());
                queryParams.Add("geolng", checkIn.GeoLng.ToString());
            }
            if (!string.IsNullOrEmpty(checkIn.Shout))
            {
                queryParams.Add("shout", checkIn.Shout);
            }

            if (checkIn.Rating.HasValue)
            {
                queryParams.Add("rating ", ((int) checkIn.Rating).ToString(CultureInfo.InvariantCulture));
            }

            if (checkIn.PostToFacebook)
            {
                queryParams.Add("facebook ", "on");
            }

            if (checkIn.PostToTwitter)
            {
                queryParams.Add("twitter ", "on");
            }
            if (checkIn.PostToFourSquare)
            {
                queryParams.Add("foursquare ", "on");
            }

            return await PostObject<CheckinResponse>("checkin/add", queryParams);
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
            string s = await GetObject("user/pending");

            JObject o = JObject.Parse(s);


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
            var queryParams = new Dictionary<string, string>
                                  {
                                      {"client_id", Configuration.ClientId},
                                      {"client_secret", Configuration.ClientSecret}
                                  };

            return await GetObject<NotificationsResponse>("notifications", queryParams);
        }

        public async Task<string> FoursquareVenueLookup(int venueId)
        {
            return await GetObject("venue/foursquare_lookup/" + venueId);
        }


        private async Task<string> GetObject(string apiUrlAction,
                                             IEnumerable<KeyValuePair<string, string>> queryParams = null
            )
        {
            using (var client = new HttpClient())
            {
                string requestUri = string.Format("{0}{1}/?access_token={2}", UntappdApiUrl, apiUrlAction, _accessToken);

                if (queryParams != null)
                {
                    requestUri = queryParams.Aggregate(requestUri,
                                                       (current, queryParam) =>
                                                       current +
                                                       string.Format("&{0}={1}", queryParam.Key, queryParam.Value));
                }


                HttpResponseMessage response = await client.GetAsync(requestUri);

                return await HandleResponse(response);
            }
        }

        private async Task<T> GetObject<T>(string apiUrlAction,
                                           IEnumerable<KeyValuePair<string, string>> queryParams = null,
                                           bool? post = false)
        {
            string apiResponse = await GetObject(apiUrlAction, queryParams);

            JToken responseToken = JObject.Parse(apiResponse)["response"];
            return responseToken.ToObject<T>();
        }

        private async Task<T> PostObject<T>(string apiUrlAction, IEnumerable<KeyValuePair<string, string>> postParams)
        {
            string apiResponse = await PostObject(apiUrlAction, postParams);

            JToken responseToken = JObject.Parse(apiResponse)["response"];
            return responseToken.ToObject<T>();
        }

        private async Task<string> PostObject(string apiUrlAction,
                                              IEnumerable<KeyValuePair<string, string>> postParams = null)
        {
            using (var client = new HttpClient())
            {
                string requestUri = string.Format("{0}{1}/?access_token={2}", UntappdApiUrl, apiUrlAction, _accessToken);


                var c = new FormUrlEncodedContent(postParams);
                HttpResponseMessage response = await client.PostAsync(requestUri, c).ContinueWith((post) =>
                                                                                                  post.Result
                                                                                                      .EnsureSuccessStatusCode
                                                                                                      ()
                                                         );


                return await HandleResponse(response);
            }
        }

        private static async Task<string> HandleResponse(HttpResponseMessage response)
        {
            string apiResponse = await response.Content.ReadAsStringAsync();

            JToken metaToken = JObject.Parse(apiResponse)["meta"];
            var meta = metaToken.ToObject<Meta>();

            if (meta.Code == 500)
            {
                string message = string.Format("ErrorType: {0} Detail: {1}", meta.ErrorType, meta.ErrorDetail);
                throw new InvalidOperationException(message);
            }

            return apiResponse;
        }
    }
}