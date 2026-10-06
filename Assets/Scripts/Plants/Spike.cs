using UnityEngine;

public class Spike : MonoBehaviour
{
    [Header("Atributos del proyectil")]
    public float velocidad = 5f;
    public int danio = 20;
    public int maxEnemigos = 3;
    public float tiempoVida = 5f;

    private int enemigosAtraviesados = 0;

    void Start()
    {
        // Autodestrucción por tiempo
        Destroy(gameObject, tiempoVida);
    }

    void Update()
    {
        // Movimiento constante hacia la derecha
        transform.Translate(Vector2.right * velocidad * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Zombie z = other.GetComponent<Zombie>();
        if (other.CompareTag("Zombie"))
        {
            other.SendMessage("TakeDamage", danio, SendMessageOptions.DontRequireReceiver);

            enemigosAtraviesados++;

            if (enemigosAtraviesados >= maxEnemigos)
            {
                Destroy(gameObject);
            }

        }
    }
}
