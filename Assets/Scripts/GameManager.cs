using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private GameObject firstCard;
    [SerializeField] private GameObject secondCard;

    private int matches;
    private int turns;

    private bool isFirstCardSelected = false;
    private bool isSecondCardSelected = false;

    private void Awake() {
        Instance = this;

        matches = 0;
        turns = 0;
    }

    public int GetMatches() { 
        return matches;
    }

    public int GetTurns() {
        return turns;
    }

    public bool GetIsFirstCardSelected() {
        return isFirstCardSelected;
    }

    public bool GetIsSecondCardSelected()
    {
        return isSecondCardSelected;
    }

    public void SetIsFirstCardSelected(bool selected) {
        isFirstCardSelected = selected;
    }

    public void SetIsSecondCardSelected(bool selected)
    {
        isSecondCardSelected = selected;
    }

    public void SetFirstCard(GameObject card) {
        firstCard = card;
        Debug.Log(firstCard.GetComponent<Card>().GetCardImageSprite());
    }

    public void SetSecondCard(GameObject card) {
        secondCard = card;
        Debug.Log(secondCard.GetComponent<Card>().GetCardImageSprite());
    }

    public void CheckIfCardsMatch() {
        turns++;
        if (firstCard.GetComponent<Card>().GetCardImageSprite() == secondCard.GetComponent<Card>().GetCardImageSprite())
        {
            Debug.Log("Cards Match");
            matches++;
            StartCoroutine(DelayRemoveCards());
        }
        else {
            Debug.Log("Cards Do not Match");
            StartCoroutine(DelayCloseCards());
        }

        MainGameUI.Instance.UpdateScore();

        if (matches == CardArea.Instance.GetCardSet()) {
            Debug.Log("GameOver");
            GameOverUI.Instance.ShowGameOverUI();
        }
    }

    private IEnumerator DelayRemoveCards() {
        yield return new WaitForSeconds(1f);
        firstCard.GetComponent<Image>().enabled = false;
        secondCard.GetComponent<Image>().enabled = false;
        firstCard.GetComponent<Card>().GetCardImage().SetActive(false);
        secondCard.GetComponent<Card>().GetCardImage().SetActive(false);
        isFirstCardSelected = false;
        isSecondCardSelected = false;
    }

    private IEnumerator DelayCloseCards() {
        yield return new WaitForSeconds(1f);
        firstCard.GetComponent<Card>().CloseCard();
        secondCard.GetComponent<Card>().CloseCard();
        isFirstCardSelected = false;
        isSecondCardSelected = false;
    }

    public void ResetScore() {
        matches = 0;
        turns = 0;

        MainGameUI.Instance.UpdateScore();
    }
}
