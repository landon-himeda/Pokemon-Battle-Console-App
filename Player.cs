using System;
using System.Collections.Generic;

namespace Pokeymans
{
    class Player
    {
        public string Name {get;set;}
        public List<Pokemon> MyPokemon {get;set;}
        public bool PokemonIsAlive
        {
            get
            {
                return this.MyPokemon[0].IsAlive;
            }
        }

        public Player(string name)
        {
            Name = name;
            MyPokemon = new List<Pokemon>();
        }

        public void AddPokemon(Pokemon pokemon)
        {
            MyPokemon.Add(pokemon);
        }
    }
}
