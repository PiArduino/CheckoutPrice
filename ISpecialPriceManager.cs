namespace CheckoutPrice
{
    public interface ISpecialPriceManager
    {
        int ApplyOffer(string item, int quantity, int unitPrice);
    }
}
