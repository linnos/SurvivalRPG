using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "characterRefEvent", menuName = "Events/Character Reference Event")]
public class CharacterReferenceEvent : ScriptableObject
{
    public UnityAction<Character> onCharRefEvent;

    public void RaiseEvent(Character character){
        if(onCharRefEvent != null){
            onCharRefEvent.Invoke(character);
        }
    }
}
