/*
Skapa en gästbok som en konsollapplikation med möjlighet att lägga till en post, ta bort en valfri post samt visa alla poster. 
*/
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

            while (running)
            {
                Clear();
                WriteLine("**** GUESTBOOK MENU ****");

                // Menu
                WriteLine("\nMenu: ");
                WriteLine("1. Show all entries");
                WriteLine("2. Add new entry");
                WriteLine("3. Delete an entry");
                WriteLine("4. Exit");
                WriteLine("Choose an option: ");

                string choice = ReadLine()!;

                switch (choice)
                {
                    // Show available entries
                    case "1":
                        Clear();
                        WriteLine("**** GUESTBOOK ENTRIES ****\n");
                        ShowEntries(guestbook);
                        WriteLine("\nPress any button to go back to the menu.");
                        ReadKey();
                        break;

                    // Create new entry
                    case "2":
                        Clear();
                        WriteLine("**** CREATE NEW ENTRY ****\n");
                        AddEntry(guestbook);
                        WriteLine("\nSucess! Press any button to go back to the menu.");
                        ReadKey();
                        break;
                    // Delete an entry
                    case "3":
                        Clear();
                        WriteLine("**** DELETE AN ENTRY ****\n");
                        DeleteEntry(guestbook);
                        break;
                    // Exit
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

        static void AddEntry(List<GuestbookEntry> guestbook)
        {
            string author = "";
            while (string.IsNullOrWhiteSpace(author))
            {
                Write("Enter your name: ");
                author = ReadLine()!;
                if (string.IsNullOrWhiteSpace(author))
                {
                    WriteLine("\nName cannot be empty. Please try again.\n");
                }
            }

            string entryText = "";
            while (string.IsNullOrWhiteSpace(entryText))
            {
                WriteLine("\nEnter your text: ");
                entryText = ReadLine()!;
                if (string.IsNullOrWhiteSpace(entryText))
                {
                    WriteLine("\nText field cannot be empty. Please try again.\n");
                }
            }

            guestbook.Add(new GuestbookEntry(author, entryText));
            string json = JsonSerializer.Serialize(guestbook, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("guestbook.json", json);
        }

        static void DeleteEntry(List<GuestbookEntry> guestbook)
        {
            if (guestbook.Count == 0)
            {
                WriteLine("The guestbook is empty.");
                return;
            }

            bool deleting = true;
            while (deleting && guestbook.Count > 0)
            {
                ShowEntries(guestbook);

                int index;
                while (true)
                {
                    Write("\nEnter the number of the entry you want to delete: ");
                    string input = ReadLine()!;
                    if (int.TryParse(input, out index) && index >= 0 && index < guestbook.Count)
                    {
                        break; // Valid index
                    }
                    WriteLine("Invalid number. Please try again.");
                }

                guestbook.RemoveAt(index); //Remove the entry

                // Save update guesbook
                string json = JsonSerializer.Serialize(guestbook, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText("guestbook.json", json);

                Clear();
                WriteLine("\nEntry deleted succesfully.");


                // Show updated list immediately
                WriteLine("\n**** UPDATED GUESTBOOK ****\n");
                ShowEntries(guestbook);

                // Ask user if they want to delete another
                WriteLine("\nPress 1 to delete another entry, or any other key to return to the menu.");
                string choice = ReadLine()!;
                deleting = choice == "1";
                Clear();
                WriteLine("**** DELETE AN ENTRY ****\n");
            }
        }

        static void ShowEntries(List<GuestbookEntry> guestbook)
        {
            if (guestbook.Count == 0)
            {
                WriteLine("The guesbook is empty :-(");
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
/* 
Ett enklare menysystem hanterar de val som ska kunna genomföras: 
1. Lägg till inlägg ska ge dig valet att mata in ägare samt det nya inlägget. Dessa fält får ej vara tomma.
2. Ta bort inlägg ska fråga efter valt index (till vänster i listan av inlägg på bild ovan) att ta bort innan radering
av inlägget. 
*/

/*
 Inläggen ska innehålla två fält, "ägare till inlägget" samt texten för inlägget. 
*/

/*
Gästbokens inlägg ska serialiseras/deserialiseras samt sparas på fil antingen binärt eller som json, 
så att tidigare inmatad data finns lagrad
*/

/*
Felhantering i from av en kontroll så att inmatningsfält inte är tomma. 
*/

/*
 Efter varje genomfört menyval ska skärmen skrivas om. Detta sker enklast genom att man "rensar" konsolen och 
sedan ritar/skriver om den. Se Console.Clear för mer information om hur detta kan ske. 
*/


