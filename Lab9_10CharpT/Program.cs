using System;
using System.Collections;
using System.Collections.Generic;

class Song
{
    public string Title { get; set; }
    public string Artist { get; set; }
    public double Duration { get; set; }

    public Song(string title, string artist, double duration)
    {
        Title = title;
        Artist = artist;
        Duration = duration;
    }

    public override string ToString()
    {
        return $"{Title} - {Artist} ({Duration} min)";
    }
}

class MusicDisk
{
    private Hashtable songs = new Hashtable();

    public void AddSong(string title, Song song)
    {
        songs[title] = song;
    }

    public void RemoveSong(string title)
    {
        songs.Remove(title);
    }

    public void ViewContent()
    {
        foreach (DictionaryEntry entry in songs)
        {
            Console.WriteLine(entry.Value);
        }
    }

    public void ViewSong(string title)
    {
        if (songs.ContainsKey(title))
        {
            Console.WriteLine(songs[title]);
        }
        else
        {
            Console.WriteLine("Song not found.");
        }
    }

    public void SearchArtist(string artist)
    {
        bool found = false;
        foreach (DictionaryEntry entry in songs)
        {
            Song song = (Song)entry.Value;
            if (song.Artist == artist)
            {
                Console.WriteLine(song);
                found = true;
            }
        }
        if (!found)
        {
            Console.WriteLine("Songs of the artist not found.");
        }
    }
}

class Program
{
    static void Main()
    {
        // Execution of the first task
        ReverseLinesInFile();

        // Execution of the second task
        GroupNumbersFromFile();

        // Execution of the third task
        ArrayListManipulation();

        // Execution of the fourth task
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
            Console.WriteLine("Error: " + ex.Message);
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

        // Add an element to the beginning of the list
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

        // Creating music disks and adding them to the catalog
        MusicDisk disk1 = new MusicDisk();
        disk1.AddSong("Song 1", new Song("Song 1", "Singer 1", 3.5));
        disk1.AddSong("Song 2", new Song("Song 2", "Singer 2", 4.0));
        catalog["Disk 1"] = disk1;

        MusicDisk disk2 = new MusicDisk();
        disk2.AddSong("Song 3", new Song("Song 3", "Singer 1", 3.8));
        disk2.AddSong("Song 4", new Song("Song 4", "Singer 3", 4.2));
        catalog["Disk 2"] = disk2;

        // Viewing the content of the catalog
        Console.WriteLine("Music catalog:");
        foreach (DictionaryEntry entry in catalog)
        {
            Console.WriteLine($"Disk: {entry.Key}");
            MusicDisk disk = (MusicDisk)entry.Value;
            disk.ViewContent();
            Console.WriteLine();
        }

        // Searching for songs of an artist
        string artist = "Singer 1";
        Console.WriteLine($"Search for songs of {artist}:");
        foreach (DictionaryEntry entry in catalog)
        {
            MusicDisk disk = (MusicDisk)entry.Value;
            disk.SearchArtist(artist);
        }
    }
}
