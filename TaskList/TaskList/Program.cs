using System;
using System.IO;

namespace TaskList
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo command;
            string path = "c:\\users\\natalia\\desktop\\todo.csv";

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

                        Console.WriteLine("Write a task for the list: ");
                        string list = Console.ReadLine();

                        File.AppendAllText(path, list);
                        Console.WriteLine($"Appended to file {path}");

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
