using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tile : MonoBehaviour
{
    [SerializeField]
    private Color baseColor, offsetColor;
    [SerializeField]
    private SpriteRenderer _renderer;
    [SerializeField]
    private GameObject highlight;

    public bool isEnabled = true;
    //Tag that is used to determine if tile is usable on spawn
    public string disableTag;

    public TileEvent tileEvent_Char = default;
    public TileEvent tileEvent_IsEnabled = default;

    public Character character;

    public void Init( bool isOffset){
        // offsetColor.a = 1;
        // baseColor.a = 1;
        if(_renderer == null){
            _renderer = GetComponent<SpriteRenderer>();
        }

        _renderer.color = isOffset ? offsetColor : baseColor;
    }

    private void OnMouseEnter()
    {
        highlight.SetActive(true);
    }

        private void OnMouseExit()
    {
        highlight.SetActive(false);
    }

    private void OnMouseDown()
    {
        if(character != null){
            tileEvent_Char.RaiseEvent(character.data.charName);
        }
        else{
            Debug.Log($"There is no character on this tile");
        }
    }

    //disables the gameobject is an object tagged environment enters it's collider
    //This may need to change because if the object is moved, it will disable
    //more tiles during combat. WARNING
    private void OnCollisionEnter(Collision col)
    {
        GameObject curCol = col.gameObject;

        //Removes tile if an environmental
        //object touched
        if(curCol.tag == disableTag){
            isEnabled = false;
            Debug.Log($"{isEnabled.ToString()} {gameObject.transform.position.x} {gameObject.transform.position.y}");
            tileEvent_IsEnabled.RaiseEvent($"{isEnabled.ToString()} {gameObject.transform.position.x} {gameObject.transform.position.y}");
            _renderer.color = new Color (0 ,0 ,0 ,0);
            gameObject.SetActive(false);
            GameObject.Destroy(gameObject);
        }

        //If a character is on the tile, set variable
        if(curCol.GetComponent<Character>() != null){
            character = curCol.GetComponent<Character>();
            isEnabled = false;
            tileEvent_IsEnabled.RaiseEvent($"{isEnabled.ToString()} {gameObject.transform.position.x} {gameObject.transform.position.y}");
        }
        
    }
    private void OnCollisionExit(Collision col)
    {
        if(character != null){
            character = null;

            isEnabled = true;
            tileEvent_IsEnabled.RaiseEvent($"{isEnabled.ToString()} {gameObject.transform.position.x} {gameObject.transform.position.y}");
        }
    }
}