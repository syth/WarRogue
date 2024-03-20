using System;
using System.Collections.Generic;

namespace WarRogue {
    public class Deck {
        private List<Card> cards = new List<Card>();
        private Random random = new Random();

        public Deck() {
            foreach ( Suit suit in Enum.GetValues( typeof( Suit ) ) ) {
                foreach ( Value value in Enum.GetValues( typeof( Value ) ) ) {
                    cards.Add( new Card( suit, value ) );
                }
            }
        }

        public void Shuffle() {
            int n = cards.Count;
            while ( n > 1 ) {
                n--;
                int k = random.Next( n + 1 );
                Card value = cards[ k ];
                cards[ k ] = cards[ n ];
                cards[ n ] = value;
            }
        }

        public List<Card> DealCards( int count ) {
            if ( count > cards.Count ) {
                throw new InvalidOperationException("Not enough cards in the deck to deal.");
            }

            List<Card> dealtCards = new List<Card>();
            for ( int i = 0; i < count; i++ ) {
                dealtCards.Add( cards[ 0 ] );
                cards.RemoveAt( 0 );
            }

            return dealtCards;
        }

        public int CardsLeft() {
            return cards.Count;
        }
    }
}
