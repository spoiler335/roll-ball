using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;

    private Vector3 offset;
    private InputManager input => DI.di.inputManager;
    private float mouseSensitivity = 5.0f;

    private void Start()
    {
        offset = transform.position - player.position;
    }

    private void LateUpdate()
    {
        transform.position = offset + player.position;
    }
}
