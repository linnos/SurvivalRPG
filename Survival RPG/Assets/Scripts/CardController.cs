using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardController : MonoBehaviour, IPointerClickHandler
{
    public Card card;

    public Text nameText;
    public Text descriptionText;
    public Text costText;
    public Text damageText;

    [Header("Card Images")]
    public Image cardImage;
    public Image cardTemplate;
    public Image cardDamageIcon;
    public Image cardDamageTemplate;

    

    void Start() {
    }
    public void SetCard(Card inCard){
        card = inCard;
        Display();
    }

    public void Display(){
        nameText.text = card.cardName;
        descriptionText.text = card.description;

        cardImage.sprite = card.cardImage.art;
        cardTemplate.sprite = card.cardTemplate.art;
        cardDamageIcon.sprite = card.damageIcon.art;
        cardDamageTemplate.sprite = card.damageTemplate.art;


        costText.text = card.cost.ToString();
        damageText.text = card.damage.ToString();
    }
    
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        card.effect(gameObject);
    }
}
