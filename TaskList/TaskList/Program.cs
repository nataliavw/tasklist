using System;
using System.Collections.Generic;
using System.IO;


namespace TaskList
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo command;
            var list = new Dictionary<int, string>();
            int nextFree;
            string line;

            do
            {
                Console.WriteLine("\nMenu: \n\tPress Q to exit. \n\tPress A to add tasks. \n\tPress T to list tasks. \n\tPress R to remove a task.\n\tPress S to save the list. \n\tPress L to load the saved list.");
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

                    case 't':
                        Console.WriteLine("Listing tasks:");
                        foreach (var currentKVPair in list)
                        {
                            Console.WriteLine($"{currentKVPair.Key}:\t {currentKVPair.Value}");
                        }

#if DEBUG
                        Console.WriteLine("\n\nPress enter to continue");
                        Console.ReadKey();
#endif
                        break;

                    case 'r':
                        Console.WriteLine("Select a task number to remove.");
                        var taskNumberRaw = Console.ReadLine();
                        var taskNumber = int.Parse(taskNumberRaw);
                        list.Remove(taskNumber);
                        break;

                    case 's':
                        using (StreamWriter fileOut = new StreamWriter("ToDo.txt"))
                            foreach (var entry in list)
                                fileOut.WriteLine(entry.Value);
                        Console.WriteLine("File saved.");

                        break;

                    case 'l':
                        nextFree = 1;

                        list.Clear();

                        using (var fileIn = new StreamReader("ToDo.txt"))
                        {
                            while ((line = fileIn.ReadLine()) != null)
                            {
                                list.Add(nextFree, line);
                                nextFree++;
                            }
                        }

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