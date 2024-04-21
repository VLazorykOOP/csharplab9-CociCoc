using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Виконання першого завдання
        ReverseLinesInFile();

        // Виконання другого завдання
        GroupNumbersFromFile();
    }

    static void ReverseLinesInFile()
    {
        string filePath = "t.txt";

        try
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                for (int i = line.Length - 1; i >= 0; i--)
                {
                    Console.Write(line[i]);
                }
                Console.WriteLine();
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

        List<int> numbers = File.ReadAllLines(filePath)
                                 .Select(int.Parse)
                                 .ToList();

        int a = 5;
        int b = 10;

        Stack<int> inRangeStack = new Stack<int>();
        Stack<int> lessThanAStack = new Stack<int>();
        Stack<int> greaterThanBStack = new Stack<int>();

        foreach (int num in numbers)
        {
            if (num >= a && num <= b)
            {
                inRangeStack.Push(num);
            }
            else if (num < a)
            {
                lessThanAStack.Push(num);
            }
            else
            {
                greaterThanBStack.Push(num);
            }
        }

        Console.WriteLine("Numbers in the range [{0},{1}]:", a, b);
        while (inRangeStack.Count > 0)
        {
            Console.WriteLine(inRangeStack.Pop());
        }

        Console.WriteLine("Numbers less than {0}:", a);
        while (lessThanAStack.Count > 0)
        {
            Console.WriteLine(lessThanAStack.Pop());
        }

        Console.WriteLine("Numbers greater than {0}:", b);
        while (greaterThanBStack.Count > 0)
        {
            Console.WriteLine(greaterThanBStack.Pop());
        }
    }
}
