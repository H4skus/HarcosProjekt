using System;
using System.Collections.Generic;

namespace HarcosProjekt
{
    class Program
    {
        static Harcos player;
        static Harcos bot;
        static string message;
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            Start();
            Console.Clear();
            bot = new Harcos("Dunny", rnd.Next(1,4));
            Scan();
            Fight();
        }


        public static void Start()
        {
            string name;
            int chosenChamp;
            Console.WriteLine("\t\t\t\t\t\t   Add your username!");
            name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\t    Welcome "+name + "\n\n\t\t\t\t\t\t  Choose your Champ! \n\n\t\t\t\t(1)Warrior: \t Health: 15 \t Damage: 3 \n\t\t\t\t(2)Archer: \t Health: 12 \t Damage: 4 \n\t\t\t\t(3)Mage: \t Health: 8 \t Damage: 5");
            bool isNumber = Int32.TryParse(Console.ReadLine(), out chosenChamp);
            while (!isNumber || chosenChamp <1 || chosenChamp > 3)
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\t\t\t    Welcome " + name + "\n\n\t\t\t\t\t\t  Choose your Champ! \n\n\t\t\t\t(1)Warrior: \t Health: 15 \t Damage: 3 \n\t\t\t\t(2)Archer: \t Health: 12 \t Damage: 4 \n\t\t\t\t(3)Mage: \t Health: 8 \t Damage: 5");
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
            string command;
            do
            {
                Console.WriteLine("Press a key to fight!");
                Console.ReadKey();
                attack();
                Console.WriteLine("Press 'f' to leave , or press any key to contiune attack.");
                command = Console.ReadLine();
            } while (command != "f" || !isDeath());
            menu();
        }

        public static void Scan()
        {
            Console.Clear();
            Console.WriteLine(player);
            Console.WriteLine("\n");
            Console.WriteLine(bot);
            if (player.Role == bot.Role)
            {
                Console.Clear();
                message = "Error!";
                Console.WriteLine("\t\t\t\t\t\t    "+message);
                bot = new Harcos("Dunny", rnd.Next(1, 4));
                Console.WriteLine("Press a key to find a new enenmy ");
                Console.ReadKey();
                Scan();
            }
            else if(player.Health == 0)
            {
                Console.Clear();
                Console.WriteLine(player);
                message = "Your health is too low to fight...";
                Console.WriteLine(message);
            }
        }
        public static bool isDeath()
        {
            if (player.Health < 0)
            {
                bot.Exp += 10;
                Console.Clear();
                message = "You died...";
                Console.WriteLine(message);
                Console.WriteLine("Press a key..");
                Console.ReadKey();
                return true;
            }
            else if (bot.Health < 0)
            {
                player.Exp += 10;
                message = "Your enemy's died.";
                Console.WriteLine(message);
                Console.WriteLine("Press a key..");
                Console.ReadKey();
                return true;
            }
            else
            {
                player.Exp += 5;
                bot.Exp += 5;
                return false;
            }
        }

        public static void attack()
        {
            bot.Health -= player.Damage;
            player.Health -= bot.Damage;
            isDeath();
            Console.Clear();
            Console.WriteLine(player);
            Console.WriteLine("\n");
            Console.WriteLine(bot);
        }

        public static void menu()
        {
            Console.Clear();
            Console.WriteLine(player);
        }
    }
}
