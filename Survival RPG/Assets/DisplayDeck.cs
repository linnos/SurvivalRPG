using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDeck : MonoBehaviour
{
    public GameObject prefab;
    
    public Deck deckToDisplay;

    public int handSize;

    public int multiplicator;

    public bool draw;
    public bool shuffleDeck;

    public int x = 0;
    public int y = 0;

    void Start()
    {
        for (int i = 0; i < handSize; i++){
            drawCardToDisplay();
        }
    }

    private void Update()
    {
        if(draw){
            draw = false;
            drawCardToDisplay();
        }
        if(shuffleDeck){
            shuffleDeck = false;
            shuffle();
        }
    }

    private void drawCardToDisplay(){
        Card tempCard = Instantiate(deckToDisplay.drawCard());
        CardDisplay curObject = Instantiate(prefab, new Vector3( transform.position.x + ( x++ * 2.0f * multiplicator), transform.position.y, 0), Quaternion.identity, gameObject.transform).GetComponent<CardDisplay>();
        curObject.SetCard(tempCard);
    }

    private void shuffle(){
        foreach (Transform child in transform){
            Destroy(child.gameObject);
        }
        x = y = 0;
        deckToDisplay.shuffle();
    }
    // public void SpawnPrefabs(){

    //     foreach (Transform child in transform)
    //     {
    //         Destroy(child.gameObject);
    //     }

    //     for(int i = 0; i < spawnNumber; i++){
    //         var curObject = Instantiate(prefab, new Vector3( transform.position.x + ( i * 2.0f * multiplicator), transform.position.y, 0), Quaternion.identity, gameObject.transform);
    //     }
    // }
}
