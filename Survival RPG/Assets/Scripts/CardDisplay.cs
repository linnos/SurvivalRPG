using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Card card;

    public Text nameText;
    public Text descriptionText;
    public Image artwork;

    public Text costText;
    public Text damageText;

    public List<Card> cardsAvailable;

    void Start()
    {
        if(card == null){
            int num = Random.Range(1, cardsAvailable.Count);
            card = cardsAvailable[num];
        }

        nameText.text = card.cardName;
        descriptionText.text = card.description;

        artwork.sprite = card.art;

        costText.text = card.cost.ToString();
        damageText.text = card.damage.ToString();
    }
}
