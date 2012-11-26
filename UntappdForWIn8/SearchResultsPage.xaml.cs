using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Untappd.Api;
using Untappd.Api.Models;
using UntappdForWIn8.Common;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Search Contract item template is documented at http://go.microsoft.com/fwlink/?LinkId=234240

namespace UntappdForWIn8
{
    /// <summary>
    ///     This page displays search results when a global search is directed to this application.
    /// </summary>
    public sealed partial class SearchResultsPage : LayoutAwarePage
    {
        

        public SearchResultsPage()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Populates the page with content passed during navigation.  Any saved state is also
        ///     provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">
        ///     The parameter value passed to
        ///     <see cref="Frame.Navigate(Type, Object)" /> when this page was initially requested.
        /// </param>
        /// <param name="pageState">
        ///     A dictionary of state preserved by this page during an earlier
        ///     session.  This will be null the first time a page is visited.
        /// </param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            var searchTerm = navigationParameter as String;

            // TODO: Application-specific searching logic.  The search process is responsible for
            //       creating a list of user-selectable result categories:
            //
            //       filterList.Add(new Filter("<filter name>", <result count>));
            //
            //       Only the first filter, typically "All", should pass true as a third argument in
            //       order to start in an active state.  Results for the active filter are provided
            //       in Filter_SelectionChanged below.

            var filterList = new List<Filter>
                                 {
                                     new Filter("Beer", 0, true)
                                 };
            // Communicate results through the view model
            DefaultViewModel["QueryText"] = '\u201c' + searchTerm + '\u201d';
            DefaultViewModel["Filters"] = filterList;
            DefaultViewModel["ShowFilters"] = filterList.Count > 1;
        }


        

        /// <summary>
        ///     Invoked when a filter is selected using the ComboBox in snapped view state.
        /// </summary>
        /// <param name="sender">The ComboBox instance.</param>
        /// <param name="e">Event data describing how the selected filter was changed.</param>
        public async void Filter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Determine what filter was selected
            var selectedFilter = e.AddedItems.FirstOrDefault() as Filter;
            if (selectedFilter != null)
            {
                // Mirror the results into the corresponding Filter object to allow the
                // RadioButton representation used when not snapped to reflect the change
                selectedFilter.Active = true;

                // TODO: Respond to the change in active filter by setting this.DefaultViewModel["Results"]
                //       to a collection of items with bindable Image, Title, Subtitle, and Description properties

                var client = new UntappdClient(Configuration.AccessToken);

                BeerSearchResponse beers = await client.BeerSearch(DefaultViewModel["QueryText"].ToString());

                DefaultViewModel["Results"] = beers.Beers.Items.Select(b => new BeerSearchItem(b.Beer.BeerName, b.Brewery.BreweryName, b.Beer.BeerStyle, b.Beer.BeerLabel, b)).ToList();

                // Ensure results are found
                object results;
                ICollection resultsCollection;
                bool tryGetValue = DefaultViewModel.TryGetValue("Results", out results);
                ICollection collection = resultsCollection = results as ICollection;
                if (tryGetValue &&
                    collection != null &&
                    resultsCollection.Count != 0)
                {
                    VisualStateManager.GoToState(this, "ResultsFound", true);
                    return;
                }
            }

            // Display informational text when there are no search results.
            VisualStateManager.GoToState(this, "NoResultsFound", true);
        }

        /// <summary>
        ///     Invoked when a filter is selected using a RadioButton when not snapped.
        /// </summary>
        /// <param name="sender">The selected RadioButton instance.</param>
        /// <param name="e">Event data describing how the RadioButton was selected.</param>
        private void Filter_Checked(object sender, RoutedEventArgs e)
        {
            // Mirror the change into the CollectionViewSource used by the corresponding ComboBox
            // to ensure that the change is reflected when snapped
            if (filtersViewSource.View != null)
            {
                object filter = (sender as FrameworkElement).DataContext;
                filtersViewSource.View.MoveCurrentTo(filter);
            }
        }

        private void ResultsGridView_OnItemClick(object sender, ItemClickEventArgs e)
        {
            //got the beer, send to details page.

            BeerSearchItem item = e.ClickedItem as BeerSearchItem;

            this.Frame.Navigate(typeof (BeerDetailsPage), item);
        }

        /// <summary>
        ///     View model describing one of the filters available for viewing search results.
        /// </summary>
        private sealed class Filter : BindableBase
        {
            private bool _active;
            private int _count;
            private String _name;

            public Filter(String name, int count, bool active = false)
            {
                Name = name;
                Count = count;
                Active = active;
            }

            public String Name
            {
                get { return _name; }
                set { if (SetProperty(ref _name, value)) OnPropertyChanged("Description"); }
            }

            public int Count
            {
                get { return _count; }
                set { if (SetProperty(ref _count, value)) OnPropertyChanged("Description"); }
            }

            public bool Active
            {
                get { return _active; }
                set { SetProperty(ref _active, value); }
            }

            public String Description
            {
                get { return String.Format("{0} ({1})", _name, _count); }
            }

            public override String ToString()
            {
                return Description;
            }
        }
    }
}