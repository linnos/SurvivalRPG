using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "CardRequestEvent", menuName = "Events/Card Request Event")]
public class CardRequestEvent : ScriptableObject
{
    public UnityAction<string> onCardRequestedEvent;

    public void RaiseEvent(string card){
        onCardRequestedEvent.Invoke(card);
    }
}
