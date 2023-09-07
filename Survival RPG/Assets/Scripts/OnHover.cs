using UnityEngine;
using UnityEngine.EventSystems;

public class OnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Vector3 ogScale;
    int id;

    public void Start() {
        transform.localScale = ogScale;
    }
    //Detect if the Cursor starts to pass over the GameObject
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        //Output to console the GameObject's name and the following message
        Debug.Log("Cursor Entering " + name + " GameObject");
        id = LeanTween.scale(transform.gameObject, new Vector3(1.5f,1.5f,1.5f), 0.5f).setLoopPingPong().id;
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        //Output the following message with the GameObject's name
        Debug.Log("Cursor Exiting " + name + " GameObject");
        LeanTween.cancel(id);
        LeanTween.scale(transform.gameObject, ogScale, 0.5f).setEaseInElastic();
    }
}
