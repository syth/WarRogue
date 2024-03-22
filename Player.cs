namespace WarRogue {
    class Player {
        public string Name { get; private set; }
        private readonly Random Random = new();
        public List<Card> Hand { get; private set; }
        public List<Card> Discard { get; private set; }

        public Player( string name ) {
            Name = name;
            Hand = new List<Card>();
            Discard = new List<Card>();
        }

        public void AddCards( List<Card> cards ) {
            Hand.AddRange( cards );
        }

        public Card PlayCard() {
            if ( Hand.Count > 0 ) {
                Card card = Hand[ 0 ];
                Hand.RemoveAt( 0 );
                return card;
            } else {
                throw new InvalidOperationException( "Deck is empty." );
            }
        }

        public void AddDiscardToHand()
        {
            if( !HasCards() )       // Only if the hand is empty can discarded cards be added
            {
                // Shuffle the discard deck
                int n = Discard.Count;
                while ( n > 1)
                {
                    n--;
                    int k = Random.Next(n + 1);
                    Card value = Discard[k];
                    Discard[k] = Discard[n];
                    Discard[n] = value;
                }

                Hand.AddRange( Discard );
                Discard.Clear();
                
            } else              // If the hand is not empty then discarded cards cannot be added
            {
                throw new InvalidOperationException( "Hand is not empty." );
            }
        }

        public void DiscardDeck( List<Card> discarded )
        {
            if( discarded.Count > 0 )
            {
                Discard.AddRange( discarded );
                Console.WriteLine( "Added cards to discard pile" );
            }
        }

        public bool HasCards() {
            return Hand.Count > 0;
        }
    }
}
