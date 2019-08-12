using System;
using System.Collections.Generic;


namespace TaskList
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo command;
            var list = new Dictionary<int, string>();
            int nextFree;

            do
            {
                Console.WriteLine("\nMenu: \n\tPress Q to exit. \n\tPress A to add tasks. \n\tPress L to list tasks. \n\tPress R to remove a task.");
                command = Console.ReadKey(true);

                switch (char.ToLower(command.KeyChar))
                {
                    case 'q':
                        Console.WriteLine("Quitting");
                        break;

                    case 'a':
                        Console.WriteLine("State a task to add:");
                        nextFree = 0;
                        do
                        {
                            nextFree++;
                        } while (list.ContainsKey(nextFree));
                        
                        list.Add(nextFree, Console.ReadLine());

                        Console.WriteLine("Task added.");

                        break;

                    case 'l':
                        Console.WriteLine("Listing tasks:");
                        foreach (var currentKVPair in list)
                        {
                            Console.WriteLine($"{currentKVPair.Key}:\t {currentKVPair.Value}");
                        }

                        Console.ReadKey(true);
                        break;

                    case 'r':
                        Console.WriteLine("Select a task number to remove.");
                        var taskNumberRaw = Console.ReadLine();
                        var taskNumber = int.Parse(taskNumberRaw);
                        list.Remove(taskNumber);
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