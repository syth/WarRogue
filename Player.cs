using System;
using System.Collections.Generic;

namespace WarRogue {
    class Player {
        public string name { get; private set; }
        private List<Card> hand { get; set; }

        public Player(string name) {
            this.name = name;
            hand = new List<Card>();
        }

        public void AddCards( List<Card> cards ) {
            hand.AddRange(cards);
        }

        public Card PlayCard() {
            if (hand.Count > 0) {
                Card card = hand[0];
                hand.RemoveAt(0);
                return card;
            } else {
                throw new InvalidOperationException("Deck is empty.");
            }
        }

        public bool HasCards() {
            return hand.Count > 0;
        }
    }
}
