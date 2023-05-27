using System;
using System.Collections.Generic;
using System.Text;

namespace Lib
{
    public interface IBuilding
    {
        int Floors { get; set; } // свойство - количество этажей
        string Open(); // метод - открытие здания
        string Close(); // метод - закрытие здания
    }
}
