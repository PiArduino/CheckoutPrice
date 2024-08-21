namespace CheckoutPrice
{
    public class SpecialPriceProvider : ISpecialPriceProvider
    {
        private readonly int _quantityRequired;
        private readonly int _specialPrice;

        public SpecialPriceProvider(int quantityRequired, int specialPrice)
        {
            _quantityRequired = quantityRequired;
            _specialPrice = specialPrice;
        }

        // Given item's unit price and quantity, apply the special price offer
        // and any remaining at usual price
        public int ApplyOffer(int quantity, int unitPrice)
        {
            if (quantity < _quantityRequired)
            {
                // Not enough for special price
                return quantity * unitPrice;
            }

            // Get number of special prices from quantity 
            int countOfSpecialPrices = quantity / _quantityRequired;

            // Get remaining quantity 
            int remainingQuantity = quantity % _quantityRequired;

            // Return the total
            return (countOfSpecialPrices * _specialPrice) + (remainingQuantity * unitPrice);  
        }
    }

}
