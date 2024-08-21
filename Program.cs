
static void main()
{


}

public interface ICheckout
{
    void Scan(string item);
    int GetTotalPrice();
}

public class Checkout : ICheckout
{ 

    public void Scan(string item)
    {

    }

    public int GetTotalPrice()
    {
        return 0;
    }
}

