// Uppgift 3 - Julia Gustafsson

using static System.Console; // Import to simplify code

namespace GuestbookApp
{
    public class Program
    {
        public static void Main()
        {
            var storage = new GuestbookStorage("guestbook.json");
            var manager = new GuestbookManager(storage);

            bool running = true;

            while (running)
            {
                Clear();
                WriteLine("**** GUESTBOOK MENU ****");
                WriteLine("\nMenu: ");
                WriteLine("1. Show all entries");
                WriteLine("2. Add new entry");
                WriteLine("3. Delete an entry");
                WriteLine("4. Exit");
                Write("\nChoose an option: ");
                string choice = ReadLine()!;

                switch (choice)
                {
                    // Option 1: Show available entries
                    case "1":
                        Clear();
                        WriteLine("**** GUESTBOOK ENTRIES ****\n");
                        manager.ShowEntries();
                        WriteLine("\nPress any key to return to menu");
                        ReadKey();
                        break;
                    // Option 2: Create new entry
                    case "2": manager.AddEntry(); break;
                    // Option 3: Delete an entry
                    case "3": manager.DeleteEntry(); break;
                    // Option 4: Exit
                    case "4": running = false; break;
                    default:
                        WriteLine("\nInvalid option, press any key to try again");
                        ReadKey();
                        break;
                }
            }
        }

    }
}