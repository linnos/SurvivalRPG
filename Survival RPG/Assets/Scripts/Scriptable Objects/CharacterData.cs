using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "Characters/New Character Data")]
public class CharacterData : ScriptableObject
{
    public string charName;
    public bool selectable = true;

    //stats
    public int hp;
    public int sanity;
    public int handSize;
    //Might need to remove this one
    public int manaSize;
    
    public int movement;
}
