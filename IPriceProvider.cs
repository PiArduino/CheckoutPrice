namespace CheckoutPrice
{
    public interface IPriceProvider
    {
        int GetPrice(string item);
    }
}
