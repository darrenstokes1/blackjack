using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack
{
    class Program

    {

        public enum Suit
        {
            Hearts,
            Clubs,
            Diamonds,
            Spades
        }

        public enum Rank
        {
            Ace,
            Deuce,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King
        }
        public class Card
        {
            public Suit Suit { get; set; }
            public Rank Rank { get; set; }

            public Card(Suit s, Rank r)
            {
                this.Suit = s;
                this.Rank = r;
            }

            public int GetCardValue() // Use this function to total cards
            {
                var rv = 0;
                switch (this.Rank)
                {
                    case Rank.Ace:
                        rv = 11; // Explorer Mode
                        break;
                    case Rank.Deuce:
                        rv = 2;
                        break;
                    case Rank.Three:
                        rv = 3;
                        break;
                    case Rank.Four:
                        rv = 4;
                        break;
                    case Rank.Five:
                        rv = 5;
                        break;
                    case Rank.Six:
                        rv = 6;
                        break;
                    case Rank.Seven:
                        rv = 7;
                        break;
                    case Rank.Eight:
                        rv = 8;
                        break;
                    case Rank.Nine:
                        rv = 9;
                        break;
                    case Rank.Ten:
                        rv = 10;
                        break;
                    case Rank.Jack:
                        rv = 10;
                        break;
                    case Rank.Queen:
                        rv = 10;
                        break;
                    case Rank.King:
                        rv = 10;
                        break;
                    default:
                        break;
                }
                return rv;
            }
            public override string ToString()
            {
                return $"The {this.Rank} of {this.Suit}";
            }
        }


        static void Main(string[] args)
        {
            // Create the deck and load in the cards
            var deck = new List<Card>();
            List<Card> randomDeck;

            foreach (Rank r in Enum.GetValues(typeof(Rank)))
            {
                foreach (Suit s in Enum.GetValues(typeof(Suit)))
                {
                    deck.Add(new Card(s, r));
                }
            }

            //sort the deck. NOTICE that the variable 'deck' is unchanged, but 'randomDeck' is the actual sorted deck.
            randomDeck = deck.OrderBy(x => Guid.NewGuid()).ToList();

            // Declare varables and intialize counters
            var player1Card = 0;
            var player1Hand = 0;
            var dealerCard = 0;
            var dealerHand = 0;
            var counter = 0;

            // Declare players
            Card dealer;
            Card player1;


            // Deal the cards from shuffled deck player1 goes first
            player1 = randomDeck[counter];
            counter++;	// Increments cards in deck
            player1Hand = player1.GetCardValue(); // Gets value of card
            player1Card++;		// Increments cards in hand
            Console.WriteLine();
            Console.WriteLine($"Player, your card is the {player1}.");
            Console.WriteLine();
            // Deal the cards from shuffled deck dealer goes next
            dealer = randomDeck[counter];
            counter++; // Increments cards in deck
            dealerHand = dealer.GetCardValue(); // Gets value of card
            dealerCard++;  // Increments cards in deck
            Console.WriteLine();
            Console.WriteLine($"Dealer, your card is the {dealer}.");
            Console.WriteLine();
            // player1 dealt second card
            player1 = randomDeck[counter];
            counter++;
            player1Hand += player1.GetCardValue(); // adds the value of the cards
            player1Card++;
            // Total player hand
            Console.WriteLine();
            Console.WriteLine($"Player, your card is the {player1}.");
            Console.WriteLine();
            Console.WriteLine("Player, so far you have " + player1Hand);
            Console.WriteLine();
            // Dealer dealt second card
            dealer = randomDeck[counter];
            counter++;
            dealerHand += dealer.GetCardValue();
            dealerCard++;
            Console.WriteLine("The house is showing " + dealerHand);
            // Evaluate hand and ask if player wants another card
            bool playerStillPlays = true;

            while (player1Hand <= 21 && playerStillPlays)
            {

                if (player1Hand < 21)
                {
                    Console.WriteLine();
                    Console.WriteLine("Player, would you like another card? Y or N ");
                    string reply1 = Console.ReadLine();
                    // Player wants another card
                    if (reply1 == "y" || reply1 == "Y") // Use Console. ReadLine().ToUpper() in future in var reply
                    {
                        player1 = randomDeck[counter];
                        counter++;
                        player1Hand += player1.GetCardValue();
                        player1Card++;
                        // Total player hand
                        Console.WriteLine();
                        Console.WriteLine($"Player, your card is the {player1}.");
                        Console.WriteLine();
                        Console.WriteLine("Player, so far you have " + player1Hand);
                        Console.WriteLine();

                    }

                    // Player holds
                    else if (reply1 == "n" || reply1 == "N")
                    {
                        Console.WriteLine("Player stands at " + player1Hand);
                        Console.WriteLine();
                        playerStillPlays = false;

                    }
                }
                // Evaluate hand and ask if dealer wants another card
                bool dealerStillPlays = true;
                while (dealerHand <= 16 && dealerStillPlays)
                {
                    if (dealerHand < 16)

                        Console.WriteLine();
                    Console.WriteLine("Dealer, would you like another card? Y or N ");
                    string reply1 = Console.ReadLine();

                    // Dealer wants another card
                    if (reply1 == "y" || reply1 == "Y") // Use Console. ReadLine().ToUpper() in future in var reply
                    {
                        dealer = randomDeck[counter];
                        counter++;
                        dealerHand += dealer.GetCardValue();
                        dealerCard++;
                        // Total dealer hand
                        Console.WriteLine();
                        Console.WriteLine("The house has " + dealerHand);
                        Console.WriteLine();
                        //Console.WriteLine("Dealer, would you like another card? Y or N ");
                    }
                    // Dealer holds
                    else if (reply1 == "n" || reply1 == "N")
                    {
                        Console.WriteLine("House stands at " + dealerHand);
                        Console.WriteLine();
                        dealerStillPlays = false;
                    }
                }

                // Dealer holds Eval for win
                {
                    if (player1Hand > 21) // Player exceeds 21
                    {
                        Console.WriteLine("House wins!!...You're over 21");
                        Console.WriteLine();
                        Console.WriteLine("The House has " + dealerHand);

                    }
                    else if (dealerHand > 21) // Dealer exceeds 21
                    {
                        Console.WriteLine("The House busted! Player wins!");
                        Console.WriteLine();
                        Console.WriteLine("The house has " + dealerHand);
                    }
                    else if (dealerHand >= player1Hand) // Dealer wins outright
                    {
                        Console.WriteLine("The House wins again!");
                        Console.WriteLine();
                        Console.WriteLine("The house has " + dealerHand);
                    }

                    else if (player1Hand > dealerHand)
                    {
                        Console.WriteLine("Congrats! Player you win!");
                        Console.WriteLine();
                        Console.WriteLine("Player, you have " + player1Hand);
                    }

                    Console.ReadLine();
                }
            }
        }
    }

}
