using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDeck
{
    void populateDeck(List<ICard> cards);
    void shuffle();
    ICard discard(ICard card);
    ICard drawCard(); 
}