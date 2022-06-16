using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Heal Card", menuName = "Card/Healing")]
public class Card_Healing : Card
{
    public override void effect(GameObject parent)
    {
        //Takes the damage variable from the parent and uses it as a heal amount
        Debug.Log("Healing you " + damage + "HP");
    }
}
