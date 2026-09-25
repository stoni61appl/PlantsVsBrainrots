using UnityEngine;

/// <summary>
/// Comportamiento del guisante: se mueve en línea recta hacia la derecha,
/// hace daño al zombie que golpea y se destruye al impactar o salir de pantalla.
/// </summary>
public class Pea : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed = 8f;

    [Header("Daño")]
    public int damage = 20;

    [Header("Limpieza")]
    [Tooltip("Tiempo máximo de vida antes de autodestruirse si no golpea nada")]
    public float lifeTime = 5f;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // El collider del zombie debe tener el tag "Zombie" y un componente Zombie
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
