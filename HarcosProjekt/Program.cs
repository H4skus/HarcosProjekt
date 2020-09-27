using System;
using System.Collections.Generic;
using System.IO;

namespace HarcosProjekt
{
    class Program
    {
        static Harcos player;
        static Harcos bot;
        static string message;
        static Random rnd = new Random();
        static List<Harcos> enemy = new List<Harcos>();

        static void Main(string[] args)
        {
            addEnemys();
            Start();
            menu();
            listEnemy();
            //Fight();
            Console.ReadKey();
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
            Console.WriteLine("Press a key to fight.. \n press 'f' to leave");
            command = Console.ReadLine();
            if (command == "f")
            {
                menu();
            }
            else
            {
                attack();
            }
            
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
        public static void isDeath()
        {
            if (player.Health < 0)
            {
                Console.Clear();
                message = "You died...";
                Console.WriteLine(message);
                Console.WriteLine("Press a key..");
                Console.ReadKey();
                menu();
            }
            else if (bot.Health < 0)
            {
                Console.Clear();
                message = "Your enemy's died.";
                Console.WriteLine(message);
                Console.WriteLine("Press a key..");
                Console.ReadKey();
                menu();
            }
        }

        public static void attack()
        {
            bot.Health -= player.Damage;
            player.Health -= bot.Damage;
            if (bot.Health<0)
            {
                player.Exp += 10;
            }
            else if (player.Health<0)
            {
                bot.Exp += 10;
            }
            else if (bot.Health>0 && player.Health>0)
            {
                player.Exp += 5;
                bot.Exp += 5;
            }
            Console.Clear();
            Console.WriteLine(player);
            Console.WriteLine("\n");
            Console.WriteLine(bot);
            isDeath();
            Fight();
        }

        public static void menu()
        {
            Console.Clear();
            Console.WriteLine(player + "\n\n\t\t\t\t\t\tPress a key to find enemy..");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine(player+"\n\n\t\t\t\t\t\tChoose your enemy..\n\n");
        }

        public static void addEnemys()
        { 
            StreamReader sr = new StreamReader("harcosok.csv", System.Text.Encoding.Default);
            int i = 0;
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] elem = line.Split(';');
                enemy.Add(new Harcos(elem[0],Convert.ToInt32(elem[1])));
                enemy[i].Name = elem[0];
                enemy[i].Template = Convert.ToInt32(elem[1]);
                i++;
            }
        }
        public static void listEnemy()
        {
            for (int i = 0; i < enemy.Count; i++)
            {
                Console.WriteLine("("+i+")"+enemy[i]);
            }
        }
    }
}
