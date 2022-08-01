using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "TileEvent", menuName = "Events/Tile Event")]
public class TileEvent : ScriptableObject
{
    public UnityAction<string> onTileEvent;

    public void RaiseEvent(string tileInfo){
        if(onTileEvent != null){
            onTileEvent.Invoke(tileInfo);
        }
    }
}