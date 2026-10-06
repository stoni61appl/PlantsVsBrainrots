
using UnityEngine;

public class ZombiePrueba : MonoBehaviour
{
    [Header("Vida")]
    public int vida = 10;

    [Header("Movimiento")]
    public float velocidad = 0.5f;

    [Header("Ataque")]
    public Transform puntoAtaque;          // hijo vacío del zombie, al frente (izquierda)
    public float radioAtaque = 0.3f;
    public string tagPlant = "Planta";
    public int damage = 20;
    public float tiempoEntreAtaques = 1f;

    private float temporizadorAtaque;
    private PlantHealth plantaObjetivo;

    void Update()
    {
        DetectarPlanta();

        if (plantaObjetivo != null)
        {
            // Atacando: se detiene
            temporizadorAtaque -= Time.deltaTime;
            if (temporizadorAtaque <= 0f)
            {
                plantaObjetivo.RecibirDanio(damage);
                temporizadorAtaque = tiempoEntreAtaques;
            }
        }
        else
        {
            // Avanza hacia la izquierda
            transform.Translate(Vector2.left * velocidad * Time.deltaTime);
        }
    }

    void DetectarPlanta()
    {
        plantaObjetivo = null;
        Collider2D[] hits = Physics2D.OverlapCircleAll(puntoAtaque.position, radioAtaque);

        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag(tagPlant))
            {
                plantaObjetivo = hit.GetComponent<PlantHealth>();
                break;
            }
        }
    }

    public void TakeDamage(int cantidad)
    {
        vida -= cantidad;
        Debug.Log("Zombie prueba recibió daño, vida: " + vida);
        if (vida <= 0) Destroy(gameObject);
    }

    // Para ver el rango en la escena
    void OnDrawGizmosSelected()
    {
        if (puntoAtaque == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(puntoAtaque.position, radioAtaque);
    }
}