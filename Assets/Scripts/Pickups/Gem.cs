using UnityEngine;

public class Gem : MonoBehaviour
{

    private void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
