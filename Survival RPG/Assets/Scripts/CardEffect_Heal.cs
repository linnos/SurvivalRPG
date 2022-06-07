using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffect_Heal : MonoBehaviour, ICard
{
    public void effect(){
        Debug.Log("Healing you");
    }
}