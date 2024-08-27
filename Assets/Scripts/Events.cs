using UnityEngine.Events;

public class Events
{
    public static UnityAction GAME_STARTED;
    public static UnityAction GAME_OVER;
    public static UnityAction START_BEGIN_COUNTDOWN;
    public static UnityAction GEM_PICKED;
    public static UnityAction SPIKE_ENCOUNTERD;
    public static UnityAction UPDATE_SCORE_UI;
    public static UnityAction<float> UPDATE_TIME_UI;
}
