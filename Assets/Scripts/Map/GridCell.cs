using UnityEngine;

// Este script va en cada celda del grid (un objeto con SpriteRenderer + BoxCollider2D)
public class GridCell : MonoBehaviour
{
    public int fila;
    public int columna;
    public bool ocupada = false;

    private GridManagerPlants gridManager;

    void Start()
    {
        gridManager = FindObjectOfType<GridManagerPlants>();
    }

    // Se llama automáticamente cuando el jugador hace clic sobre el collider de esta celda
    void OnMouseDown()
    {
        if (ocupada)
        {
            Debug.Log($"Celda ({fila},{columna}) ya está ocupada");
            return;
        }

        gridManager.ColocarPlanta(this);
    }

    public void MarcarOcupada()
    {
        ocupada = true;
    }
}
