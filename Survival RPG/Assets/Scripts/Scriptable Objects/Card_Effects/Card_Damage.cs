using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Damage Card", menuName = "Card/Damage")]
public class Card_Damage : Card
{
    public override void effect(GameObject parent)
    {
        //Takes the damage variable from the parent to deal damage
        Debug.Log("Hitting you for " + damage + " damage");
    }
}
