using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public static MainMenuUI Instance { get; private set; }

    [SerializeField] private Button playButton;
    [SerializeField] private GameObject mainMenuUIObject;

    private void Awake() {
        Instance = this;
        playButton.onClick.AddListener(() =>
        {
            Play();
        });
    }

    public void HideMainMenu() {
        mainMenuUIObject.SetActive(false);
    }

    public void ShowMainMenu() {
        mainMenuUIObject.SetActive(true);
    }

    public void Play() {
        CardArea.Instance.ResetGame();
        GameOverUI.Instance.HideGameOverUI();
        HideMainMenu();
    }
}
