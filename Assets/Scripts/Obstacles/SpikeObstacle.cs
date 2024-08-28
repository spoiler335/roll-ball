using UnityEngine;

public class SpikeObstacle : MonoBehaviour
{
    private float amplitude = 10f; // The distance the object will move
    private float frequency = 5f; // The speed of oscillation

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        float offset = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = startPosition + new Vector3(offset, 0, 0);
    }
}
