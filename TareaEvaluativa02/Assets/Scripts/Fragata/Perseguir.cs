using UnityEngine;

public class Perseguir : MonoBehaviour
{
    public Transform objetivo;
    public float velocidad = 5f;
    private void Start()
    {

    }
    void Update()
    {
        // Verifica si hay un objetivo asignado
        if (objetivo != null)
        {
            // Calcula la direcci�n hacia el objetivo
            Vector3 direccion = objetivo.position - transform.position;

            // Normaliza la direcci�n para mantener una velocidad constante
            direccion.Normalize();

            // Mueve el objeto en la direcci�n del objetivo
            transform.Translate(direccion * velocidad * Time.deltaTime);
        }
    }
}
