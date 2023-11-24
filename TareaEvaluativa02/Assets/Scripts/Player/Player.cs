using UnityEngine;

[ExecuteInEditMode]
public class Player : MonoBehaviour
{
    public float velocidad;
    public float velocidadMax = 20f;
    public float velocidadMin = 0f;
    public GameObject disparo = null;
    Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Las llamadas est�n sicronizadas con el motor de f�sicas. Se mueve el RigidBody
    void FixedUpdate()
    {
        moverRigidBody();

    }

    // Update is called once per frame
    void Update()
    {
        // moverTransform();

        //  orientar();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            disparar();
        }
        // Aumentar velocidad, m�ximo 20
        if (Input.GetKey(KeyCode.Plus) || Input.GetKey(KeyCode.KeypadPlus))
        {
            Debug.Log("+: " + velocidad);
            velocidad += 0.1f;
            velocidad = Mathf.Min(velocidad, velocidadMax);
        }

        // Reducir velocidad, m�nimo 0
        if (Input.GetKey(KeyCode.Minus) || Input.GetKey(KeyCode.KeypadMinus))
        {
            Debug.Log("-: " + velocidad);
            velocidad -= 0.1f;
            velocidad = Mathf.Max(velocidad, velocidadMin);
        }
    }

    void disparar()
    {
        GameObject projectileGameObject = Instantiate(disparo, transform.position, transform.rotation, null);

        Rigidbody2D projectileRb = projectileGameObject.GetComponent<Rigidbody2D>();

        // Ajusta la velocidad del proyectil
        if (projectileRb != null)
        {
            float nuevaVelocidad = 10.0f;
            projectileRb.velocity = transform.up * nuevaVelocidad;
        }
    }

    /* void orientar()
     {
         // Obtener la posici�n del rat�n
         Vector3 posicionRaton = Input.mousePosition;

         // Ajustar las coordenadas del rat�n en el monitor a las de la pantalla de juego
         Vector3 posicion = Camera.main.ScreenToWorldPoint(posicionRaton);
         // Debug.Log("Posicion rat�n: " + posicionRaton);

         // Obtener la direcci�n a partir de la posici�n del objeto y la del rat�n
         Vector2 lookDirection = posicion - transform.position;       
         // Debug.Log("Posicion: " + posicion);

         // Girar el GameObject modificando su eje Up
         this.transform.up = lookDirection;
     }*/

    private void moverRigidBody()
    {
        // Leemos los valores de las teclas flecha para mover el jugador
        float entradaHorizontal = Input.GetAxis("Horizontal");
        float entradaVertical = Input.GetAxis("Vertical");

        // Movemos el RigidBody en vez del transform
        Vector2 nuevaPosition;
        nuevaPosition.x = rigidbody2d.position.x + velocidad * entradaHorizontal * Time.deltaTime;
        nuevaPosition.y = rigidbody2d.position.y + velocidad * entradaVertical * Time.deltaTime;

        rigidbody2d.MovePosition(nuevaPosition);
    }
    private void moverTransform()
    {
        // Leemos los valores de las teclas flecha para mover el jugador
        float entradaHorizontal = Input.GetAxis("Horizontal");
        float entradaVertical = Input.GetAxis("Vertical");

        if (entradaVertical != 0)
        {
            Debug.Log("Vertical: " + entradaVertical);
        }
        if (entradaHorizontal != 0)
        {
            Debug.Log("Horizontal: " + entradaHorizontal);
        }

        /* Movemos el objeto segun la velocidad configurada y las teclas pulsadas */
        transform.Translate(Vector3.up * Time.deltaTime * velocidad * entradaVertical);
        transform.Translate(Vector3.right * Time.deltaTime * velocidad * entradaHorizontal);

        /* Movemos usando position
        float x = transform.position.x;
        float y = transform.position.y;

        x = x + Time.deltaTime * velocidad * entradaHorizontal;
        y += Time.deltaTime * velocidad * entradaVertical;

        Vector3 nuevaPosicion = new Vector3(x, y, 0);

        transform.position = nuevaPosicion;
        */
    }
}
