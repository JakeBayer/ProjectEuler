﻿using System;

namespace Card.PlayingCards
{
    public class PlayingCard : CardBase, IEquatable<PlayingCard>
    {
        public Suit Suit { get; }
        public Rank Rank { get; }
        public PlayingCard(Rank rank, Suit suit)
        {
            Suit = suit;
            Rank = rank;
        }

        public PlayingCard(PlayingCard other)
        {
            Suit = other.Suit;
            Rank = other.Rank;
        }

        public static bool operator ==(PlayingCard left, PlayingCard right)
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

        public static bool operator !=(PlayingCard left, PlayingCard right)
        {
            return !(left == right);
        }

        public bool Equals(PlayingCard other)
        {
            if (other == null)
            {
                return false;
            }

            return Rank == other.Rank && Suit == other.Suit;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as PlayingCard);
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
