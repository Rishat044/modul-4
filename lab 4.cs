using System;
using System.Collections.Generic;

public class Invoice
{
    public int Id { get; set; }
    public List<Item> Items { get; set; } = new List<Item>();
    public double TaxRate { get; set; }
}

public class InvoiceCalculator
{
    public double CalculateTotal(Invoice invoice)
    {
        double subTotal = 0;
        foreach (var item in invoice.Items)
        {
            subTotal += item.Price;
        }
        return subTotal + (subTotal * invoice.TaxRate);
    }
}

public class InvoiceRepository
{
    public void SaveToDatabase(Invoice invoice)
    {

        Console.WriteLine($"Invoice with ID {invoice.Id} saved to database.");
    }
}

public class Item
{
    public string Name { get; set; }
    public double Price { get; set; }
}

public class Program
{
    public static void Main(string[] args)
    {

        Invoice invoice = new Invoice
        {
            Id = 1,
            TaxRate = 0.2 // 20% налог
        };
   
        invoice.Items.Add(new Item { Name = "Товар 1", Price = 100 });
        invoice.Items.Add(new Item { Name = "Товар 2", Price = 200 });
        

        InvoiceCalculator calculator = new InvoiceCalculator();
        double total = calculator.CalculateTotal(invoice);
        Console.WriteLine($"Общая стоимость: {total}");

        InvoiceRepository repository = new InvoiceRepository();
        repository.SaveToDatabase(invoice);
    }
}



#-----------------------------------------------------------------------------------

using System;

public interface IDiscountStrategy
{
    double CalculateDiscount(double amount);
}


public class RegularCustomerDiscount : IDiscountStrategy
{
    public double CalculateDiscount(double amount) => amount; // Без скидки
}




public class SilverCustomerDiscount : IDiscountStrategy
{
    public double CalculateDiscount(double amount) => amount * 0.9; // 10% скидка
}





public class GoldCustomerDiscount : IDiscountStrategy
{
    public double CalculateDiscount(double amount) => amount * 0.8; // 20% скидка
}




public class PlatinumCustomerDiscount : IDiscountStrategy
{
    public double CalculateDiscount(double amount) => amount * 0.7; // 30% скидка
}




public class DiscountCalculator
{
    private readonly IDiscountStrategy _discountStrategy;

    public DiscountCalculator(IDiscountStrategy discountStrategy)
    {
        _discountStrategy = discountStrategy;
    }

    public double CalculateDiscount(double amount)
    {
        return _discountStrategy.CalculateDiscount(amount);
    }
}




public class Program
{
    public static void Main(string[] args)
    {
        double amount = 1000;

        DiscountCalculator regularDiscountCalculator = new DiscountCalculator(new RegularCustomerDiscount());
        Console.WriteLine($"Скидка для обычного клиента: {regularDiscountCalculator.CalculateDiscount(amount)}");




        DiscountCalculator silverDiscountCalculator = new DiscountCalculator(new SilverCustomerDiscount());
        Console.WriteLine($"Скидка для серебряного клиента: {silverDiscountCalculator.CalculateDiscount(amount)}");



        DiscountCalculator goldDiscountCalculator = new DiscountCalculator(new GoldCustomerDiscount());
        Console.WriteLine($"Скидка для золотого клиента: {goldDiscountCalculator.CalculateDiscount(amount)}");



        DiscountCalculator platinumDiscountCalculator = new DiscountCalculator(new PlatinumCustomerDiscount());
        Console.WriteLine($"Скидка для платинового клиента: {platinumDiscountCalculator.CalculateDiscount(amount)}");
    }
}


# RegularCustomerDiscount: Без скидки.
# SilverCustomerDiscount: 10% скидка.
# GoldCustomerDiscount: 20% скидка.
# PlatinumCustomerDiscount: 30% скидка.
#-----------------------------------------------------------------------------------


using System;
public interface IWorker
{
    void Work();
}
public interface IEater
{
    void Eat();
}
public interface ISleeper
{
    void Sleep();
}


public class HumanWorker : IWorker, IEater, ISleeper
{
    public void Work()
    {
        Console.WriteLine("Человек работает.");
    }

    public void Eat()
    {
        Console.WriteLine("Человек ест.");
    }

    public void Sleep()
    {
        Console.WriteLine("Человек спит.");
    }
}

public class RobotWorker : IWorker
{
    public void Work()
    {
        Console.WriteLine("Робот работает.");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        HumanWorker human = new HumanWorker();
        human.Work();
        human.Eat();
        human.Sleep();

        RobotWorker robot = new RobotWorker();
        robot.Work();
    }
}

#---------------------------------------------------------------

using System;

public interface INotificationSender
{
    void Send(string message);
}

public class EmailSender : INotificationSender
{
    public void Send(string message)
    {
        Console.WriteLine("Email отправлен: " + message);
    }
}

public class SmsSender : INotificationSender
{
    public void Send(string message)
    {
        Console.WriteLine("SMS отправлено: " + message);
    }
}

public class NotificationService
{
    private readonly INotificationSender _notificationSender;

    public NotificationService(INotificationSender notificationSender)
    {
        _notificationSender = notificationSender;
    }

    public void SendNotification(string message)
    {
        _notificationSender.Send(message);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        INotificationSender emailSender = new EmailSender();
        NotificationService emailNotificationService = new NotificationService(emailSender);
        emailNotificationService.SendNotification("Привет! Это уведомление по Email.");

        INotificationSender smsSender = new SmsSender();
        NotificationService smsNotificationService = new NotificationService(smsSender);
        smsNotificationService.SendNotification("Привет! Это уведомление по SMS.");
    }
}