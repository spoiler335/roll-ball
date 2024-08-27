using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUIManager : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button quitButton;


    private void Awake()
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    private void StartGame()
    {
        SceneManager.LoadScene(SceneConstants.GAME_SCENE);
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
