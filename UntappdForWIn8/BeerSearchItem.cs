using Untappd.Api.Models;

namespace UntappdForWIn8
{
    public class BeerSearchItem
    {
        private readonly string _title;
        private readonly string _subtitle;
        private readonly string _description;
        private readonly string _image;
        private readonly TrendingBeerDetails _beerItem;

        public string Title
        {
            get { return _title; }
        }

        public string Subtitle
        {
            get { return _subtitle; }
        }

        public string Description
        {
            get { return _description; }
        }

        public string Image
        {
            get { return _image; }
        }

        public TrendingBeerDetails BeerItem
        {
            get { return _beerItem; }
        }

        public BeerSearchItem(string title, string subtitle, string description, string image, TrendingBeerDetails beerItem)
        {
            _title = title;
            _subtitle = subtitle;
            _description = description;
            _image = image;
            _beerItem = beerItem;
        }
    }
}