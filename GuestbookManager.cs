using System.Runtime.CompilerServices;
using static System.Console;

namespace GuestbookApp
{
    public class GuestbookManager
    {
        private readonly GuestbookStorage _storage;
        private List<GuestbookEntry> _entries;

        public GuestbookManager(GuestbookStorage storage)
        {
            _storage = storage;
            _entries = storage.Load();
        }

        public void ShowEntries()
        {
            if (_entries.Count == 0)
            {
                WriteLine("The guestbook is empty");
            }
            else
            {
                for (int i = 0; i < _entries.Count; i++)
                {
                    WriteLine($"[{i}] {_entries[i].Author}: {_entries[i].EntryText}");
                }
            }
        }

        public void AddEntry()
        {
            Clear();
            WriteLine("**** CREATE NEW ENTRY ****\n");

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

            string text = "";
            while (string.IsNullOrWhiteSpace(text))
            {
                WriteLine("\nEnter your text: ");
                text = ReadLine()!;
                if (string.IsNullOrWhiteSpace(text))
                {
                    WriteLine("\nText field cannot be empty, please try again\n");
                }
            }

            _entries.Add(new GuestbookEntry(author, text));
            _storage.Save(_entries);

            WriteLine("\nSucess! Press any key to return to menu");
            ReadKey();
        }

        public void DeleteEntry()
        {
            bool deleting = true;

            while (deleting)
            {
                Clear();
                WriteLine("**** DELETE AN ENTRY ****\n");

                // Check if guestbook is empty
                if (_entries.Count == 0)
                {
                    WriteLine("The guestbook is empty");
                    ReadKey(); // pause so user can see the message
                    return;    // exit the method
                }

                // Show current entries
                ShowEntries();

                // Ask which entry to delete
                int index;
                while (true)
                {
                    Write("\nEnter the number of the entry you want to delete: ");
                    string input = ReadLine()!;
                    if (int.TryParse(input, out index) && index >= 0 && index < _entries.Count)
                        break;
                    WriteLine("\nInvalid number, please try again");
                }

                // Delete the entry
                _entries.RemoveAt(index);
                _storage.Save(_entries);

                // Show success message
                Clear();
                WriteLine("\nEntry deleted successfully\n");

                // Show updated entries
                ShowEntries();

                // Ask if the user wants to delete another entry
                WriteLine("\nPress 1 to delete another entry, or any other key to return to menu");
                string choice = ReadLine()!;
                deleting = choice == "1";
            }
        }
    }
}