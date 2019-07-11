using System;

namespace TaskList
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo command;
            do
            {
                Console.WriteLine("\nMenu: \n\tPress Q to exit.");
                command = Console.ReadKey();

                if (command.KeyChar == 'q')
                {
                    Console.Write("\n\tPressed Q");
                }

            } while (command.KeyChar != 'q');
        }
    }
}
