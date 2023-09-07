using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private CharacterReferenceEvent onCharRefEvent = default;
    public CharacterData data;
    // TEST STUDD
    public GameObject[] test;
    public bool _move = false;

    private void Start()
    {
        onCharRefEvent.RaiseEvent(this);
    }

    public void SetSelectable(bool isSelectable){
        data.selectable = isSelectable;
        Debug.Log(data.name + " has been selected");
    }

    IEnumerator Movement(Vector3[] positions){
        foreach(Vector3 position in positions){
            LeanTween.move(gameObject, position, 1.0f) .setEase( LeanTweenType.easeOutQuad );
            yield return new WaitForSeconds(2);
        }
    }

    // Move to position based on list of coordinates given
    public void Move(Vector3[] positions){
        foreach(Vector3 position in positions){
            LeanTween.move(gameObject, position, 2.0f) .setEase( LeanTweenType.easeOutQuad );
        }
    }

    private void Update()
    {
        if(_move){
            _move = false;
            Vector3[] moveTo = new Vector3[test.Length];
            for(int i = 0; i < test.Length; i++){
                moveTo[i] = test[i].transform.position;
            }
            StartCoroutine(Movement(moveTo));
        }
    }
}
