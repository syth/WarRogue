namespace WarRogue {
    class Player {
        public string Name { get; private set; }
        private List<Card> Hand { get; set; }

        public Player( string name ) {
            Name = name;
            Hand = new List<Card>();
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
                throw new InvalidOperationException("Deck is empty.");
            }
        }

        // TODO: Add method to remove a card from a player's hand

        public bool HasCards() {
            return Hand.Count > 0;
        }
    }
}
