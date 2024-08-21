namespace CheckoutPrice
{
    public interface ISpecialPriceProvider
    {
        int ApplyOffer(int quantity, int unitPrice);
    }
}
