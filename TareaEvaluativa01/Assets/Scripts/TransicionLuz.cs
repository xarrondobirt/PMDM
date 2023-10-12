using UnityEngine;

public class TransicionLuz : MonoBehaviour
{
    public float velocidadRotacion = 10.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Rotar la luz direccional en torno al eje Y
        transform.Rotate(Vector3.up * velocidadRotacion * Time.deltaTime);
    }
}
