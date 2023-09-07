using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private CharacterReferenceEvent onCharRefEvent = default;
    [SerializeField]
    private TileEvent onCharSelect = default;

    [SerializeField] 
    private List<Character> characters;
    
    private void Awake()
    {
        onCharRefEvent.onCharRefEvent += AddChar;
        onCharSelect.onTileEvent += test;    
    }

    public void AddChar(Character character){
        characters.Add(character);
    }

    public void test(string name){
        Debug.Log($"Character: " + name);
    }
}
