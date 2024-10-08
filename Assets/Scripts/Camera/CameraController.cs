using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;

    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - player.position;
    }

    private void LateUpdate()
    {
        transform.position = offset + player.position;
    }
}
