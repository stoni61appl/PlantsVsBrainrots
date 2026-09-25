//using System.Numerics;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [Header("Ataque")]
    public int danio = 10;
    public float intervaloAtaque = 1f;
    public float distanciaDeteccion = 0.6f;

    [Header("Referencia")]
    [Tooltip("Arrastra aquí el script que hace avanzar al zombie")]
    public MonoBehaviour scriptMovimiento;

    private PeaShooterAdvance plantaObjetivo;
    private float temporizador;

    [Header("Vida")]
    public int vidaMaxima = 100;
    private int vidaActual;
    void Update()
    {
        // Si no tengo objetivo (o ya murió), busco una planta enfrente
        if (plantaObjetivo == null)
        {
            plantaObjetivo = BuscarPlanta();
        }

        // Sin planta: sigo avanzando
        if (plantaObjetivo == null)
        {
            if (scriptMovimiento != null) scriptMovimiento.enabled = true;
            temporizador = 0f;
            return;
        }

        // Con planta: me detengo y muerdo cada cierto tiempo
        if (scriptMovimiento != null) scriptMovimiento.enabled = false;

        temporizador -= Time.deltaTime;
        if (temporizador <= 0f)
        {
            plantaObjetivo.RecibirDanio(danio);
            temporizador = intervaloAtaque;
        }
    }

    PeaShooterAdvance BuscarPlanta()
    {
        // El zombie avanza hacia la izquierda
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.left, distanciaDeteccion);

        foreach (RaycastHit2D hit in hits)
        {
            PeaShooterAdvance p = hit.collider.GetComponent<PeaShooterAdvance>();
            if (p != null) return p;
        }

        return null;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.left * distanciaDeteccion);
    }
    public void RecibirDanio(int cantidad)
    {
        vidaActual -= cantidad;

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


