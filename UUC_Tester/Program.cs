using System;
using uuc;

namespace UUC_Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Universal Unit Converter!");

            Console.WriteLine("Checking modules...");
            UC_Modules.CheckModules();

            for (int i = 0; i < UC_Modules.UnitTypes.GetLength(0); i++)
            {
                if(UC_Modules.UnitTypes[i,3] == "1")
                    Console.WriteLine(UC_Modules.UnitTypes[i, 1] + " Found.");
                else
                    Console.WriteLine(UC_Modules.UnitTypes[i, 1] + " Not found.");
            }

            Console.ReadLine();
        }
    }
}
