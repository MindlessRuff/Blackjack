using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Deck : IComparable<Deck>
    {
         private const int num_Faces = 13; 
         private const int num_Suits = 4;
         private const int num_Cards = 52;
         // This will be the stack to store the game's actual deck of cards, will be reshuffled, drawn from, etc.
         private Stack<string> deck = new Stack<string>();
         /* This is an array to store all 52 cards, it will not be drawn from or added to upon intialization.
          * It is static to avoid making multiple copies with multiple decks.
          * Will be used to create the deck stack(s) and when shuffling. */
         private static string[] unshuffledDeck = new string[52];
         public Deck()
         {
            // If the array of ordered cards is empty, create it.
            if (unshuffledDeck[0] == null)
            {
                int count = 0;
                // T is 10, J is Jack, and so on.
                char[] faces = { 'A', '2', '3', '4',  '5',
                                 '6', '7', '8', '9', 'T',
                                 'J', 'Q', 'K' };

                //suits: Clubs, Diamonds, Hearts, Spades
                char[] suits = { 'C', 'D', 'H', 'S' };

                for (int face = 0; face < num_Faces; face++)
                {
                    for (int suit = 0; suit < num_Suits; suit++, count++)
                    {
                        char[] temp = { 'A', 's', 's', 'e', 't', 's', '/', faces[face], '_', suits[suit], '.', 'p', 'n', 'g' };
                        string card = new string(temp);
                        unshuffledDeck[count] = card;
                    }
                }
            }
         }

         //Reference: https://bit.ly/2OVo1G9
         public static void Shuffle(Stack<string> deck_Of_Cards)
         {
            deck_Of_Cards.Clear();
            Random rand = new Random();
            //For each spot in the array, 
            //a random item to swap into that spot
            int i;
            for (i = 0; i < 52; i++)
            {
                int j = rand.Next(i, 52);
                string temp = unshuffledDeck[i];
                unshuffledDeck[i] = unshuffledDeck[j];
                unshuffledDeck[j] = temp;
            }
            for (i = 0; i < 52; ++i)
            {
                deck_Of_Cards.Push(unshuffledDeck[i]);
            }
         }

         public void Shuffle_Deck()
         {
             Shuffle(deck);
         }

        /// <summary>
        /// Deals a card from the top of the Stack.
        /// </summary>
        /// <returns></returns>
        public string Deal_Card()
        {
            string top_Card = "";
            top_Card = deck.Pop();
            return top_Card;
        }

        /// <summary>
        /// Checks the remaining number of cards in the deck.
        /// </summary>
        public int CardsInStack()
        {
            return deck.Count();
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int CompareTo(Deck other)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
