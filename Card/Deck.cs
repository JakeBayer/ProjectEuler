using System;
using System.Collections.Generic;

namespace Card
{
    public class Deck<T> : LinkedList<T>
        where T : CardBase
    {
        private readonly Random _rand = new Random();
        private readonly LinkedList<T> _discardPile = new LinkedList<T>();

        public Deck() : base() { }

        public Deck(IEnumerable<T> cards) : base(cards) { }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public T Draw()
        {
            var top = First.Value;
            RemoveFirst();
            _discardPile.AddLast(top);
            return top;
        }

        public T DrawAndReturn()
        {
            var top = First;
            RemoveFirst();
            AddLast(top);
            return top.Value;
        }

        public IEnumerable<T> Draw(int num)
        {
            for (int i = 0; i < num; i++)
            {
                yield return Draw();
            }
        }

        public void Shuffle()
        {
            if (Count < 2) return;
            var result = new T[Count];
            int i = 0;
            foreach(var card in this)
            {
                int j = _rand.Next(i + 1);
                if (i != j)
                    result[i] = result[j];
                result[j] = card;
                i++;
            }
            i = 0;
            for (var node = First; node != null; node = node.Next)
            {
                node.Value = result[i];
                i++;
            }
        }

        public void Reshuffle()
        {
            foreach (var c in _discardPile)
            {
                AddLast(c);
            }
            _discardPile.Clear();
            Shuffle();
        }
    }
}
