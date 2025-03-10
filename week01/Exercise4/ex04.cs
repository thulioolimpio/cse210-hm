using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args) // Método Main corretamente definido
    {
        List<int> numbers = new List<int>();
        
        int userNumber;
        while (true)
        {
            Console.Write("Enter a number (0 to quit): ");
            string userResponse = Console.ReadLine();
            
            if (!int.TryParse(userResponse, out userNumber)) // Validação de entrada
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                continue;
            }
            
            if (userNumber == 0)
                break;

            numbers.Add(userNumber);
        }

        if (numbers.Count == 0) // Evita erro se nenhum número for inserido
        {
            Console.WriteLine("No numbers entered.");
            return;
        }

        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        Console.WriteLine($"The sum is: {sum}");

        float average = (float)sum / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        int max = numbers[0]; // Inicializando com o primeiro elemento

        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }

        Console.WriteLine($"The max is: {max}");
    }
}
