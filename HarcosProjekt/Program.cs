using System;
using System.Collections.Generic;

namespace HarcosProjekt
{
    class Program
    {
        public static string name;

        static void Main(string[] args)
        {
            Start();
        }


        public static void Start()
        {
            int chosenChamp;
            Console.WriteLine("Add your username!");
            name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\t    Welcome "+name + "\n\n\t\t\t\t\t\tChoose your Champ! \n\n\t\t\t\t(1)Warrior: \t Health: 15 \t Damage: 3 \n\t\t\t\t(2)Archer: \t Health: 12 \t Damage: 4 \n\t\t\t\t(3)Mage: \t Health: 8 \t Damage: 5");
            bool isNumber = Int32.TryParse(Console.ReadLine(), out chosenChamp);
            while (!isNumber || chosenChamp <1 || chosenChamp > 3)
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\t\t\t    Welcome " + name + "\n\n\t\t\t\t\t\tChoose your Champ! \n\n\t\t\t\t(1)Warrior: \t Health: 15 \t Damage: 3 \n\t\t\t\t(2)Archer: \t Health: 12 \t Damage: 4 \n\t\t\t\t(3)Mage: \t Health: 8 \t Damage: 5");
                if (!isNumber)
                {
                    Console.WriteLine("\n\t\t\t\t\t\tEz nem szam ");
                }
                isNumber =Int32.TryParse(Console.ReadLine(), out chosenChamp);
            }


        }
    }
}
