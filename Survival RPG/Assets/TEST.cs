using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{
    public string effect;
    public GameObject target;
    // Start is called before the first frame update
    [SerializeField]private VoidEvent voidEvent = default;
    void Start()
    {
        voidEvent.onVoidRequestedEvent += testEvent;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            AnimationFactory.GetAnimation(effect, target.transform.position);
        }

        // if (Input.GetKeyDown(KeyCode.X))
        // {
        //     sendEventRequest();
        // }
    }

    void testEvent(){
        Debug.Log("Test Event fired from TEST");
    }
    // void sendEventRequest(){
    //     voidEvent.RaiseEvent();
    // }
}
// public enum CardTemplate{
//     Purple,Green,Yellow,Red
// }
// public enum CardType{
//     Damage,
//     Healing,
//     Defense
// }