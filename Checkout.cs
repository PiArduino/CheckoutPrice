namespace CheckoutPrice
{
    public class Checkout : ICheckout
    {
        private readonly Dictionary<string, int> _checkoutItems;
        private readonly IPriceProvider _priceProvider;
        private readonly ISpecialPriceManager _specialPriceManager;

        public Checkout(IPriceProvider priceProvider, ISpecialPriceManager specialPriceManager)
        {
            _checkoutItems = new Dictionary<string, int>();
            _priceProvider = priceProvider;
            _specialPriceManager = specialPriceManager; 
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
                var unitPrice = _priceProvider.GetPrice(name);

                totalPrice += _specialPriceManager.ApplyOffer(name, quantity, unitPrice);
            }

            return totalPrice;
        }
    }
}
