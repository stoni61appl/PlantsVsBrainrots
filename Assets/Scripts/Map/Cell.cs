using UnityEngine;

public class Cell : MonoBehaviour
{
    public bool occupied = false;
    public GameObject currentPlant;

    void OnMouseDown()
    {
        if (!occupied)
        {
            PlantManager.Instance.PlantHere(this);
        }
    }
}

