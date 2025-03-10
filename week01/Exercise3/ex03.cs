using System;

class Program
{
    static void Main(string[] args) // Método Main corretamente definido
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101); // Número aleatório entre 1 e 100

        int guess = -1;

        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            
            string input = Console.ReadLine();
            if (!int.TryParse(input, out guess)) // Validação da entrada
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue; // Pula para a próxima iteração do loop
            }

            if (magicNumber > guess)
            {
                Console.WriteLine("Higher");
            }
            else if (magicNumber < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
    }
}
