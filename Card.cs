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
        public Suit Suit { get; private set; }
        public Value Value { get; private set; }

        public Card( Suit suit, Value value )
        {
            Suit = suit;
            Value = value;
        }

        public override string ToString() {
            return $"{Value} of {Suit}";
        }
    }

    public class CardComparer {
        public static bool IsCardHigher( Card card1, Card card2 ) {
            return card1.Value > card2.Value;
        }
    }

}