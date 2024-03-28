namespace WarRogue {
    public class Game {
        private readonly Deck deck;
        private readonly Player player1;
        private readonly Player player2;

        public Game( string player1Name, string player2Name ) {
            deck = new Deck();
            deck.Shuffle();
            player1 = new Player( player1Name );
            player2 = new Player( player2Name );
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
                    Console.WriteLine( $"{ player1.Name } draws from their discard pile.");
                    player1.AddDiscardToHand();
                }

                if( !player2.HasCards() && player2.Discard.Count > 0 )
                {
                    Console.WriteLine( $"{ player2.Name } draws from their discard pile.");
                    player2.AddDiscardToHand();
                }

                try
                {
                    Card player1Card = player1.PlayCard();
                    Card player2Card = player2.PlayCard();
                    List<Card> playedCards = new()
                {
                    player1Card,
                    player2Card
                };
                    Console.WriteLine($"{player1.Name} plays: {player1Card}");
                    Console.WriteLine($"{player2.Name} plays: {player2Card}");

                    if (CardComparer.IsCardHigher(player1Card, player2Card))
                    {
                        Console.WriteLine($"{player1.Name} wins the round.");
                        player1.DiscardDeck(playedCards);
                    }
                    else if (CardComparer.IsCardHigher(player2Card, player1Card))
                    {
                        Console.WriteLine($"{player2.Name} wins the round.");
                        player2.DiscardDeck(playedCards);
                    }
                    else
                    {
                        Console.WriteLine($"A war has broken out between {player1.Name} and {player2.Name}!");
                        // TODO: Add logic to go to war (possibly make a method for when war happens multiple times [nested wars])

                    }
                } catch ( EmptyHandException )
                {
                    if (player1.HasCards())
                    {
                        Console.WriteLine($"{player1.Name} wins!");
                        break;
                    }
                    else if (player2.HasCards())
                    {
                        Console.WriteLine($"{player2.Name} wins!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("It's a tie!");
                        break;
                    }
                }
            }
        }
    }
}
