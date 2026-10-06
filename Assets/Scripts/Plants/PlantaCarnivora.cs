using UnityEngine;

public class PlantaCarnivora : MonoBehaviour
{
    [Header("Atributos")]
    public int danio = 999;           // Daño alto (mata de un bocado)
    public float rango = 1f;          // Distancia de detección
    public float tiempoRecarga = 10f; // Tiempo de espera tras comer

    private bool enRecarga = false;
    private float temporizador = 0f;

    void Update()
    {
        if (enRecarga)
        {
            temporizador -= Time.deltaTime;
            if (temporizador <= 0f)
            {
                enRecarga = false;
            }
            return;
        }

        GameObject objetivo = BuscarZombie();
        if (objetivo != null)
        {
            ComerZombie(objetivo);
        }
    }

    GameObject BuscarZombie()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, rango);
        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Zombie"))
            {
                return hit.gameObject;
            }
        }
        return null;
    }

    void ComerZombie(GameObject zombie)
    {
        zombie.SendMessage("TakeDamage", danio, SendMessageOptions.DontRequireReceiver);

        enRecarga = true;
        temporizador = tiempoRecarga;

        Debug.Log("La planta carnívora se comió un zombie!");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, rango);
    }
}