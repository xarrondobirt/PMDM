using UnityEngine;

public class Colision : MonoBehaviour
{
    private Animator animator;
    public AudioSource audioEnergia;
    public AudioSource audioExplotar;

    void Start()
    {
        // Obtén el Animator de la nave
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Enemigo choca contra player
        if (other.CompareTag("Player"))
        {
            // Activa la animación de destrucción
            audioExplotar.Play();
            animator.SetTrigger("Muerto");
        }

        // Player choca contra enemigo
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Se ha producido un trigger con " + other.gameObject);

            Vidas controller = this.GetComponent<Vidas>();

            if (controller != null)
            {
                controller.changeVidas(-1);
                int vidas = controller.getVidas();
                Debug.Log(vidas);

            }
        }

        // Player recoge energia
        if (other.CompareTag("Energia"))
        {
            Debug.Log("Se ha producido un trigger con " + other.gameObject);

            Vidas controller = this.GetComponent<Vidas>();

            if (controller != null)
            {
                controller.changeVidas(+1);
                int vidas = controller.getVidas();
                Debug.Log(vidas);
                Destroy(other.gameObject);
                audioEnergia.Play();

            }
        }
    }
}
