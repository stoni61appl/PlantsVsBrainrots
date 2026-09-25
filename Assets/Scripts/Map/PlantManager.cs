using UnityEngine;

public class PlantManager : MonoBehaviour
{
    public static PlantManager Instance; // Singleton para fácil acceso
    public GameObject plantPrefab;       // Prefab de la planta

    void Awake()
    {
        Instance = this;
    }

    public void PlantHere(Cell cell)
    {
        if (!cell.occupied)
        {
            GameObject newPlant = Instantiate(plantPrefab, cell.transform.position, Quaternion.identity);
            newPlant.transform.parent = cell.transform; // Se queda dentro de la celda
            cell.currentPlant = newPlant;
            cell.occupied = true;
        }
    }
}
