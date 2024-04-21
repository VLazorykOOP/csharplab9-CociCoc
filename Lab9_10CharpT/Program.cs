using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "t.txt";

        try
        {
            // Читаємо вміст файлу
            string[] lines = File.ReadAllLines(filePath);

            // Проходження по кожному рядку
            foreach (string line in lines)
            {
                // Виводимо літери кожного рядка в зворотному порядку
                for (int i = line.Length - 1; i >= 0; i--)
                {
                    Console.Write(line[i]);
                }
                Console.WriteLine(); // Додаємо перехід на новий рядок після кожного рядка
            }
        }
        catch (Exception ex)
        {
            // Обробка помилок
            Console.WriteLine("Помилка: " + ex.Message);
        }
    }
}
