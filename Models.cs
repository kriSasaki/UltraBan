using System;
using System.Collections.Generic;

namespace UltraBan.Models
{
    // Класс действия (напр. "Ban", "Warn")
    public class ActionEntry
    {
        public string ActionType { get; set; }
        public string Reason { get; set; }
        public DateTime Timestamp { get; set; }
    }

    // Основной класс приложения
    public class TargetApp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public List<ActionEntry> Actions { get; set; } = new List<ActionEntry>();

        public override string ToString() => $"[{Id}] {Name} ({Category}) - Действий: {Actions.Count}";
    }
}
