﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Cards
{
    public interface ICardParser<TCard>
        where TCard : CardBase
    {
        TCard Parse(string card);
    }
}
