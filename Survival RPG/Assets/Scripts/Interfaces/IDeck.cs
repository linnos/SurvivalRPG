using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDeck
{
    void populateDeck(BaseDeck cards);
    void shuffle();
    Card discard(Card card);
    Card drawCard(); 
    void addCard(Card card);
}