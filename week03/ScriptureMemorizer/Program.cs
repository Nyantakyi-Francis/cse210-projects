using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Create a reference and scripture
        Reference reference = new Reference("John", 3, 16);
        string text = "For God so loved the world that he gave his only begotten Son, " +
                      "that whosoever believeth in him should not perish, but have everlasting life.";
        Scripture scripture = new Scripture(reference, text);

        // Main loop
        while (!scripture.AllWordsHidden())
        {
            scripture.Display();
            Console.WriteLine($"\nProgress: {scripture.GetPercentHidden()}% hidden");

            Console.WriteLine("Press Enter to hide more words or type 'quit' to exit.");
            string input = Console.ReadLine().Trim().ToLower();

            if (input == "quit")
                break;

            scripture.HideRandomWords(3); // You can change this number for difficulty
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
