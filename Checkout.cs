namespace CheckoutPrice
{
    public class Checkout : ICheckout
    {
        private readonly Dictionary<string, int> _checkoutItems;
        private readonly IPriceProvider _priceProvider;

        public Checkout(IPriceProvider priceProvider)
        {
            _checkoutItems = new Dictionary<string, int>();
            _priceProvider = priceProvider;
        }

        public void Scan(string item)
        {
            // Tally each item scanned
            _checkoutItems[item] = _checkoutItems.GetValueOrDefault(item, 0) + 1;
        }

        public int GetTotalPrice()
        {
            int totalPrice = 0;

            foreach (var item in _checkoutItems)
            {
                var name = item.Key;
                var quantity = item.Value;

                totalPrice += quantity * _priceProvider.GetPrice(name);
            }

            return totalPrice;
        }
    }
}
