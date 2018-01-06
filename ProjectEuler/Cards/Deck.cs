using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Cards
{
    public class Deck<T> : LinkedList<T>
        where T : CardBase
    {
        private readonly Random _rand = new Random();
        private LinkedList<T> _discardPile = new LinkedList<T>();

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

        public IEnumerable<T> Draw(int num)
        {
            for (int i = 0; i < num; i++)
            {
                yield return Draw();
            }
        }

        public Deck<T> Shuffle()
        {
            if (Count < 2) return this;
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
            return this;
        }

        public Deck<T> Reshuffle()
        {
            this.Concat(_discardPile);
            _discardPile.Clear();
            return Shuffle();
        }
    }
}
