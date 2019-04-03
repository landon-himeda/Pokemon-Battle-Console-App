using System;
using System.Collections.Generic;

namespace Pokeymans
{
    class Pokemon
    {
        public string Name {get;set;}
        public Attack[] MyAttacks {get;set;}
        private int health;
        public bool IsAlive 
        {
            get
            {
                return this.health >0;
            }
        }
        public string[] Picture {get;set;}

        public Pokemon(string name, Attack attack1, Attack attack2, Attack attack3, Attack attack4, int Health, string[] pic)
        {
            Name = name;
            MyAttacks = new Attack[4];
            MyAttacks[0] = attack1;
            MyAttacks[1] = attack2;
            MyAttacks[2] = attack3;
            MyAttacks[3] = attack4;
            health = Health;
            Picture = pic;
        }

        public int UseAttack(Attack attack, Pokemon target)
        {
            int damage = attack.Damage;
            target.health -= damage;
            System.Console.WriteLine($"{this.Name} used {attack.Name}! It dealt {damage} damage!");
            System.Console.WriteLine();
            if (target.health > 0)
            {
                System.Console.WriteLine($"{target.Name} has {target.health} HP remaining.");
            }
            else
            {
                System.Console.WriteLine($"{target.Name} fainted!");
            }
            return target.health;
        }
    }
}