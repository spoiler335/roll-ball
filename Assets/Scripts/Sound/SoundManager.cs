using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip spikeClip;
    [SerializeField] private AudioClip wallClip;
    [SerializeField] private AudioClip pickupClip;
    [SerializeField] private AudioClip fallClip;

    [Space(10)]
    [Header("Button")]
    [SerializeField] private AudioClip buttonSoundClip;
    private AudioSource audioSource;

    private void Awake()
    {
        if (DI.di.soundManager == null)
        {
            DI.di.SetSoundManager(this);
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);

        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(Sounds soundId)
    {
        switch (soundId)
        {
            case Sounds.Spike:
                audioSource.PlayOneShot(spikeClip);
                break;
            case Sounds.Wall:
                audioSource.PlayOneShot(wallClip);
                break;
            case Sounds.Pickup:
                audioSource.PlayOneShot(pickupClip);
                break;
            case Sounds.Fall:
                audioSource.PlayOneShot(fallClip);
                break;
        }
    }

    public void PlayButtonSound()
    {
        audioSource.PlayOneShot(buttonSoundClip);
    }
}

public enum Sounds
{
    Spike,
    Wall,
    Pickup,
    Fall
}
