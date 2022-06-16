using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : ScriptableObject
{
    public string cardName;
    public string description;
    public Sprite art;
    public int cost;

    //This variable represents damage, healing, etc... Depends on the card using it.
    public int damage;
    public virtual void effect(GameObject parent) {
        Debug.Log("Base class. Need to implement effect");
    }
}