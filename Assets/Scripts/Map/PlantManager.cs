using UnityEngine;

public class PlantManager : MonoBehaviour
{
    public static PlantManager Instance;

    public GameObject[] plantPrefabs;

    private int selectedIndex = -1;

    void Awake()
    {
        Instance = this;
    }

    public void PlantHere(Cell cell)
    {
        if (!cell.occupied && selectedIndex >= 0)
        {
            int cost = GetPlantCost(selectedIndex);

            // Comprobar si tenemos suficientes soles
            if (!SunManager.instance.SpendSun(cost))
            {
                Debug.Log("No tienes suficientes soles para plantar esta planta.");
                return;
            }

            GameObject newPlant = Instantiate(
                plantPrefabs[selectedIndex],
                cell.transform.position,
                Quaternion.identity
            );

            newPlant.transform.parent = cell.transform;

            cell.currentPlant = newPlant;
            cell.occupied = true;
        }
    }

    public void SelectPlant(int index)
    {
        selectedIndex = index;

        Debug.Log("Planta seleccionada: " + plantPrefabs[index].name);
    }

    private int GetPlantCost(int index)
    {
        switch (index)
        {
            case 0:
                return 50;   // Girasol

            case 1:
                return 100;  // Lanzaguisantes

            case 2:
                return 150;  // Cactus

            case 3:
                return 200;  // Carnívora

            default:
                return 0;
        }
    }
}