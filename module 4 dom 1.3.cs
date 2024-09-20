using System;

public interface IPrinter
{
    void Print(string content);
}

public interface IScanner
{
    void Scan(string content);
}

public interface IFax
{
    void Fax(string content);
}

public class AllInOnePrinter : IPrinter, IScanner, IFax
{
    public void Print(string content)
    {
        Console.WriteLine("Печать: " + content);
    }

    public void Scan(string content)
    {
        Console.WriteLine("Сканирование: " + content);
    }

    public void Fax(string content)
    {
        Console.WriteLine("Отправка факса: " + content);
    }
}

public class BasicPrinter : IPrinter
{
    public void Print(string content)
    {
        Console.WriteLine("Печать: " + content);
    }
}

public class SimpleScanner : IScanner
{
    public void Scan(string content)
    {
        Console.WriteLine("Сканирование: " + content);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        IPrinter printer = new BasicPrinter();
        printer.Print("Привет, мир!");

        IScanner scanner = new SimpleScanner();
        scanner.Scan("Документ");

        AllInOnePrinter allInOnePrinter = new AllInOnePrinter();
        allInOnePrinter.Print("Многофункциональный принтер");
        allInOnePrinter.Scan("Многофункциональный документ");
        allInOnePrinter.Fax("Документ для факса");
    }
}

