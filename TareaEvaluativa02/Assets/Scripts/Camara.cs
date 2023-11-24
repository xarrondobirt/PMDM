using UnityEngine;

public class Camara : MonoBehaviour
{
    [Tooltip("GameObject al que debe seguir la cámara")]
    public Transform objetivo = null;
    public Transform inicio = null;
    public float vel;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Mueve la cámara hacia arriba a una velocidad constante
        transform.Translate(Vector3.up * vel * Time.deltaTime);

        // Si hay un objetivo, sigue al objetivo
        if (objetivo != null)
        {
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, objetivo.position.y, Time.deltaTime * vel), transform.position.z);
        }
    }
}
