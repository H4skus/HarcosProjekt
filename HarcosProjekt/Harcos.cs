using System;
using System.Collections.Generic;
using System.Text;

namespace HarcosProjekt
{
    class Harcos
    {

        private string name;
        private int level, exp, health, startHealth, startDamage;

        public Harcos(string name , List <int>status)
        {
            this.name = name;
            level = 1;
            exp = 0;
            startHealth = status[0];
            startDamage = status[1];

        }

        public string Name { get => name; set => name = value; }
        public int Level { get => level; set => level = value; }
        public int Exp { get => exp; set => exp = value; }
        public int StartDamage { get => startDamage; }
        public int StartHealth { get => startHealth; }
        public int Health { get => health; set => health = value; }
        public int Damage { get => startDamage + level; }
        public int NextLevel { get => 10 + level * 5; }
        public int MaxHealth { get => StartHealth + level * 3; }
    }
}
