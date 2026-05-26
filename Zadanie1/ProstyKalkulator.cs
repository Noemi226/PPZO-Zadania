using System;

class Program
{
    static void Main()
    {
        Console.Write("Podaj pierwszą liczbę: ");
        double l1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Podaj drugą liczbę: ");
        double l2 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Operatory arytmetyczne \n Dodawanie + \n Odejmowanie - \n Mnożenie * \n Dzielenie / \n Potęgowanie ^ \n Wybierz operację: ");
        string opcja = Console.ReadLine();

        if (opcja == "+")
        {
            Console.WriteLine($"Wynik: {l1 + l2}");
        }
        else if (opcja == "-")
        {
            Console.WriteLine($"Wynik: {l1 - l2}");
        }
        else if (opcja == "*")
        {
            Console.WriteLine($"Wynik: {l1 * l2}");
        }
        else if (opcja == "/")
        {
            if (l2 == 0)
            {
                Console.WriteLine("Wynik: Błąd (nie dzieli się przez zero)");
            }
            else
            {
                Console.WriteLine($"Wynik: {l1 / l2}");
            }
        }
        else if (opcja == "^")
        {
           double wynik = Math.Pow(l1, l2);
            Console.WriteLine($"Wynik: {wynik}");
        }
        else
        {
            Console.WriteLine("Wynik: Nie rozpoznano operatora");
        }
    }
}
