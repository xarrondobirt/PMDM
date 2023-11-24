using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject paredIzquierda;
    public GameObject paredDerecha;
    public float velocidad = 5.0f;

    private int direccion = 1;  // 1 para derecha, -1 para izquierda

    void Update()
    {
        // Mueve el objeto horizontalmente
        transform.Translate(Vector3.right * direccion * velocidad * Time.deltaTime);
    }

    // Se llama cuando el objeto entra en un collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == paredDerecha || collision.gameObject == paredIzquierda)
        {
            Debug.Log("añdsiofjasodfijaodsfjoadsjfdoafdjsoajfa");
            // Cambia la dirección al chocar con una pared
            direccion *= -1;
        }
    }
}
