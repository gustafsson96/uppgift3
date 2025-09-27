// Uppgift 3 - Julia Gustafsson

using System.Diagnostics;
using System.Text.Json;
using static System.Console; // Import to simplify code

namespace GuestbookApp
{
    public class Program
    {
        public static void Main()
        {
            // Create a list to store guestbook entries
            string filePath = "guestbook.json";
            List<GuestbookEntry> guestbook;

            // Check if list exists in json storage
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                guestbook = JsonSerializer.Deserialize<List<GuestbookEntry>>(json) ?? new List<GuestbookEntry>();
            }
            else
            {
                guestbook = new List<GuestbookEntry>();
            }

            bool running = true;

            // Guestbook menu prompting for user input
            while (running)
            {
                Clear();
                WriteLine("**** GUESTBOOK MENU ****");

                // Menu options
                WriteLine("\nMenu: ");
                WriteLine("1. Show all entries");
                WriteLine("2. Add new entry");
                WriteLine("3. Delete an entry");
                WriteLine("4. Exit");
                WriteLine("Choose an option: ");

                string choice = ReadLine()!;

                switch (choice)
                {
                    // Option 1: Show available entries
                    case "1":
                        Clear();
                        WriteLine("**** GUESTBOOK ENTRIES ****\n");
                        ShowEntries(guestbook);
                        WriteLine("\nPress any button to return to menu");
                        ReadKey();
                        break;

                    // Option 2: Create new entry
                    case "2":
                        Clear();
                        WriteLine("**** CREATE NEW ENTRY ****\n");
                        AddEntry(guestbook);
                        WriteLine("\nSucess! Press any button to return to menu");
                        ReadKey();
                        break;
                    // Option 3: Delete an entry
                    case "3":
                        Clear();
                        WriteLine("**** DELETE AN ENTRY ****\n");
                        DeleteEntry(guestbook);
                        break;
                    // Option 4: Exit
                    case "4":
                        running = false;
                        break;
                    default:
                        WriteLine("Invalid option. Press any key to continue.");
                        ReadKey();
                        break;
                }

            }
        }

        // Method to add a new guestbook entry
        static void AddEntry(List<GuestbookEntry> guestbook)
        {
            string author = "";

            // Validate use input
            while (string.IsNullOrWhiteSpace(author))
            {
                Write("Enter your name: ");
                author = ReadLine()!;
                if (string.IsNullOrWhiteSpace(author))
                {
                    WriteLine("\nName cannot be empty, please try again\n");
                }
            }

            string entryText = "";
            while (string.IsNullOrWhiteSpace(entryText))
            {
                WriteLine("\nEnter your text: ");
                entryText = ReadLine()!;
                if (string.IsNullOrWhiteSpace(entryText))
                {
                    WriteLine("\nText field cannot be empty, please try again\n");
                }
            }

            // Create new guestbook entry using GuesbookEntry class
            guestbook.Add(new GuestbookEntry(author, entryText));

            // Store using json
            string json = JsonSerializer.Serialize(guestbook, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("guestbook.json", json);
        }

        // Method to delete a guestbook entry
        static void DeleteEntry(List<GuestbookEntry> guestbook)
        {
            // Check if there are any entries to display
            if (guestbook.Count == 0)
            {
                WriteLine("The guestbook is empty");
                return;
            }

            bool deleting = true;
            while (deleting && guestbook.Count > 0)
            {
                ShowEntries(guestbook);

                int index;
                while (true)
                {
                    // Ask for user input (number of entry to delete)
                    Write("\nEnter the number of the entry you want to delete: ");
                    string input = ReadLine()!;
                    if (int.TryParse(input, out index) && index >= 0 && index < guestbook.Count) // Validate user input
                    {
                        break; // Valid index
                    }
                    WriteLine("\nInvalid number, please try again");
                }

                guestbook.RemoveAt(index); //Remove the entry

                // Save updated guestbook
                string json = JsonSerializer.Serialize(guestbook, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText("guestbook.json", json);

                Clear();
                WriteLine("\nEntry deleted succesfully");

                // Show updated list
                WriteLine("\n**** UPDATED GUESTBOOK ****\n");
                ShowEntries(guestbook);

                // Ask user if they want to delete another
                WriteLine("\nPress 1 to delete another entry, or any other key to return to menu");
                string choice = ReadLine()!;
                deleting = choice == "1";
                Clear();
                WriteLine("**** DELETE AN ENTRY ****\n");
            }
        }

        // Method to display saved entries
        static void ShowEntries(List<GuestbookEntry> guestbook)
        {
            // Check if there are any entries to display
            if (guestbook.Count == 0)
            {
                WriteLine("The guesbook is empty");
            }
            else
            {
                // Display the entries
                for (int i = 0; i < guestbook.Count; i++)
                {
                    WriteLine($"[{i}] {guestbook[i].Author}: {guestbook[i].EntryText}");
                }
            }
        }

    }
}