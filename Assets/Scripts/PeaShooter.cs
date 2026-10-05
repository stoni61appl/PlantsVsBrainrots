using UnityEngine;

public class PeaShooter : MonoBehaviour
{
    [Header("Disparo")]
    public GameObject peaPrefab;
    public Transform firePoint;
    public float fireRate = 1.5f;

    [Header("Detección")]
    public bool requireZombieInLane = true;
    public float detectionRadius = 6f;
    public LayerMask zombieLayer;

    [Header("Vida")]
    public int vidaMaxima = 100;

    private int vidaActual;
    private float timer;

    void Start()
    {
        vidaActual = vidaMaxima;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= fireRate)
        {
            if (!requireZombieInLane || HayZombieEnfrente())
            {
                Disparar();
                timer = 0f;
            }
        }
    }

    bool HayZombieEnfrente()
    {
        Vector2 origen = firePoint != null
            ? firePoint.position
            : transform.position;

        RaycastHit2D hit = Physics2D.Raycast(
            origen,
            Vector2.right,
            detectionRadius,
            zombieLayer
        );

        return hit.collider != null;
    }

    void Disparar()
    {
        if (peaPrefab == null)
            return;

        Vector3 posicion = firePoint != null
            ? firePoint.position
            : transform.position;

        Instantiate(peaPrefab, posicion, Quaternion.identity);
    }

    public void RecibirDanio(int cantidad)
    {
        vidaActual -= cantidad;

        if (vidaActual <= 0)
        {
            Destroy(gameObject);
        }
    }
}