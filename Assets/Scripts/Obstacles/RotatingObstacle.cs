using UnityEngine;

public class RotatingObstacle : MonoBehaviour
{

    private const float ROTATION_SPEED = 100;

    private void Update()
    {
        transform.Rotate(Vector3.up * ROTATION_SPEED * Time.deltaTime);
    }
}
