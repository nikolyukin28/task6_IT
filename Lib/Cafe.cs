using System;
using System.Collections.Generic;
using System.Text;

namespace Lib
{
    internal class Cafe : PublicBuilding
    {
        public string Cuisine { get; set; } // свойство - тип кухни в кафе
        public bool OutdoorSeating { get; set; } // свойство - наличие открытой площадки
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
            return "Вместимость кафе: " + Capacity + " посетителей";
        }

        public void StartEvent(int eventId)
        {
            Console.WriteLine("Начато событие №" + eventId);
        }

        public void EndEvent()
        {
            Console.WriteLine("Событие завершено");
        }

        public string SetOutdoorSeating(bool hasOutdoorSeating)
        {
           OutdoorSeating = hasOutdoorSeating;
           return "Открытая площадка: " + (hasOutdoorSeating ? "Да" : "Нет");
        }
    }
}
