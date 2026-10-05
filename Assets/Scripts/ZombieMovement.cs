using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    public float velocidad = 1f;

    void Update()
    {
        transform.Translate(Vector2.left * velocidad * Time.deltaTime);
    }
}