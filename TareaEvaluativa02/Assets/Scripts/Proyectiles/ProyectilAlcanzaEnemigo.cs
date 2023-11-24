using UnityEngine;

public class ProyectilAlcanzaEnemigo : MonoBehaviour
{
    public AudioSource audioExplotar;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Colisión con un enemigo.Destruye el enemigo y el proyectil.
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Enemy"))
        {
            Animator enemyAnimator = other.GetComponent<Animator>();

            if (enemyAnimator != null)
            {
                // Activa el trigger "muerto" en el Animator del enemigo
                enemyAnimator.SetTrigger("Muerto");
                audioExplotar.Play();
            }
            //  Destroy(other.gameObject);
        }
        if (other.name != "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
