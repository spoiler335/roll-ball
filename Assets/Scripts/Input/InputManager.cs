using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerInput inputActions;

    private void Awake()
    {
        inputActions = new PlayerInput();
        if (DI.di.inputManager == null)
        {
            DI.di.SetInputManager(this);
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    private void OnEnable() => inputActions.Enable();

    public float GetFoward()
    {
        return inputActions.Player.Movement.ReadValue<Vector2>().x;
    }

    public float GetRight()
    {
        return inputActions.Player.Movement.ReadValue<Vector2>().y;
    }

    public float GetRotation()
    {
        return inputActions.Player.LookRotaion.ReadValue<float>();
    }

    private void OnDisable() => inputActions.Disable();
}