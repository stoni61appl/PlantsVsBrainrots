using UnityEngine;

/// <summary>
/// Lanzaguisantes estilo Plants vs Zombies.
/// Dispara un guisante cada cierto intervalo mientras haya un zombie
/// en su carril (opcional) o simplemente de forma continua.
/// </summary>
public class PeaShooter : MonoBehaviour
{
    [Header("Configuración de disparo")]
    [Tooltip("Prefab del guisante que se va a instanciar")]
    public GameObject peaPrefab;

    [Tooltip("Punto desde donde sale el guisante (hijo vacío delante de la planta)")]
    public Transform firePoint;

    [Tooltip("Tiempo entre disparos, en segundos")]
    public float fireRate = 1.5f;

    [Header("Detección de zombies (opcional)")]
    [Tooltip("Si está activo, solo dispara cuando hay un zombie en el carril")]
    public bool requireZombieInLane = true;

    [Tooltip("Radio del área que revisa si hay zombies enfrente")]
    public float detectionRadius = 6f;

    [Tooltip("Capa donde están los zombies")]
    public LayerMask zombieLayer;

    private float timer;

    private void Update()
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

    private bool HayZombieEnfrente()
    {
        // Revisa en un radio hacia la derecha si hay algún zombie
        Vector2 origen = firePoint != null ? firePoint.position : transform.position;
        RaycastHit2D hit = Physics2D.Raycast(origen, Vector2.right, detectionRadius, zombieLayer);
        return hit.collider != null;
    }

    private void Disparar()
    {
        if (peaPrefab == null)
        {
            Debug.LogWarning("PeaShooter: falta asignar el prefab del guisante.");
            return;
        }

        Vector3 spawnPos = firePoint != null ? firePoint.position : transform.position;
        Instantiate(peaPrefab, spawnPos, Quaternion.identity);
    }

    // Dibuja el radio de detección en el editor para ajustarlo fácil
    private void OnDrawGizmosSelected()
    {
        Vector2 origen = firePoint != null ? firePoint.position : transform.position;
        Gizmos.color = Color.green;
        Gizmos.DrawLine(origen, origen + Vector2.right * detectionRadius);
    }
}
