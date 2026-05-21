using System;

class Program
{
    static void Main()
    {
        Console.Write("Podaj liczbę ocen: ");
        int liczbaOcen = Convert.ToInt32(Console.ReadLine());

        double sumaOcen = 0;

        for (int i = 0; i < liczbaOcen; i++)
        {
            while (true)
            {
                Console.Write($"Podaj ocenę {i + 1}: ");
                double ocena = Convert.ToDouble(Console.ReadLine());

                if (ocena == 1 || ocena == 2 || ocena == 3 || ocena == 4 || ocena == 5 || ocena == 6)
                {
                    sumaOcen += ocena;
                    break;
                }
                else
                {
                    Console.WriteLine("Błąd: Dozwolone są tylko oceny 1, 2, 3, 4, 5 lub 6. Spróbuj ponownie.");
                }
            }
        }

        if (liczbaOcen > 0)
        {
            double srednia = sumaOcen / liczbaOcen;

            //F2 to ilosc miejsc po przecinku
            Console.WriteLine($"Średnia: {srednia.ToString("F2")}");

            if (srednia >= 3.0)
            {
                Console.WriteLine("Uczeń zdał.");
            }
            else
            {
                Console.WriteLine("Uczeń nie zdał.");
            }
        }
        else
        {
            Console.WriteLine("Brak ocen do obliczenia średniej.");
        }
    }
}
