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
}