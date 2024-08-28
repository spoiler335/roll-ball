using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private InputManager input => DI.di.inputManager;
    private bool inputEnabled = false;
    private float moveSpeed = 20f;
    private bool hasPlayerfallen = false;
    private SoundManager soundManager => DI.di.soundManager;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        Events.GAME_STARTED += OnGameStarted;
    }

    private void UnsubscribeEvents()
    {
        Events.GAME_STARTED -= OnGameStarted;
    }

    private void OnGameStarted()
    {
        inputEnabled = true;
    }

    private void FixedUpdate()
    {
        MoveOnPlayerInput();
    }

    private void Update()
    {
        CheckIfPlayerHasFallen();
    }

    private void CheckIfPlayerHasFallen()
    {
        if (!hasPlayerfallen && transform.position.y < -10f)
        {
            Events.GAME_OVER?.Invoke(GameOver.Fall);
            hasPlayerfallen = true;
            soundManager.PlaySound(Sounds.Fall);
        }
    }

    private void MoveOnPlayerInput()
    {
        if (!inputEnabled) return;
        Vector3 movement = new Vector3(input.GetFoward(), 0f, input.GetRight());
        movement = movement.normalized;
        rb.AddForce(movement * moveSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"OnTriggerEnter :: {other.name}");
        if (other.TryGetComponent<Gem>(out var gem))
        {
            gem.GetComponent<BoxCollider>().enabled = false;
            Events.GEM_PICKED?.Invoke();
            soundManager.PlaySound(Sounds.Pickup);
            Destroy(gem.gameObject, 0.1f);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log($"OnCollisionEnter :: {other.gameObject.name}");
        if (other.gameObject.TryGetComponent<SpikeObstacle>(out var spikeObstacle))
        {
            Events.PLAYER_TOUCHED_SPIKE.Invoke();
            soundManager.PlaySound(Sounds.Spike);
        }

        if (other.gameObject.CompareTag("Rotating_Barriers"))
        {
            soundManager.PlaySound(Sounds.Wall);
        }
    }
    private void OnDestroy() => UnsubscribeEvents();
}
