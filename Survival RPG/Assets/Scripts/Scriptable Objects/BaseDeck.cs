using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Deck", menuName = "Deck")]
public class BaseDeck : ScriptableObject
{
    public List<Card> cards;
}
