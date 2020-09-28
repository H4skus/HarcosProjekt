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
            chooseEnemy();
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
            Console.Clear();
            Console.WriteLine("Press a key to fight.. \n press 'f' to leave");
            string command = Console.ReadLine();
            do
            {
                Console.Clear();
                Console.WriteLine(player);
                Console.WriteLine(enemy[chooseEnemy()]);
                attack();

            } while (command != "f");
            menu();

        }

        public static void Scan()
        {
            if (player.Exp == player.NextLevel)
            {
                player.Level++;
            }
            else if (enemy[chooseEnemy()].Exp == enemy[chooseEnemy()].NextLevel)
            {
                enemy[chooseEnemy()].Level++;
            }
            else if (enemy[chooseEnemy()].Health == 0)
            {

                message = "Your enemy's health too low to fight..";
                Console.WriteLine(message);
                menu();
            }
            else if(player.Health == 0)
            {
                Console.Clear();
                Console.WriteLine(player);
                message = "Your health is too low to fight...";
                Console.WriteLine(message);
                menu();
            }
        }
        public static void isDeath()
        {
            if (player.Health < 0)
            {
                enemy[chooseEnemy()].Exp += 10;
                Console.Clear();
                message = "You died...";
                Console.WriteLine(message);
                Console.WriteLine("Press a key..");
                Console.ReadKey();
                menu();
            }
            else if (bot.Health < 0)
            {
                player.Exp += 10;
                Console.Clear();
                message = "Your enemy's died.";
                Console.WriteLine(message);
                Console.WriteLine("Press a key..");
                Console.ReadKey();
                menu();
            }
            else
            {
                enemy[chooseEnemy()].Exp += 5;
                player.Exp += 5;
                Fight();
            }
        }

        public static void heal()
        {

        }

        public static void attack()
        {
            player.Health -= enemy[chooseEnemy()].Damage;
            enemy[chooseEnemy()].Health -= player.Damage;
            Scan();
            Fight();
        }

        public static void menu()
        {
            Console.Clear();
            Console.WriteLine(player + "\n\n\t\t\t\t\t\tPress a key to find enemy..");
            Console.WriteLine("\n\t\t\t\t\t\t   Press 'h' to heal..");
            string command = Console.ReadLine();
            if (command == "h")
            {
                heal();
            }
            Console.Clear();
            Console.WriteLine(player+"\n\n\t\t\t\t\t\tChoose your enemy..\n\n");
            listEnemy();
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
        public static int chooseEnemy()
        {
            Int32.TryParse(Console.ReadLine(), out int choosen);
            Console.Clear();
            return choosen;

        }
    }
}
