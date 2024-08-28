using System.Collections;
using UnityEngine;

public class SpikeObstacle : MonoBehaviour
{
    private float amplitude = 50f; // The distance the object will move
    private float frequency = 2f; // The speed of oscillation

    private Vector3 startPosition;

    private bool startMovment = false;

    private void Start()
    {
        startPosition = transform.position;
        StartCoroutine(WaitAndEnableMovement());
    }

    private IEnumerator WaitAndEnableMovement()
    {
        yield return new WaitForSeconds(Random.Range(0.25f, 0.5f));
        startMovment = true;
        frequency = Random.Range(1.5f, 2.5f);
    }

    private void Update() => Occilate();

    private void Occilate()
    {
        if (!startMovment) return;
        float offset = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = startPosition + new Vector3(offset, 0, 0);
    }
}
