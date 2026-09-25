using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject cellPrefab;   // Prefab de la celda
    public int rows = 5;            // Filas
    public int cols = 9;            // Columnas
    public float cellSize = 1.5f;   // Espaciado entre celdas

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < cols; x++)
            {
                Vector2 position = new Vector2(x * cellSize, y * cellSize);
                GameObject newCell = Instantiate(cellPrefab, position, Quaternion.identity);
                newCell.transform.parent = transform; // Para mantener orden en jerarquía
            }
        }
    }
}
