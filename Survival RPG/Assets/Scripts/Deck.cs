using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour, IDeck
{
    public BaseDeck deck;
    private BaseDeck tempDeck;
    private int currPosition = 0;
    public int maxHandSize;
    public int maxDeckSize;

    private void Awake(){
        //Copy base deck into temp deck
        //tempDeck = Instantiate(deck);    

        //Populate temp deck using the card factory
        tempDeck = ScriptableObject.CreateInstance<BaseDeck>();
        tempDeck.cards = new List<Card>();
        foreach(Card card in deck.cards){
            tempDeck.cards.Add(CardFactory.GetCard(card.cardName));
        }
    }
    private void Start(){

    }

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
    public Card drawCard(){
        return tempDeck.cards[currPosition++];
    }

    //TODO:Improve this function to 
    //1. Discard a chosen card when draw
    //2. Discard a chosen card on command
    //For now this just removes the first card in the deck
    //Need to properly keep track of what card comes next after a discard.
    public Card discard(Card card){
        if(tempDeck.cards.Capacity == 0){
            Debug.Log("Deck is empty");
            return null;
        }
        tempDeck.cards.RemoveAt(0);
        return null;
    }
    //TODO: talk about this and perhaps change functionality depending on
    //conditions. Should this add to main deck as well?
    public void addCard(Card card){
        if(card == null){
            return;
        }
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
