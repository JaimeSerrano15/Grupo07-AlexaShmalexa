using System;
using mef3d;
using System.Collections.Generic;

namespace mef3d
{

    public enum week
    {
        sunday,
        monday,
        tuesday,
        wednesday,
        thursday,
        friday,
        saturday
    }
    class Program
    {
        static void Main(string[] args)
        {
            int hey = Convert.ToInt32(week.monday);
            Console.WriteLine(hey);
        }
    }
}
