namespace CheckoutPrice
{
    public class SpecialPriceManager : ISpecialPriceManager
    {
        private readonly Dictionary<string, SpecialPriceProvider> _specialOffers;

        public SpecialPriceManager(Dictionary<string, SpecialPriceProvider> specialOffers)
        {
            _specialOffers = specialOffers;
        }

        public int ApplyOffer(string item, int quantity, int unitPrice)
        {
            if (_specialOffers.TryGetValue(item, out var offer))
            {
                // Item has a special offer
                return offer.ApplyOffer(quantity, unitPrice);
            }

            // Item has no special offer
            return quantity * unitPrice;
        }
    }
}
