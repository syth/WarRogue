namespace WarRogue {
    public class Game {
        private readonly Deck deck;
        private readonly Player player1;
        private readonly Player player2;

        public Game() {
            deck = new Deck();
            deck.Shuffle();
            player1 = new Player( "Player 1" );
            player2 = new Player( "Player 2" );
            DealInitialCards();
        }

        private void DealInitialCards() {
            List<Card> player1Cards = deck.DealCards( 26 );
            List<Card> player2Cards = deck.DealCards( 26 );
            player1.AddCards( player1Cards );
            player2.AddCards( player2Cards );
        }

        public void Play() {
            while ( player1.HasCards() && player2.HasCards() || ( player1.Discard.Count > 0 ) || ( player2.Discard.Count > 0 ) ) {

                if( !player1.HasCards() && player1.Discard.Count > 0 )
                {
                    // TODO: Add implementation for adding discard deck to hand
                }

                // TODO: Add implementation for adding discard deck to hand (player 2)

                Card player1Card = player1.PlayCard();
                Card player2Card = player2.PlayCard();
                List<Card> playedCards = new()
                {
                    player1Card,
                    player2Card
                };

                Console.WriteLine( $"Player 1 plays: {player1Card}" );
                Console.WriteLine( $"Player 2 plays: {player2Card}" );

                if ( CardComparer.IsCardHigher( player1Card, player2Card ) ) {
                    Console.WriteLine( "Player 1 wins the round." );
                    player1.DiscardDeck(playedCards);
                } else if ( CardComparer.IsCardHigher( player2Card, player1Card ) ) {
                    Console.WriteLine( "Player 2 wins the round." );
                    player2.DiscardDeck(playedCards);
                } else {
                    // TODO: Add logic to go to war (possibly make a method for when war happens multiple times [nested wars])

                }

            }

            if ( player1.HasCards() ) {
                Console.WriteLine( "Player 1 wins!" );
            } else if ( player2.HasCards() ) {
                Console.WriteLine( "Player 2 wins!" );
            } else {
                Console.WriteLine( "It's a tie!" );
            }
        }
    }
}
