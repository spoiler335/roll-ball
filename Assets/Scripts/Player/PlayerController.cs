using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private InputManager input => DI.di.inputManager;

    private float moveSpeed = 50f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MoveOnPlayerInput();
    }

    private void MoveOnPlayerInput()
    {
        Vector3 movement = new Vector3(input.GetFoward(), 0f, input.GetRight());
        rb.AddForce(movement * moveSpeed);
    }
}
