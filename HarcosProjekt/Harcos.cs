using System;
using System.Collections.Generic;
using System.Text;

namespace HarcosProjekt
{
    class Harcos
    {

        private string name;
        private int level, exp, health, startHealth, startDamage;

        public Harcos(string name , int level, int exp, int health, int startHealth, int startDamage)
        {
            this.name = name;
            this.level = level;
            this.exp = exp;
            this.health = health;
            this.startHealth = startHealth;
            this.startDamage = startDamage;
        }
    }
}
