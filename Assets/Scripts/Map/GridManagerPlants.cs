using UnityEngine;

public class GridManagerPlants : MonoBehaviour
{
    [Header("Tamaño del grid (clásico PvZ)")]
    public int filas = 5;
    public int columnas = 9;

    [Header("Tamaño y posición")]
    public float tamañoCelda = 1f;
    public Vector2 origen = new Vector2(-4f, 2f); // esquina superior-izquierda del césped

    [Header("Prefabs")]
    public GameObject prefabCelda;       // objeto vacío con SpriteRenderer (opcional) + BoxCollider2D
    public GameObject prefabLanzaGuisantes;

    private GridCell[,] celdas;

    void Start()
    {
        GenerarGrid();
    }

    void GenerarGrid()
    {
        celdas = new GridCell[filas, columnas];

        for (int f = 0; f < filas; f++)
        {
            for (int c = 0; c < columnas; c++)
            {
                Vector2 pos = origen + new Vector2(c * tamañoCelda, -f * tamañoCelda);

                GameObject celdaObj = Instantiate(prefabCelda, pos, Quaternion.identity, transform);
                celdaObj.name = $"Celda_{f}_{c}";

                GridCell celda = celdaObj.GetComponent<GridCell>();
                celda.fila = f;
                celda.columna = c;

                celdas[f, c] = celda;
            }
        }
    }

    // Llamado desde GridCell cuando el jugador hace clic en una celda libre
    public void ColocarPlanta(GridCell celda)
    {
        Vector3 posPlanta = celda.transform.position;
        Instantiate(prefabLanzaGuisantes, posPlanta, Quaternion.identity);

        celda.MarcarOcupada();
        Debug.Log($"Lanzaguisantes colocado en ({celda.fila},{celda.columna})");
    }
}
