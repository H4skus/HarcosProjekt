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
            Console.WriteLine("Kerem adja meg a nevet");
            name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Kerem valasszon opciot! ");

        }
    }
}
