using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Podaj 10 liczb, oddzielone spacjami:");
        string input = Console.ReadLine();
        string[] inputStrings = input.Split(' ');

        if (inputStrings.Length != 10)
        {
            Console.WriteLine("Error: Należy podać dokładnie 10 liczb.");
            return;
        }
        int[] liczby = new int[10];
        for (int i = 0; i < inputStrings.Length; i++)
        {
            liczby[i] = int.Parse(inputStrings[i]);
        }
        int[] liczby1 = liczby;
        int[] liczby2 = liczby;
        int[] liczby3 = liczby;
        int[] liczbyBubbleSort = (liczby1);
        int[] liczbyInsertionSort = (liczby2);
        int[] liczbyMergeSort = (liczby3);

        TimeSpan czasBubbleSort = SortowanieBabelkowe(liczbyBubbleSort);
        TimeSpan czasInsertionSort = SortowanieFlaga(liczbyInsertionSort);
        TimeSpan czasMergeSort = SortowaniePrzezScalenie(liczbyMergeSort);

        Console.WriteLine("\nLiczby posortowane metodą bąbelkową:");
        WyswietlLiczby(liczbyBubbleSort);

        Console.WriteLine("\nLiczby posortowane metodą wstawiania:");
        WyswietlLiczby(liczbyInsertionSort);

        Console.WriteLine("\nLiczby posortowane metodą przez scalanie:");
        WyswietlLiczby(liczbyMergeSort);

        Console.WriteLine($"\nCzas pracy Sortowanie Bąbelkowe: {czasBubbleSort.TotalMilliseconds} ms");
        Console.WriteLine($"Czas pracy Sortowanie Przez Wstawianie: {czasInsertionSort.TotalMilliseconds} ms");
        Console.WriteLine($"Czas pracy Sortowanie Przez Scalanie: {czasMergeSort.TotalMilliseconds} ms");

        TimeSpan najkrotszyCzas = czasBubbleSort;
        string najszybszaMetoda = "Sortowanie Bąbelkowe";

        if (czasInsertionSort < najkrotszyCzas)
        {
            najkrotszyCzas = czasInsertionSort;
            najszybszaMetoda = "Sortowanie Przez Wstawianie";
        }

        if (czasMergeSort < najkrotszyCzas)
        {
            najkrotszyCzas = czasMergeSort;
            najszybszaMetoda = "Sortowanie Przez Scalanie";
        }

        Console.WriteLine($"\n{najszybszaMetoda} jest najszybsze.");
    }

    static TimeSpan SortowanieBabelkowe(int[] lista)
    {
        DateTime startTime = DateTime.Now;
        int n = lista.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (lista[j] > lista[j + 1])
                {
                    int temp = lista[j];
                    lista[j] = lista[j + 1];
                    lista[j + 1] = temp;
                }
            }
        }
        DateTime stopTime = DateTime.Now;
        return stopTime - startTime;
    }

    static TimeSpan SortowanieFlaga(int[] lista)
    {
        DateTime startTime = DateTime.Now;
        int n = lista.Length;
        bool zamieniono;

        for (int i = 0; i < n - 1; i++)
        {
            zamieniono = false;

            for (int j = 0; j < n - 1 - i; j++)
            {
                if (lista[j] > lista[j + 1])
                {
                    
                    int temp = lista[j];
                    lista[j] = lista[j + 1];
                    lista[j + 1] = temp;

                    zamieniono = true;
                }
            }


            if (!zamieniono)
            {
                break;
            }
        }

        DateTime stopTime = DateTime.Now;
        return stopTime - startTime;
    }
    static TimeSpan SortowaniePrzezScalenie(int[] lista)
    {
        DateTime startTime = DateTime.Now;
        SortowaniePrzezScalenieRekurencyjnie(lista);
        DateTime stopTime = DateTime.Now;
        return stopTime - startTime;
    }

    static void SortowaniePrzezScalenieRekurencyjnie(int[] lista)
    {
        if (lista.Length <= 1)
        {
            return;
        }

        int srodek = lista.Length / 2;
        int[] lewa = new int[srodek];
        int[] prawa = new int[lista.Length - srodek];

        Array.Copy(lista, 0, lewa, 0, srodek);
        Array.Copy(lista, srodek, prawa, 0, lista.Length - srodek);

        SortowaniePrzezScalenieRekurencyjnie(lewa);
        SortowaniePrzezScalenieRekurencyjnie(prawa);

        Scalanie(lista, lewa, prawa);
    }

    static void Scalanie(int[] wynik, int[] lewa, int[] prawa)
    {
        int i = 0, j = 0, k = 0;

        while (i < lewa.Length && j < prawa.Length)
        {
            if (lewa[i] <= prawa[j])
            {
                wynik[k++] = lewa[i++];
            }
            else
            {
                wynik[k++] = prawa[j++];
            }
        }

        while (i < lewa.Length)
        {
            wynik[k++] = lewa[i++];
        }

        while (j < prawa.Length)
        {
            wynik[k++] = prawa[j++];
        }
    }

    static void WyswietlLiczby(int[] liczby)
    {
        foreach (int liczba in liczby)
        {
            Console.Write(liczba + " ");
        }
        Console.WriteLine();
    }
}
