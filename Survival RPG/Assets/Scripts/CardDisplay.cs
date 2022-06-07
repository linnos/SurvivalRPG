using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GenericReferences))]
public class CardDisplay : MonoBehaviour
{
    public Card card;

    public Text nameText;
    public Text descriptionText;
    public Image artwork;

    public Text costText;
    public Text damageText;

    public GenericReferences references;

    void Start() {
    }
    public void SetCard(Card inCard){
        card = inCard;
        Display();
    }

    public void Display(){
        nameText.text = card.cardName;
        descriptionText.text = card.description;

        artwork.sprite = card.art;

        costText.text = card.cost.ToString();
        damageText.text = card.damage.ToString();
    }
}
