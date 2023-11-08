using System;
public interface IParent
{
    string Info();
    double Metod1(int n);
    double Metod2(int n);
}

public class Child1 : IParent
{
    private double a;
    private double d;
    private int n;

    public Child1(double a, double d, int n)
    {
        this.a = a;
        this.d = d;
        this.n = n;
    }

    public string Info()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        return $"Арифметичної прогресії: {Metod1(n)}, Перший член = {Math.Round(a, 2)}, різниця = {Math.Round(d, 2)}, Номер члена = {n}";
    }

    public double Metod1(int n)
    {
        return Math.Round(a + (n - 1) * d);
    }

    public double Metod2(int n)
    {
        return (n / 2) * (2 * a + (n - 1) * d);
    }
}

public class Child2 : IParent
{
    private double a;
    private double d;
    private int n;

    public Child2(double a, double d, int n)
    {
        this.a = Math.Round(a, 2);
        this.d = Math.Round(d, 2);
        this.n = n;
    }

    public string Info()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        return $"Геометричний прогрес: Перший член = {Math.Round(a, 2)}, знаменник = {Math.Round(d, 2)}, Номер члена = {n}";
    }

    public double Metod1(int n)
    {
        return Math.Round(a * Math.Pow(d, n - 1), 2);
    }

    public double Metod2(int n)
    {
        return Math.Round(a * (Math.Pow(d, n) - 1) / (d - 1), 2);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();

        for (int i = 0; i < 5; i++)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            double a = random.NextDouble() * 10;
            double d = random.NextDouble() * 5;
            int n = random.Next(1, 10);
            int x = random.Next(0, 2);

            IParent parent;

            if (x == 0)
            {
                parent = new Child1(a, d, n);
            }
            else
            {
                parent = new Child2(a, d, n);
            }

            Console.WriteLine(parent.Info());
            Console.WriteLine("n-й елемент = " + Math.Round(parent.Metod1(n), 2));
            Console.WriteLine("сума перших n елементів = " + Math.Round(parent.Metod2(n), 2));
        }
    }
}