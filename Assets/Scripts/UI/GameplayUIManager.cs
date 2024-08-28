using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI beginCountDowntext;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI livesText;

    // GameOver UI
    [Space(10)]
    [Header("Game Over UI elements")]
    [SerializeField] private TextMeshProUGUI gameOverHeadingText;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private TextMeshProUGUI gameOverScoreText;
    [SerializeField] private TextMeshProUGUI gameOverHighScoreText;

    private int score => DI.di.gameManager.score;
    private int highScore => DI.di.progressSaver.highestScore;
    private int lives => DI.di.gameManager.lives;

    private void Awake()
    {
        SubscribeEvents();
        beginCountDowntext.gameObject.SetActive(false);
        timerText.gameObject.SetActive(false);
        gameOverUI.SetActive(false);
    }

    private void SubscribeEvents()
    {
        Events.START_BEGIN_COUNTDOWN += ShowBeginCountDown;
        Events.UPDATE_SCORE_UI += UpdateScoretext;
        Events.UPDATE_TIME_UI += UpdateTimerText;
        Events.GAME_STARTED += OnGameStarted;
        Events.GAME_OVER += OnGameOver;
        Events.UPDATE_LIVES_UI += UpdateLives;

        restartButton.onClick.AddListener(RestartGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    private void UnsubscribeEvents()
    {
        Events.START_BEGIN_COUNTDOWN -= ShowBeginCountDown;
        Events.UPDATE_SCORE_UI -= UpdateScoretext;
        Events.UPDATE_TIME_UI -= UpdateTimerText;
        Events.GAME_STARTED -= OnGameStarted;
        Events.GAME_OVER -= OnGameOver;
        Events.UPDATE_LIVES_UI -= UpdateLives;
    }

    private void ShowBeginCountDown() => StartCoroutine(ShowBeginCountDownCou());

    private IEnumerator ShowBeginCountDownCou()
    {
        beginCountDowntext.gameObject.SetActive(true);
        int time = 3;
        while (time > 0)
        {
            beginCountDowntext.text = time.ToString();
            yield return new WaitForSeconds(1f);
            time--;
        }
        beginCountDowntext.text = "GO!";
        yield return new WaitForSeconds(0.5f);
        beginCountDowntext.gameObject.SetActive(false);
    }

    private void OnGameStarted()
    {
        timerText.gameObject.SetActive(true);
    }

    private void UpdateScoretext()
    {
        scoreText.text = score.ToString();
        highScoreText.text = highScore.ToString();
    }

    private void OnGameOver(GameOver gameOver)
    {
        switch (gameOver)
        {
            case GameOver.Lives:
                gameOverHeadingText.text = "Out of Lives";
                break;
            case GameOver.Timeout:
                gameOverHeadingText.text = "Out of time";
                break;
            case GameOver.Finish:
                gameOverHeadingText.text = "Target Reached";
                break;
            case GameOver.Fall:
                gameOverHeadingText.text = "Try To Stay On Track";
                break;
        }
        timerText.gameObject.SetActive(false);
        gameOverScoreText.text = $"Score: {score}";
        gameOverHighScoreText.text = $"High Score: {highScore}";
        gameOverUI.SetActive(true);
        livesText.gameObject.SetActive(false);
    }

    private void UpdateTimerText(float timeRemaining)
    {
        timerText.text = FormatTime(timeRemaining);
    }

    private string FormatTime(float totalSeconds)
    {
        int minutes = Mathf.FloorToInt(totalSeconds / 60F);
        int seconds = Mathf.FloorToInt(totalSeconds % 60F);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneConstants.GAME_SCENE);
    }

    private void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneConstants.MAIN_MENU_SCENE);
    }

    private void UpdateLives()
    {
        livesText.text = lives.ToString();
    }

    private void OnDestroy() => UnsubscribeEvents();
}

public enum GameOver
{
    Lives,
    Timeout,
    Finish,
    Fall
}