using System;
using System.Collections.Generic;
using System.Text;

namespace Lib
{
    internal class Theater : PublicBuilding
    {
        public string Genre { get; set; } // свойство - жанр театра
        public int CurrentEvent { get; set; } // свойство - текущее мероприятие
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
            return "Вместимость театра: " + Capacity + " зрителей";
        }

        public void StartEvent(int eventId)
        {
            CurrentEvent = eventId;
            Console.WriteLine("Начато мероприятие №" + eventId);
        }

        public void EndEvent()
        {
            Console.WriteLine("Мероприятие №" + CurrentEvent + " окончено");
            CurrentEvent = 0;
        }
    }
}
