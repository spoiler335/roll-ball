using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score { get; private set; } = 0;
    public int lives { get; private set; } = 3;
    private int highestScore
    {
        get => DI.di.progressSaver.highestScore;
        set => DI.di.progressSaver.highestScore = value;
    }

    private void Awake()
    {
        if (DI.di.gameManager == null) DI.di.SetGameManager(this);
        else Destroy(gameObject);

        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        Events.GEM_PICKED += OnGemPicked;
        Events.GAME_OVER += OnGameOver;
    }

    public void UnsubscribeEvents()
    {
        Events.GEM_PICKED -= OnGemPicked;
        Events.GAME_OVER -= OnGameOver;
    }

    private void Start()
    {
        score = 0;
        lives = 3;
        Events.UPDATE_SCORE_UI?.Invoke();
        StartCoroutine(StartGameAfterBeginCountDown());
    }

    private IEnumerator StartGameAfterBeginCountDown()
    {
        Debug.Log($"Starting begin count down");
        Events.START_BEGIN_COUNTDOWN?.Invoke();
        yield return new WaitForSeconds(3);
        Debug.Log($"Begin count down finished");
        Events.GAME_STARTED?.Invoke();
    }

    private void OnGemPicked()
    {
        score++;
        if (score > highestScore) highestScore = score;
        Events.UPDATE_SCORE_UI?.Invoke();
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;
    }

    private void OnDestroy() => UnsubscribeEvents();
}