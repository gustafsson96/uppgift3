/*
Skapa en gästbok som en konsollapplikation med möjlighet att lägga till en post, ta bort en valfri post samt visa alla poster. 
*/
using System;
using static System.Console; // Import to simplify code

public class Program
{
    public static void Main(string[] args)
    {
        WriteLine($"Welcome to my guestbook :-). There are {args.Length} arguments.");
        foreach (string arg in args)
        {
            WriteLine(arg);
        }

        // WriteLine("Pick a username and press ENTER: ");
        // string username = ReadLine();

        // WriteLine($"Hello {username}!");
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
