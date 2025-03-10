using System;

using System;

class Program
{
    static void Main(string[] args) // Adicionado o método Main corretamente
    {
        Console.Write("What is your grade percentage? ");
        string answer = Console.ReadLine();

        int percent;
        if (!int.TryParse(answer, out percent)) // Validação para evitar erro caso o usuário digite algo inválido
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            return; // Sai do programa se a entrada for inválida
        }

        string letter = "";

        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your grade is: {letter}");
        
        if (percent >= 70)
        {
            Console.WriteLine("You passed!");
        }
        else
        {
            Console.WriteLine("Better luck next time!");
        }
    }
}
