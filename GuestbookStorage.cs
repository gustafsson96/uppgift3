/* Class to persist data */

using System.Text.Json;

namespace GuestbookApp
{
    public class GuestbookStorage
    {
        private readonly string _filePath;

        public GuestbookStorage(string filePath)
        {
            _filePath = filePath;
        }

        public List<GuestbookEntry> Load()
        {
            if (File.Exists(_filePath))
            {
                string json = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<List<GuestbookEntry>>(json) ?? new List<GuestbookEntry>();
            }
            return new List<GuestbookEntry>();
        }

        public void Save(List<GuestbookEntry> entries)
        {
            string json = JsonSerializer.Serialize(entries, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
    }
}