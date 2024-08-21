namespace CheckoutPrice
{
    public class PriceProvider : IPriceProvider
    {
        private readonly Dictionary<string, int> _prices;

        public PriceProvider(Dictionary<string, int> prices)
        {
            _prices = prices;
        }

        public int GetPrice(string item)
        {
            return _prices.TryGetValue(item, out var price) ? price : 0;
        }
    }
}
