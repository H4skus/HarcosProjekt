using System;
using System.Collections.Generic;

namespace HarcosProjekt
{
    class Program
    {
        static Harcos player;
        static Harcos bot;
        static string message;

        static void Main(string[] args)
        {
            Random rnd = new Random();
            Start();
            Console.Clear();
            bot = new Harcos("Dunny", rnd.Next(1,4));
            Scan();
            Fight();
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

        public static void Fight()
        {
            Console.WriteLine(player);
            Console.WriteLine("\n");
            Console.WriteLine(bot);
        }

        public static void Scan()
        {
            if (player.Role == bot.Role)
            {
                Console.Clear();
                message = "Error!";
                Console.WriteLine("\t\t\t\t\t\t    "+message);
            }
            else if(player.Health == 0)
            {
                Console.Clear();
                Console.WriteLine(player);
                message = "Your health is too low to fight...";
                Console.WriteLine(message);
            }
        }
        public static void isDeath()
        {
            if (player.Health == 0)
            {
                message = "You died...";
                Console.WriteLine(message);
                bot.Exp += 10;
            }
            else if (bot.Health == 0)
            {
                message = "Your enemy's died.";
                Console.WriteLine(message);
                player.Exp += 10;
            }
            else
            {
                player.Exp += 5;
                bot.Exp += 5;
            }
        }
    }
}
