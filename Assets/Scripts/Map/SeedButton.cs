using UnityEngine;

public class SeedButton : MonoBehaviour
{
    public int plantIndex; 

    public void OnClick()
    {
        PlantManager.Instance.SelectPlant(plantIndex);
    }
}
