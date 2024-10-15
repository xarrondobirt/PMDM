using UnityEngine;

public class MovimientoPJ : MonoBehaviour
{
    // Parametros de entrada
    public Transform obj;
    public AudioClip moverClip;

    AudioSource audioSource;
    float velocidadMov = 1.0f;
    // float velocidadRotar = 90.0f;
    Vector3 posInicio;
    // Quaternion rotacionInicio;

    enum EstadoPJ
    {
        MOV_HACIA_OBJ,
        // GIRO_OBJ,
        MOV_HACIA_INICIO,
        // GIRO_INICIO
    }

    EstadoPJ estadoActual;

    // Start is called before the first frame update
    void Start()
    {
        posInicio = transform.position;
        // rotacionInicio = transform.rotation;

        // Audio mover
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = moverClip;

        estadoActual = EstadoPJ.MOV_HACIA_OBJ;
    }

    // Update is called once per frame
    void Update()
    {
        switch (estadoActual)
        {
            case EstadoPJ.MOV_HACIA_OBJ:

                transform.position = Vector3.MoveTowards(transform.position, obj.position, velocidadMov * Time.deltaTime);
                if (Vector3.Distance(transform.position, obj.position) < 3.0f)
                {
                    estadoActual = EstadoPJ.MOV_HACIA_INICIO;
                }
                break;

            /* case EstadoPJ.GIRO_OBJ:

                 transform.Rotate(Vector3.up, velocidadRotar * Time.deltaTime);

                 // Comprueba si se ha completado la rotación.
                 if (Quaternion.Angle(transform.rotation, rotacionInicio * Quaternion.Euler(0, 180, 0)) < 1.0f)
                 {
                     estadoActual = EstadoPJ.MOV_HACIA_INICIO;
                 }
                 break;*/

            case EstadoPJ.MOV_HACIA_INICIO:
                transform.position = Vector3.MoveTowards(transform.position, posInicio, velocidadMov * Time.deltaTime);

                if (Vector3.Distance(transform.position, posInicio) < 1.0f)
                {
                    estadoActual = EstadoPJ.MOV_HACIA_OBJ;
                }
                break;
                /* case EstadoPJ.GIRO_INICIO:
                     transform.Rotate(Vector3.up, velocidadRotar * Time.deltaTime);

                     // Comprueba si se ha completado la rotación.
                     if (Quaternion.Angle(transform.rotation, rotacionInicio) < 1.0f)
                     {
                         estadoActual = EstadoPJ.MOV_HACIA_OBJ;
                     }
                     break;*/
        }
    }
}
