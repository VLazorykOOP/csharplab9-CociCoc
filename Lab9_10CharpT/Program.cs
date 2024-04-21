using System;
using System.Collections;
using System.Collections.Generic;

class Song
{
    public string Назва { get; set; }
    public string Виконавець { get; set; }
    public double Тривалість { get; set; }

    public Song(string назва, string виконавець, double тривалість)
    {
        Назва = назва;
        Виконавець = виконавець;
        Тривалість = тривалість;
    }

    public override string ToString()
    {
        return $"{Назва} - {Виконавець} ({Тривалість} хв)";
    }
}

class MusicDisk
{
    private Hashtable пісні = new Hashtable();

    public void AddSong(string назва, Song пісня)
    {
        пісні[назва] = пісня;
    }

    public void ВидалитиПісню(string назва)
    {
        пісні.Remove(назва);
    }

    public void ПереглянутиВміст()
    {
        foreach (DictionaryEntry entry in пісні)
        {
            Console.WriteLine(entry.Value);
        }
    }

    public void ПереглянутиПісню(string назва)
    {
        if (пісні.ContainsKey(назва))
        {
            Console.WriteLine(пісні[назва]);
        }
        else
        {
            Console.WriteLine("Пісня не знайдена.");
        }
    }

    public void ПошукВиконавця(string виконавець)
    {
        bool знайдено = false;
        foreach (DictionaryEntry entry in пісні)
        {
            Song пісня = (Song)entry.Value;
            if (пісня.Виконавець == виконавець)
            {
                Console.WriteLine(пісня);
                знайдено = true;
            }
        }
        if (!знайдено)
        {
            Console.WriteLine("Пісні виконавця не знайдено.");
        }
    }
}

class Program
{
    static void Main()
    {
        // Виконання першого завдання
        ReverseLinesInFile();

        // Виконання другого завдання
        GroupNumbersFromFile();

        // Виконання третього завдання
        ArrayListManipulation();

        // Виконання четвертого завдання
        MusicCatalog();
    }

    static void ReverseLinesInFile()
    {
        string filePath = "t.txt";

        try
        {
            ArrayList linesList = new ArrayList(System.IO.File.ReadAllLines(filePath));

            foreach (string line in linesList)
            {
                char[] charArray = line.ToCharArray();
                Array.Reverse(charArray);
                Console.WriteLine(new string(charArray));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Помилка: " + ex.Message);
        }
    }

    static void GroupNumbersFromFile()
    {
        string filePath = "numbers.txt";

        try
        {
            ArrayList numbersList = new ArrayList();
            foreach (string line in System.IO.File.ReadLines(filePath))
            {
                numbersList.Add(int.Parse(line));
            }

            int a = 5;
            int b = 10;

            ArrayList inRangeList = new ArrayList();
            ArrayList lessThanAList = new ArrayList();
            ArrayList greaterThanBList = new ArrayList();

            foreach (int num in numbersList)
            {
                if (num >= a && num <= b)
                {
                    inRangeList.Add(num);
                }
                else if (num < a)
                {
                    lessThanAList.Add(num);
                }
                else
                {
                    greaterThanBList.Add(num);
                }
            }

            Console.WriteLine("Numbers in the range [{0},{1}]:", a, b);
            foreach (int num in inRangeList)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("Numbers less than {0}:", a);
            foreach (int num in lessThanAList)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("Numbers greater than {0}:", b);
            foreach (int num in greaterThanBList)
            {
                Console.WriteLine(num);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void ArrayListManipulation()
    {
        ArrayList originalList = new ArrayList() { 1, 2, 3, 4, 5 };
        ArrayList clonedList = (ArrayList)originalList.Clone();

        // Додати елемент у початок списку
        originalList.Insert(0, 0);

        Console.WriteLine("Original list:");
        foreach (var item in originalList)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();

        Console.WriteLine("Clone list:");
        foreach (var item in clonedList)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    static void MusicCatalog()
    {
        Hashtable catalog = new Hashtable();

        // Створення музичних дисків і додавання їх до каталогу
        MusicDisk disk1 = new MusicDisk();
        disk1.AddSong("Song 1", new Song("Song 1", "Singer 1", 3.5));
        disk1.AddSong("Song 2", new Song("Song 2", "Singer 2", 4.0));
        catalog["Диск 1"] = disk1;

        MusicDisk диск2 = new MusicDisk();
        диск2.AddSong("Song 3", new Song("Song 3", "Singer 1", 3.8));
        диск2.AddSong("Song 4", new Song("Song 4", "Singer 3", 4.2));
        catalog["Диск 2"] = диск2;

        // Перегляд вмісту каталогу
        Console.WriteLine("Music catalog:");
        foreach (DictionaryEntry entry in catalog)
        {
            Console.WriteLine($"Disk: {entry.Key}");
            MusicDisk disk = (MusicDisk)entry.Value;
            disk.ПереглянутиВміст();
            Console.WriteLine();
        }

        // Пошук пісень виконавця
        string singer = "Singer 1";
        Console.WriteLine($"search for a song of {singer}:");
        foreach (DictionaryEntry entry in catalog)
        {
            MusicDisk disk = (MusicDisk)entry.Value;
            disk.ПошукВиконавця(singer);
        }
    }
}
