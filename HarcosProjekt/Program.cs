using System;
using System.Collections.Generic;

namespace HarcosProjekt
{
    class Program
    {
        static Harcos player;

        static void Main(string[] args)
        {
            Start();
            Console.Clear();
            Console.WriteLine(player);
            Console.ReadKey();
        }


        public static void Start()
        {
            string name;
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
                    Console.WriteLine("\n\t\t\t\t\t\tIs not a number! ");
                }
                else if(chosenChamp < 1 || chosenChamp > 3)
                {
                    Console.WriteLine("\n\t\t\t\t\tHave no champion with this number! ");
                }
                isNumber =Int32.TryParse(Console.ReadLine(), out chosenChamp);
            }
            player = new Harcos(name, chosenChamp);
        }
    }
}
