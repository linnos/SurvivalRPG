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
    public bool addCard;
    public bool discardCard;

    public int x = 0;
    public int y = 0;

    ///TEST CARD TO ADD CARD
    public Card card;
    public string cardName;

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
        if(addCard){
            addCard = false;
            if(card != null){
                deckToDisplay.addCard(card);
                card = null;
            } 
            if(cardName != null){
                deckToDisplay.addCard(cardName);
                cardName = null;
            } 
        }
        if(discardCard){
            discardCard = false;
            //TODO: Fix this once the discard method is properly implemented
            //Fix to display the updated hand after a discard
            deckToDisplay.discard(null);
        }
    }

    private void drawCardToDisplay(){
        Card tempCard = Instantiate(deckToDisplay.drawCard());
        CardController curObject = Instantiate(prefab, new Vector3( transform.position.x + ( x++ * 2.0f * multiplicator), transform.position.y, 0), Quaternion.identity, gameObject.transform).GetComponent<CardController>();
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
