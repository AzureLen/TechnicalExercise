using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainGameUI : MonoBehaviour
{
    public static MainGameUI Instance { get; private set; }

    [SerializeField] private GameObject mainGameUI;
    [SerializeField] private Button homeButton;

    [SerializeField] private TextMeshProUGUI matchesValueText;
    [SerializeField] private TextMeshProUGUI turnsValueText;

    private void Awake() {
        Instance = this;

        homeButton.onClick.AddListener(() =>
        {
            MainMenuUI.Instance.ShowMainMenu();
        });
    }

    public void UpdateScore() {
        matchesValueText.text = "" + GameManager.Instance.GetMatches();
        turnsValueText.text = "" + GameManager.Instance.GetTurns();
    }
}
