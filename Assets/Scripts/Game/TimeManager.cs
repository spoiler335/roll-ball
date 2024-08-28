using System.Collections;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private const float TOTAL_GAME_TIME = 60;
    private float remainingTime = -1;


    private void Awake()
    {
        remainingTime = TOTAL_GAME_TIME;
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        Events.GAME_STARTED += StartGameTimer;
    }

    private void UnsubscribeEvents()
    {
        Events.GAME_STARTED -= StartGameTimer;
    }

    private void StartGameTimer()
    {
        StartCoroutine(CountdownTimer());
    }

    private IEnumerator CountdownTimer()
    {
        while (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            Events.UPDATE_TIME_UI?.Invoke(remainingTime);
            yield return null;
        }
        Events.GAME_OVER?.Invoke(GameOver.Timeout);
    }

    private void OnDestroy() => UnsubscribeEvents();
}
