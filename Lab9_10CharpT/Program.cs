using System;
using System.IO;
using System.Collections;
using System.Linq;

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
    }

    static void ReverseLinesInFile()
    {
        string filePath = "t.txt";

        try
        {
            ArrayList linesList = new ArrayList(File.ReadAllLines(filePath));

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
            foreach (string line in File.ReadLines(filePath))
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
            Console.WriteLine("Помилка: " + ex.Message);
        }
    }

    static void ArrayListManipulation()
    {
        ArrayList originalList = new ArrayList() { 1, 2, 3, 4, 5 };
        ArrayList clonedList = (ArrayList)originalList.Clone();

        // Додати елемент у початок списку
        originalList.Insert(0, 0);

        Console.WriteLine("original list:");
        foreach (var item in originalList)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();

        Console.WriteLine("clone list:");
        foreach (var item in clonedList)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}
