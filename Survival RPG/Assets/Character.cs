using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private CharacterReferenceEvent onCharRefEvent = default;
    public CharacterData data;

    private void Start()
    {
        onCharRefEvent.RaiseEvent(this);
    }

    public void setSelectable(bool isSelectable){
        data.selectable = isSelectable;
        Debug.Log(data.name + " has been selected");
    }

    // Move to position based on list of coordinates given
    public void move(Vector3[] positions){
        foreach(Vector3 position in positions){
            LeanTween.move(gameObject, position, 2.0f) .setEase( LeanTweenType.easeOutQuad );
        }
    }
}
