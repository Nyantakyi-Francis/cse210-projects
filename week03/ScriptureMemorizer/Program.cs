using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Load a library of scriptures
        List<Scripture> scriptureLibrary = new List<Scripture>
        {
            new Scripture(new Reference("John", 3, 16),
                "For God so loved the world that he gave his only begotten Son, " +
                "that whosoever believeth in him should not perish, but have everlasting life."),
            
            new Scripture(new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart; and lean not unto thine own understanding. " +
                "In all thy ways acknowledge him, and he shall direct thy paths."),
            
            new Scripture(new Reference("2 Nephi", 2, 25),
                "Adam fell that men might be; and men are, that they might have joy."),
            
            new Scripture(new Reference("Mosiah", 2, 17),
                "When ye are in the service of your fellow beings ye are only in the service of your God."),
            
            new Scripture(new Reference("Philippians", 4, 13),
                "I can do all things through Christ which strengtheneth me.")
        };

        // Select a random scripture
        Random random = new Random();
        Scripture scripture = scriptureLibrary[random.Next(scriptureLibrary.Count)];

        // Main loop
        while (!scripture.AllWordsHidden())
        {
            scripture.Display();
            Console.WriteLine($"\nProgress: {scripture.GetPercentHidden()}% hidden");

            Console.WriteLine("Press Enter to hide more words or type 'quit' to exit.");
            string input = Console.ReadLine().Trim().ToLower();

            if (input == "quit")
                break;

            scripture.HideRandomWords(3); // Adjust number for difficulty
        }

        // Final display
        scripture.Display();
        Console.WriteLine($"\nProgress: {scripture.GetPercentHidden()}% hidden");
        Console.WriteLine("\nAll words are now hidden. Program ended.");
    }
}

// Reference class
class Reference
{
    public string Book { get; }
    public int Chapter { get; }
    public int VerseStart { get; }
    public int VerseEnd { get; }

    public Reference(string book, int chapter, int verse)
    {
        Book = book;
        Chapter = chapter;
        VerseStart = verse;
        VerseEnd = verse;
    }

    public Reference(string book, int chapter, int verseStart, int verseEnd)
    {
        Book = book;
        Chapter = chapter;
        VerseStart = verseStart;
        VerseEnd = verseEnd;
    }

    public override string ToString()
    {
        return VerseStart == VerseEnd
            ? $"{Book} {Chapter}:{VerseStart}"
            : $"{Book} {Chapter}:{VerseStart}-{VerseEnd}";
    }
}

// Word class
class Word
{
    public string Text { get; }
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public void Hide()
    {
        IsHidden = true;
    }

    public string GetDisplayText()
    {
        return IsHidden ? new string('_', Text.Length) : Text;
    }
}

// Scripture class
class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ')
                     .Select(word => new Word(word))
                     .ToList();
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine(_reference);
        Console.WriteLine(string.Join(" ", _words.Select(w => w.GetDisplayText())));
    }

    public void HideRandomWords(int count)
    {
        var visibleWords = _words.Where(w => !w.IsHidden).ToList();
        Random rand = new Random();

        for (int i = 0; i < count && visibleWords.Count > 0; i++)
        {
            int index = rand.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public bool AllWordsHidden()
    {
        return _words.All(w => w.IsHidden);
    }

    public int GetPercentHidden()
    {
        int total = _words.Count;
        int hidden = _words.Count(w => w.IsHidden);
        return (int)((double)hidden / total * 100);
    }
}


// Enhancements to Exceed Requirements:
//
// 1. Scripture Library with Random Selection:
//    Instead of using a single hardcoded scripture, this program includes a library of multiple scriptures.
//    When the program starts, it randomly selects one scripture to display, making the memorization practice more varied.
//
// 2. Progress Tracker:
//    After each step, the program calculates and displays the percentage of words that are hidden.
//    This gives the user visual feedback and motivation as they memorize the passage.
//
// These features go beyond the core requirements and demonstrate creativity in making the program more interactive
// and useful for users trying to memorize different scriptures.