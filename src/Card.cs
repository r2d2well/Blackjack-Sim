﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Card
{
    public byte set;
    public string value;
    public Card(byte set, string value)
    {
        this.set = set;
        this.value = value;
    }
    //Basic card deck that stores a card's value and what set it belongs to
}
