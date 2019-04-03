using System;
using System.Collections.Generic;

namespace Pokeymans
{
    class Game
    {
        public bool IsPlayer1Turn {get;set;}
        public Player Player1 {get;set;}
        public Player Player2 {get;set;}
        public string[] PokemonArt = {"                                .::.                          ",
            "                              .;:**'                          ",
            "                              `                  0            ",
            "  .:XHHHHk.              db.   .;;.     dH  MX   0            ",
            "oMMMMMMMMMMM       ~MM  dMMP :MMMMMR   MMM  MR      ~MRMN     ",
            "QMMMMMb  'MMX       MMMMMMP !MX' :M~   MMM MMM  .oo. XMMM 'MMM",
            "  `MMMM.  )M> :X!Hk. MMMM   XMM.o'  .  MMMMMMM X?XMMM MMM>!MMP",
            "   'MMMb.dM! XM M'?M MMMMMX.`MMMMMMMM~ MM MMM XM `' MX MMXXMM ",
            "    ~MMMMM~ XMM. .XM XM`'MMMb.~*?**~ .MMX M t MMbooMM XMMMMMP ",
            "     ?MMM>  YMMMMMM! MM   `?MMRb.    `'''   !L'MMMMM XM IMMM  ",
            "      MMMX   'MMMM'  MM       ~%:           !Mh.''' dMI IMMP  ",
            "      'MMM.                                             IMX   ",
            "       ~M!M                                             IMP   ",
            "                                                              "};

        public Game(Player player1, Player player2)
        {
            Player1 = player1;
            Player2 = player2;
            IsPlayer1Turn = true;
        }

        public void ChooseAttack(Player me, Player opponent)
        {
            Console.WriteLine("Enter which attack you would like:");

            int attackNum = Int32.Parse(Console.ReadLine());
            switch (attackNum)
            {
                case 1:
                    me.MyPokemon[0].UseAttack(me.MyPokemon[0].MyAttacks[0], opponent.MyPokemon[0]);
                    break;
                case 2:
                    me.MyPokemon[0].UseAttack(me.MyPokemon[0].MyAttacks[1], opponent.MyPokemon[0]);
                    break;
                case 3:
                    me.MyPokemon[0].UseAttack(me.MyPokemon[0].MyAttacks[2], opponent.MyPokemon[0]);
                    break;
                case 4:
                    me.MyPokemon[0].UseAttack(me.MyPokemon[0].MyAttacks[3], opponent.MyPokemon[0]);
                    break;
                default:
                    System.Console.WriteLine("You didn't choose a valid attack.");
                    ChooseAttack(me, opponent);
                    break;
            }
        }
        public void Turn(Player me, Player opponent)
        {
            System.Console.WriteLine($"It is {me.Name}'s turn! Choose an attack for {me.MyPokemon[0].Name}.");
            foreach (string line in me.MyPokemon[0].Picture)
            {
                System.Console.WriteLine(line);
            }
            for (int i = 0; i < me.MyPokemon[0].MyAttacks.Length; i++)
            {
                Attack atk = me.MyPokemon[0].MyAttacks[i];
                System.Console.WriteLine($"Attack {i+1}: {atk.Name}");
            }
            System.Console.WriteLine();
            ChooseAttack(me, opponent);
        }
        public void Start()
        {
            for (int i = 0; i < PokemonArt.Length; i++)
            {
                System.Console.WriteLine(PokemonArt[i]);
            }
            while (Player1.PokemonIsAlive && Player2.PokemonIsAlive)
            {
                if (IsPlayer1Turn)
                {
                    Turn(Player1, Player2);
                    IsPlayer1Turn = false;

                }
                else
                {
                    Turn(Player2, Player1);
                    IsPlayer1Turn = true;
                }

                if(!Player1.PokemonIsAlive)
                {
                    System.Console.WriteLine($"Player {Player2.Name} wins!");
                }
                if(!Player2.PokemonIsAlive)
                {
                    System.Console.WriteLine($"Player {Player1.Name} wins!");
                }
            }
        }
    }
}