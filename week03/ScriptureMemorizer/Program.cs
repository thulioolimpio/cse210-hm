using System;

class Program
{
    static void Main(string[] args)
    {
        var reference = new Reference("Proverbs", 3, 5, 6);
        var text = "Trust in the Lord with all thine heart and lean not unto thine own understanding";
        var scripture = new Scripture(reference, text);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to finish.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            if (scripture.AllWordsHidden())
                break;

            scripture.HideRandomWords();
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nAll words are hidden. Program ended.");
    }
}
