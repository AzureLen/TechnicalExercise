using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private GameObject cardBack;
    [SerializeField] private GameObject cardImage;

    private Button cardButton;

    private bool isCardSelected = false;
    private bool isFirstCard = false;
    private bool isSecondCard = false;

    private void Awake() {
        cardButton = GetComponent<Button>();

        cardButton.onClick.AddListener(() =>
        {
            if (!isCardSelected) {
                if (!GameManager.Instance.GetIsFirstCardSelected())
                {
                    OpenCard();
                    GameManager.Instance.SetIsFirstCardSelected(true);
                    GameManager.Instance.SetFirstCard(gameObject);
                }
                else if(GameManager.Instance.GetIsFirstCardSelected() && !GameManager.Instance.GetIsSecondCardSelected())
                {
                    OpenCard();
                    GameManager.Instance.SetIsSecondCardSelected(true);
                    GameManager.Instance.SetSecondCard(gameObject);
                    GameManager.Instance.CheckIfCardsMatch();
                }
            }
        });
    }

    public void OpenCard() {
        cardBack.SetActive(false);
        isCardSelected = true;
    }

    public void CloseCard() {
        cardBack.SetActive(true);
        isCardSelected = false;
    }

    public Sprite GetCardImageSprite() {
        return cardImage.GetComponent<Image>().sprite;
    }

    public void SetCardImageSprite(Sprite sprite) { 
        cardImage.GetComponent<Image>().sprite = sprite;
    }

    public GameObject GetCardImage() {
        return cardImage;
    }
}
