namespace WarRogue {
    public class Deck {
        private readonly List<Card> Cards = new();
        private readonly Random Random = new();

        public Deck() {
            foreach ( Suit suit in Enum.GetValues( typeof( Suit ) ) ) {
                foreach ( Value value in Enum.GetValues( typeof( Value ) ) ) {
                    Cards.Add( new Card( suit, value ) );
                }
            }
        }

        public void Shuffle() {
            int n = Cards.Count;
            while ( n > 1 ) {
                n--;
                int k = Random.Next( n + 1 );
                Card value = Cards[ k ];
                Cards[ k ] = Cards[ n ];
                Cards[ n ] = value;
            }
        }

        public List<Card> DealCards( int count ) {
            if ( count > Cards.Count ) {
                throw new InvalidOperationException( "Not enough cards in the deck to deal." );
            }

            List<Card> dealtCards = new();
            for ( int i = 0; i < count; i++ ) {
                dealtCards.Add( Cards[ 0 ] );
                Cards.RemoveAt( 0 );
            }

            return dealtCards;
        }

        public int CardsLeft() {
            return Cards.Count;
        }
    }
}
