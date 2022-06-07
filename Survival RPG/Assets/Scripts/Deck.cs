using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck :MonoBehaviour, IDeck
{
    public BaseDeck deck;
    private BaseDeck tempDeck;
    private int currPosition = 0;
    public int maxSize;

    private void Awake(){
        tempDeck = Instantiate(deck);    
    }
    private void Start(){

    }

    // TODO: MAKE THE CARD CLASS FIRST!
    public void populateDeck(BaseDeck cards){
        deck = cards;
     }
    public void shuffle(){
        //Reset current position in deck
        currPosition = 0;

        for(int i = tempDeck.cards.Count - 1; i > -1; i--){
            int j = Random.Range(0, i);

            Card tmpCard = tempDeck.cards[j];
            tempDeck.cards[j] = tempDeck.cards[i];
            tempDeck.cards[i] = tmpCard;
        }
    }
    public Card discard(Card card){
        return null;
    }
    public Card drawCard(){
        return tempDeck.cards[currPosition++];
    } 
    public void addCard(Card card){
        tempDeck.cards.Add(card);
    }
    public BaseDeck getTempDeck(){
        return tempDeck;
    }

    // /////////////////////////TEST HELPER FUNCTIONS

    public void displayTempDeck(){
        foreach (var card in tempDeck.cards)
        {
            Debug.Log(card.cardName);
        }
    }

    private void Update()
    {
        //Just to shuffle deck for testing
        if (Input.GetKeyDown(KeyCode.A)){
            shuffle();
            displayTempDeck();
        }
    }
}
