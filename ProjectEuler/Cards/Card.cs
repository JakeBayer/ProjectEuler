using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Cards
{
    public class Card : IEquatable<Card>
    {
        public Suit Suit { get; }
        public Rank Rank { get; }
        public Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public static bool operator ==(Card left, Card right)
        {
            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(left, right))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)left == null) || ((object)right == null))
            {
                return false;
            }

            // Return true if the fields match:
            return left.Equals(right);
        }

        public static bool operator !=(Card left, Card right)
        {
            return !(left == right);
        }

        public bool Equals(Card other)
        {
            if (other == null)
            {
                return false;
            }

            return Rank == other.Rank && Suit == other.Suit;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Card);
        }

        public override int GetHashCode()
        {
            return Suit.GetHashCode() ^ Rank.GetHashCode();
        }

        // Not strictly needed but why not do it....
        public override string ToString()
        {
            // Take advantage of how the Enum.ToString() method functions
            return Rank.ToString() + " of " + Suit.ToString();
        }
    }
}
