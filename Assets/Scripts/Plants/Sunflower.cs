using UnityEngine;

public class Sunflower : MonoBehaviour
{
    [Header("Configuración")]
    public GameObject sunPrefab;
    public float sunInterval = 5f;

    [Header("Posición del Sol")]
    public Transform sunSpawnPoint;

    private void Start()
    {
        InvokeRepeating(nameof(GenerateSun), sunInterval, sunInterval);
    }

    private void GenerateSun()
    {
        if (sunPrefab == null)
        {
            Debug.LogWarning("No se asigno el Sun Prefab.");
            return;
        }

        Vector3 spawnPosition = sunSpawnPoint != null
            ? sunSpawnPoint.position
            : transform.position;

        spawnPosition.z = -1f;

        Instantiate(sunPrefab, spawnPosition, Quaternion.identity);
    }
}