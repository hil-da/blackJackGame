using System;
using System.Threading;

namespace blackJack
{
    public class Game
    {
        public Player player;
        public Player dealer;
        public Deck deck;
        public gameStatus status;

        public enum gameStatus // statuses throughout the game
        {
            dealerWin,
            playerWin,
            Playing,
            Tie,
            BlackJack
        }

        public Game()
        {
            player = new Player { dealer = false };
            dealer = new Player { dealer = true };
            deck = new Deck(5);
        }

        public void Play()
        {
            Console.WriteLine("#############################");
            Console.WriteLine("         Black Jack          ");
            Console.WriteLine("#############################");
            Thread.Sleep(1500);

            status = gameStatus.Playing;

            while (status == gameStatus.Playing)
            {
                PlayerDraw();
                Thread.Sleep(1500);

                PlayerDraw();
                Thread.Sleep(1500);

                DealerDraw();
                Thread.Sleep(1500);
                string choice;

                do // loops unil gamestatus changes or player chooses to continue
                {
                    Console.WriteLine(player.ToString());
                    Console.WriteLine(dealer.ToString());


                    Console.WriteLine("\nWould you like to draw another card?");
                    Console.WriteLine("\t[Y]es");
                    Console.WriteLine("\t[N]o");

                    choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "y":
                            PlayerDraw();
                            Thread.Sleep(1500);
                            break;
                        case "Y":
                            PlayerDraw();
                            Thread.Sleep(1500);
                            break;
                        case "n":
                            DealerDraw();
                            Thread.Sleep(1500);
                            break;
                        case "N":
                            DealerDraw();
                            Thread.Sleep(1500);
                            break;
                    }
                } while ((choice == "y" || choice == "Y") && status == gameStatus.Playing);


                if (status == gameStatus.playerWin)
                {
                    Console.WriteLine("You Won!");
                }
                else
                {
                    Console.WriteLine("You Lost!");
                    Console.WriteLine("Play again?");
                    Console.WriteLine("\t[Y]es");
                    Console.WriteLine("\t[N]o");

                    switch (Console.ReadLine())
                    {
                        case "y":
                            Console.Clear();
                            Play();
                            break;
                        case "Y":
                            Console.Clear();
                            Play();
                            break;
                        case "n":
                            Environment.Exit(1); // exits application
                            break;
                        case "N":
                            Environment.Exit(1);
                            break;
                    }
                }
            }
        }

        public void  Reset() // resets and shuffles the decks
        {
            deck.RNS();
            status = gameStatus.Playing;
        }

        public void PlayerDraw() 
        {
            player.Draw(deck);
            Console.WriteLine("\nPlayer drew: {0}", player.lastDrawnCard);
            checkWin();
        }

        public void DealerDraw()
        {
            dealer.Draw(deck);
            Console.WriteLine("\nDealer drew: {0}", player.lastDrawnCard);
            checkWin();
        }

        public void checkWin() // checks whos winning throughout the active game
        {
            if (player.bestValue == 21)
            {
                status = gameStatus.playerWin;
            }
            else if (player.bestValue == dealer.bestValue)
            {
                status = gameStatus.Tie;
            }
            else if ((dealer.bestValue > 16 && dealer.bestValue < 20) && (player.bestValue > 16 && player.bestValue < 20))
            {
                status = gameStatus.dealerWin;
            }
            else if (dealer.bestValue == 20 && player.bestValue == 20)
            {
                status = gameStatus.Tie;
            }
        }
    }
}
