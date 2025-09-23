// Class for guestbook entries
public class GuestbookEntry
{
    public string Author { get; set; } // The author of the entry
    public string EntryText { get; set; } // The text of the entry

    // Constructor for the GuestbookEntry class
    // Runs automatically when a new GuestbookEntry object is created
    public GuestbookEntry(string author, string entryText)
    {
        Author = author;
        EntryText = entryText;
    }


}