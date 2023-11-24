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
            // Calcula la dirección hacia el objetivo
            Vector3 direccion = objetivo.position - transform.position;

            // Normaliza la dirección para mantener una velocidad constante
            direccion.Normalize();

            // Mueve el objeto en la dirección del objetivo
            transform.Translate(direccion * velocidad * Time.deltaTime);
        }
    }
}
