using UnityEngine;
using UnityEngine.UI;

public class SoudableButton : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() => DI.di.soundManager.PlayButtonSound());
    }
}
