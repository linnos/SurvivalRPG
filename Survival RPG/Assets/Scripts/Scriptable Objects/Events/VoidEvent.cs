using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "VoidEvent", menuName = "Events/Void Event")]
public class VoidEvent : ScriptableObject
{
    public UnityAction onVoidRequestedEvent;

    public void RaiseEvent(){
        onVoidRequestedEvent.Invoke();
    }   
}