using System;
using System.Collections.Generic;
using System.Text;

namespace Lib
{
    internal class Museum : PublicBuilding
    {
        public string Theme { get; set; } // свойство - тематика музея
        public int CurrentExhibit { get; set; } // свойство - текущая экспозиция
        List<string> events = new List<string>();

        public void AddEvent(string eventName)
        {
            events.Add(eventName);
        }

        public override string ShowEvents()
        {
            string res = "Список мероприятий:\n ";
            foreach (string concert in events)
            {
                res += concert.ToString() + "\n";
            }
            return res;
        }

        public override string ShowCapacity()
        {
            return "Вместимость музея: " + Capacity + " посетителей";
        }

        public void StartExhibit(int exhibitId)
        {
            CurrentExhibit = exhibitId;
            Console.WriteLine("Начата экспозиция №" + exhibitId);
        }

        public void EndExhibit()
        {
            Console.WriteLine("Экспозиция №" + CurrentExhibit + " завершена");
            CurrentExhibit = 0;
        }
    }
}
