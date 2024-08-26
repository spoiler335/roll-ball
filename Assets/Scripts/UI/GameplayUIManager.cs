using System.Collections;
using TMPro;
using UnityEngine;

public class GameplayUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI beginCountDowntext;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    private int score => DI.di.gameManager.score;
    private int highScore => DI.di.progressSaver.highestScore;

    private void Awake()
    {
        SubscribeEvents();
        beginCountDowntext.gameObject.SetActive(false);
    }

    private void SubscribeEvents()
    {
        Events.START_BEGIN_COUNTDOWN += ShowBeginCountDown;
        Events.UPDATE_SCORE_UI += UpdateScoretext;
    }

    private void UnsubscribeEvents()
    {
        Events.START_BEGIN_COUNTDOWN -= ShowBeginCountDown;
        Events.UPDATE_SCORE_UI -= UpdateScoretext;
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

    private void UpdateScoretext()
    {
        scoreText.text = score.ToString();
        highScoreText.text = highScore.ToString();
    }

    private void OnDestroy() => UnsubscribeEvents();
}