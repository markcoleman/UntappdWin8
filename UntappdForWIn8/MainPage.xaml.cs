﻿using System;
using System.Collections.Generic;
using System.Linq;
using Untappd.Api;
using UntappdForWIn8.Common;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UntappdForWIn8
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage :  UntappdForWIn8.Common.LayoutAwarePage
    {
        

        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override async void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            var client = new Untappd.Api.UntappdClient(Configuration.AccessToken);
            var response = await client.GetFriendFeed();
            var list = response.Checkins.Items.Select(i => new
                                                               {
                                                                   Title = i.Beer.BeerName, 
                                                                   Subtitle = i.User.FirstName + " " + i.User.LastName
                                                               }).ToList();
            this.DefaultViewModel["friendBeers"] = list;

            var u = await client.GetUserFeed();

            this.DefaultViewModel["userFeed"] = response.Checkins.Items;
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }

        private void ResultsGridView_OnItemClick(object sender, ItemClickEventArgs e)
        {
           
        }
    }
}
