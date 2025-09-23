/*
Skapa en gästbok som en konsollapplikation med möjlighet att lägga till en post, ta bort en valfri post samt visa alla poster. 
*/
using System;
using static System.Console; // Import to simplify code

namespace GuestbookApp
{
    public class Program
    {
        public static void Main()
        {
            // Create a list to store guestbook entries
            List<GuestbookEntry> guestbook = new List<GuestbookEntry>();
            bool running = true;

            // Add some entries TEST
            guestbook.Add(new GuestbookEntry("Julia", "Hey here's my first entry!"));
            guestbook.Add(new GuestbookEntry("Zed", "Hi i'm a cat"));

            while (running)
            {
                Clear();
                WriteLine("**** Guestbook ****");

                if (guestbook.Count == 0)
                {
                    WriteLine("The guesbook is empty :-()");
                }
                else
                {
                    // Display the entries
                    for (int i = 0; i < guestbook.Count; i++)
                    {
                        WriteLine($"[{i}] {guestbook[i].Author}: {guestbook[i].EntryText}");
                    }
                }

                // Menu
                WriteLine("\nMenu: ");
                WriteLine("1. Add new entry");
                WriteLine("2. Exit");
                WriteLine("Choose an option: ");

                string choice = ReadLine()!;

                switch (choice)
                {
                    case "1":
                        // Replace with AddEntry
                        WriteLine("Add entry selected (not implemented yet)");
                        WriteLine("Press any key to continue");
                        ReadKey();
                        break;
                    case "2":
                        running = false;
                        break;
                    default:
                        WriteLine("Invalid option. Press any key to continue.");
                        ReadKey();
                        break;
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
    Felhantering i from av en kontroll sp att inmatningsfält inte är tomma. 
    */

    /*
     Efter varje genomfört menyval ska skärmen skrivas om. Detta sker enklast genom att man "rensar" konsolen och 
    sedan ritar/skriver om den. Se Console.Clear för mer information om hur detta kan ske. 
    */


}