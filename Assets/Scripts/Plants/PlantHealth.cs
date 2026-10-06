using UnityEngine;

public class PlantHealth : MonoBehaviour
{
    [Header("Vida")]
    public int vidaMaxima = 300;

    private int vidaActual;

    private void Start()
    {
        vidaActual = vidaMaxima;
    }

    public void RecibirDanio(int cantidad)
    {
        vidaActual -= cantidad;

        Debug.Log(gameObject.name + " recibió " + cantidad + " de daño. Vida: " + vidaActual);

        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    private void Morir()
    {
        Destroy(gameObject);
    }
}