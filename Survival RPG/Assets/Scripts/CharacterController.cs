using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private CharacterReferenceEvent onCharRefEvent = default;

    [SerializeField] 
    private List<Character> characters;
    
    private void Awake()
    {
        onCharRefEvent.onCharRefEvent += AddChar;    
    }

    public void AddChar(Character character){
        characters.Add(character);
    }
}
