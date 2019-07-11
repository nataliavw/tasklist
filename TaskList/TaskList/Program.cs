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
                Console.WriteLine("\nMenu: \n\tPress Q to exit. \n\tPress A to list tasks. \n\tPress L to exit.");
                command = Console.ReadKey(true);

                switch (char.ToLower(command.KeyChar))
                {
                    case 'q':
                        Console.WriteLine("Quitting");
                        break;
                    case 'a':
                        Console.WriteLine("Adding task");
                        break;
                    case 'l':
                        Console.WriteLine("Listing task");
                        break;
                    default:
                        Console.WriteLine("Command not recognised");
                        break;
                }

            } while (command.KeyChar != 'q');

            #if DEBUG
            Console.WriteLine("\n\nPress enter to close");
            Console.ReadKey();
            #endif 
        }
    }
}
