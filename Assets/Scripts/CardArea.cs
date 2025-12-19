
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardArea : MonoBehaviour
{
    public static CardArea Instance { get; private set; }
    //private static int levelNumber = 1;

    [SerializeField] private Card card;
    [SerializeField] private int cardSet;
    [SerializeField] private List<Card> cardList;
    [SerializeField] private Sprite[] sprites;


    private Transform cardAreaTransform;
    private GridLayoutGroup cardAreaGridLayoutGroup;

    private void Awake() {
        Instance = this;
        cardAreaTransform = GetComponent<Transform>();
        cardAreaGridLayoutGroup = GetComponent<GridLayoutGroup>();

        sprites = Resources.LoadAll<Sprite>("Sprites/FrontCardSprites");
    }

    public void SetCards() {
        int numberOfCards = cardSet * 2;
        int value = 0;
        cardList = new List<Card>();

        for (int i = 0; i < numberOfCards; i++)
        {
            GameObject cardObject = Instantiate(card.gameObject);
            
            if (i < cardSet) {
                value = i + 1;
            }
            else
            {
                value = (i - cardSet) + 1;
            }

            cardObject.name = "card" + value;
            cardObject.GetComponent<Card>().SetCardImageSprite(sprites[value]);
            cardList.Add(cardObject.GetComponent<Card>());
            cardObject.transform.SetParent(cardAreaTransform,false);
        }

        cardAreaGridLayoutGroup.constraintCount = cardSet;
    }

    public int GetCardSet() { 
        return cardSet;
    }

    public void ResetGame() {
        SetCards();
        GameManager.Instance.ResetScore();
    }
}
