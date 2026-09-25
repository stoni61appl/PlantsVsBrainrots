using UnityEngine;

public class PeaAdvance : MonoBehaviour
{
    public float speed = 8f;
    public int damage = 20;
    public float lifeTime = 5f;

    private Vector2 direction = Vector2.right; // por defecto recto
    private Vector2 finalDirection = Vector2.right;

    [Header("Corrección de dirección")]
    public float straightenTime = 0.5f; // segundos hasta que se endereza
    private float timer;


    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
    }

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        // Mientras no se cumpla el tiempo, usa la dirección inicial
        if (timer < straightenTime)
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
        else
        {
            // Después del tiempo, sigue recto
            transform.Translate(finalDirection * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Zombie"))
        {
            Zombie zombie = other.GetComponent<Zombie>();
            if (zombie != null)
            {
                zombie.RecibirDanio(damage);
            }
            Destroy(gameObject);
        }
    }
}
