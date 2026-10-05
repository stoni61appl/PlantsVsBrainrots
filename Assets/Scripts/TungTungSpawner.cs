using UnityEngine;

public class TungTungSpawner : MonoBehaviour
{
    public GameObject tungTungPrefab;
    public Transform[] puntosSpawn;

    public float tiempoMin = 3f;
    public float tiempoMax = 7f;

    void Start()
    {
        ProgramarSpawn();
    }

    void ProgramarSpawn()
    {
        float tiempo = Random.Range(tiempoMin, tiempoMax);
        Invoke("SpawnTungTung", tiempo);
    }

    void SpawnTungTung()
    {
        int fila = Random.Range(0, puntosSpawn.Length);

        Instantiate(
            tungTungPrefab,
            puntosSpawn[fila].position,
            Quaternion.identity
        );

        ProgramarSpawn();
    }
}