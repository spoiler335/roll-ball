using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private InputManager input => DI.di.inputManager;
    private bool inputEnabled = false;
    private float moveSpeed = 50f;
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

    private void MoveOnPlayerInput()
    {
        if (!inputEnabled) return;
        Vector3 movement = new Vector3(input.GetFoward(), 0f, input.GetRight());
        rb.AddForce(movement * moveSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        Gem gem;
        if (other.TryGetComponent<Gem>(out gem))
        {
            gem.GetComponent<BoxCollider>().enabled = false;
            Events.GEM_PICKED?.Invoke();
            Destroy(gem.gameObject, 0.1f);
        }
    }
    private void OnDestroy() => UnsubscribeEvents();
}
