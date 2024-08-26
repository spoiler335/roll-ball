using UnityEngine;

public class ProgressSaver
{
    public int highestScore
    {
        get => PlayerPrefs.GetInt(PPF_Strings.HIGHEST_SCORE, 0);
        set => PlayerPrefs.SetInt(PPF_Strings.HIGHEST_SCORE, value);
    }
}

public static class PPF_Strings
{
    public const string HIGHEST_SCORE = "HighestScore";
}
