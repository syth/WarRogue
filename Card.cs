namespace WarRogue {
    public enum Suit {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }

    public enum Value {
        Ace = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13
    }
    public class Card {
        public Suit suit { get; private set; }
        public Value value { get; private set; }

        public Card( Suit suit, Value value )
        {
            this.suit = suit;
            this.value = value;
        }

        public override string ToString() {
            return $"{value} of {suit}";
        }
    }

    public class CardComparer {
        public static bool IsCardHigher( Card card1, Card card2 ) {
            return card1.value > card2.value;
        }
    }

}