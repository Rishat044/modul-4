using System;
public class Order
{
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }

}

public class OrderCalculator
{
    public double CalculateTotalPrice(Order order)
    {

        return order.Quantity * order.Price * 0.9;
    }
}

public class PaymentProcessor
{
    public void ProcessPayment(string paymentDetails)
    {

        Console.WriteLine("Payment processed using: " + paymentDetails);
    }
}

public class EmailService
{
    public void SendConfirmationEmail(string email)
    {

        Console.WriteLine("Confirmation email sent to: " + email);
    }
}

public class Program
{
    public static void Main(string[] args)
    {

        Order order = new Order
        {
            ProductName = "Laptop",
            Quantity = 2,
            Price = 1000.00
        };

        OrderCalculator calculator = new OrderCalculator();
        PaymentProcessor paymentProcessor = new PaymentProcessor();
        EmailService emailService = new EmailService();

        double totalPrice = calculator.CalculateTotalPrice(order);
        Console.WriteLine("Total Price: " + totalPrice);

        paymentProcessor.ProcessPayment("Credit Card");

        emailService.SendConfirmationEmail("customer@mail.ru");
    }
}