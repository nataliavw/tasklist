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

            var count = 1;
            var found = false;

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

                        do
                        {
                            if (list.ContainsKey(count))
                            {
                                count++;
                            }
                            else
                            {
                                found = true;
                            }
                        } while (found == false);
                        
                        list.Add(count, Console.ReadLine());

                        break;

                    case 'l':
                        Console.WriteLine("Listing tasks:");
                        foreach (var currentKVPair in list)
                        {
                            Console.WriteLine($"{currentKVPair.Key}:\t {currentKVPair.Value}");
                        }
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