using System;
using System.Collections.Generic;
using System.Text;

namespace HarcosProjekt
{
    class Harcos
    {

        private string name, role;
        private int level, exp, health, startHealth, startDamage;

        public override string ToString()
        {
            return string.Format($"\t\t\t\t\t\t{name} - {role} \n\t\t\t\tLVL:{level} \n\t\t\t\tEXP: {exp}/{NextLevel} \n\t\t\t\tHP: {health}/{MaxHealth} \n\t\t\t\tDMG: {Damage}");
        }

        public Harcos(string name ,int status)
        {
            switch (status)
            {
                case 2:
                    startDamage = 4;
                    startHealth = 12;
                    role = "Archer";
                    break;
                case 3:
                    startHealth = 8;
                    startDamage = 5;
                    role = "Mage";
                    break;
                default:
                    startHealth = 15;
                    startDamage = 3;
                    role = "Warrior";
                    break;
            }
            this.name = name;
            level = 1;
            exp = 0;
            health = MaxHealth;

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
