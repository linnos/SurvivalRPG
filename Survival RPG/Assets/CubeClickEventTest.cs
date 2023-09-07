using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeClickEventTest : MonoBehaviour
{
    [SerializeField]private VoidEvent voidEvent = default;
    public void sendEventRequest(){
        voidEvent.RaiseEvent();
    }
}
