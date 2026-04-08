using System;

public class Order
{
    private static int counter = 1;

    public int OrderNo { get; private set; }
    public string Details { get; set; }
    public int Quantity { get; set; }
    public double Bill { get; private set; }

    public Order(string details, int quantity, double price)
    {
        OrderNo = counter++;
        Details = details;
        Quantity = quantity;
        Bill = quantity * price;
    }

    public double PayBill()
    {
        return Bill;
    }

    public void CollectOrder()
    {
        Console.WriteLine($"Order Number {OrderNo} is ready! Please collect at the counter.");
    }
}
