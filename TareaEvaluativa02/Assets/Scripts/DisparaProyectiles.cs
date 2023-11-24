using UnityEngine;

public class DisparaProyectiles : MonoBehaviour
{
    public GameObject proyectil = null;
    //Renderer proyectilRenderer = null;
    public float tiempo = 1.0f;
    private float siguienteProyectil = 0f;
    private bool puedeDisparar = false;

    void Start()
    {

        // Sprite bala invisible
        /* proyectilRenderer = proyectil.GetComponent<Renderer>();
         if (proyectilRenderer != null)
         {
             proyectilRenderer.enabled = false;
         }
        */
        siguienteProyectil = 0f;
    }

    void Update()
    {
        siguienteProyectil += Time.deltaTime;
        if (puedeDisparar && siguienteProyectil > tiempo)
        {
            Debug.Log("choque top");
            Disparar();
            siguienteProyectil = 0f;
        }
    }

    void Disparar()
    {
        GameObject projectileGameObject = Instantiate(proyectil, transform.position, transform.rotation, null);

        // Rigidbody2D projectileRb = projectileGameObject.GetComponent<Rigidbody2D>();
        // proyectilRenderer.enabled = true;

        // Ajusta la velocidad del proyectil
        /* if (projectileRb != null)
         {
             float nuevaVelocidad = 3.0f;

             // Cambiar la velocidad a negativo para que dispare hacia abajo
             projectileRb.velocity = transform.up * -nuevaVelocidad;
         }*/
    }

    // Se verifica cuando colisiona el disparo. Cuando lo haga con el limite superior, empiezan los disparos.
    // Cuando lo hace con el inferior, se destruye
    void OnTriggerEnter2D(Collider2D other)
    {

        // Comprueba si la colisión es con el límite superior
        if (other.CompareTag("TopLimit"))
        {
            Debug.Log("comienza a disparar");
            // Activa la capacidad de disparar
            puedeDisparar = true;
        }

        // Comprueba si la colisión es con el límite superior
        /*  if (other.CompareTag("BotLimit"))
          {
              Debug.Log("destruye a disparar");
              Destroy(proyectil);
              // Activa la capacidad de disparar
              puedeDisparar = false;
          }*/
    }

}
