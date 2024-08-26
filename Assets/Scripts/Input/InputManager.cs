using UnityEngine;

public class InputManager
{
    private PlayerInput inputActions;
    public InputManager()
    {
        inputActions = new PlayerInput();
        inputActions.Enable();
    }

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
}