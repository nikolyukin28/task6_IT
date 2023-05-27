using System;
using System.Collections.Generic;
using System.Text;

namespace Lib
{
    public abstract class PublicBuilding : IBuilding
    {
        public int Floors { get; set; }
        public int Capacity { get; set; } // свойство - вместимость здания
        public string Address { get; set; } // свойство - адрес здания
        public string Event { get; set; }

        public string Open()
        {
            return "Здание открыто";
        }

        public string Close()
        {
            return "Здание закрыто";
        }

        public abstract string ShowEvents(); // абстрактный метод - показать мероприятия
        public virtual string ShowCapacity() // виртуальный метод - показать вместимость здания
        {
            return "Вместимость здания: " + Capacity + " человек";
        }

    }
}
