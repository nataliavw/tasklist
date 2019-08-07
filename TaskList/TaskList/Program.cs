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

            var count = 0;
            var found = false;

            do
            {
                Console.WriteLine("\nMenu: \n\tPress Q to exit. \n\tPress A to add tasks. \n\tPress L to list tasks.");
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
                        Console.WriteLine("Listing tasks");
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