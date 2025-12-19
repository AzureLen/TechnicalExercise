using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public static GameOverUI Instance { get; private set; }
    [SerializeField] private GameObject gameOverUIObject;
    [SerializeField] private Button playButton;

    private void Awake() {
        Instance = this;
        playButton.onClick.AddListener(() => {
            HideGameOverUI();
            CardArea.Instance.ResetGame();
        });
    }

    public void ShowGameOverUI() {
        gameOverUIObject.SetActive(true);
    }

    public void HideGameOverUI() {
        gameOverUIObject.SetActive(false);
    }
}
