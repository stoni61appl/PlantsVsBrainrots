using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float velocidad = 1f;
    public int vidaMaxima = 100;
    public int danio = 20;
    public float distanciaAtaque = 0.8f;

    private int vidaActual;
    private Animator animator;
    private GameObject plantaObjetivo;

    void Start()
    {
        vidaActual = vidaMaxima;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        BuscarPlanta();

        if (plantaObjetivo == null)
        {
            transform.position += Vector3.left * velocidad * Time.deltaTime;

            animator.SetBool("Walk", true);
            animator.SetBool("Attack", false);
        }
        else
        {
            animator.SetBool("Walk", false);
            animator.SetBool("Attack", true);
        }
    }

    void BuscarPlanta()
    {
        RaycastHit2D hit = Physics2D.Raycast(
            transform.position,
            Vector2.left,
            distanciaAtaque
        );

        if (hit.collider != null && hit.collider.CompareTag("Plant"))
        {
            plantaObjetivo = hit.collider.gameObject;
        }
        else
        {
            plantaObjetivo = null;
        }
    }

    public void attack()
    {
        if (plantaObjetivo != null)
        {
            plantaObjetivo.SendMessage(
                "RecibirDanio",
                danio,
                SendMessageOptions.DontRequireReceiver
            );
        }
    }

    public void TakeDamage(int cantidad)
    {
        vidaActual -= cantidad;

        if (vidaActual <= 0)
        {
            Destroy(gameObject);
        }
    }
}