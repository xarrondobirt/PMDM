public class MovimientoPJ : MonoBehaviour
{
    // Parametros de entrada
    public Transform obj;
    public AudioClip moverClip;

    AudioSource audioSource;
    float velocidadMov = 1.0f;
    Vector3 posInicio;

    enum EstadoPJ
    {
        MOV_HACIA_OBJ,
        MOV_HACIA_INICIO
    }

    EstadoPJ estadoActual;

    // Start is called before the first frame update
    void Start()
    {
        posInicio = transform.position;

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

            case EstadoPJ.MOV_HACIA_INICIO:
                transform.position = Vector3.MoveTowards(transform.position, posInicio, velocidadMov * Time.deltaTime);

                if (Vector3.Distance(transform.position, posInicio) < 1.0f)
                {
                    estadoActual = EstadoPJ.MOV_HACIA_OBJ;
                }
                break;
        }
    }
}
