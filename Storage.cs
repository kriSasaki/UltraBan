using System.Text.Json;
using UltraBan.Models;

namespace UltraBan.Data
{
    public class AppRepository
    {
        private readonly string _filePath = "data.json";

        public List<TargetApp> Load()
        {
            if (!File.Exists(_filePath)) return new List<TargetApp>();
            string json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<TargetApp>>(json) ?? new List<TargetApp>();
        }

        public void Save(List<TargetApp> apps)
        {
            string json = JsonSerializer.Serialize(apps, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
    }
}
