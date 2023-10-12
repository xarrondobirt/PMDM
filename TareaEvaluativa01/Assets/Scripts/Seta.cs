using UnityEngine;

public class Seta : MonoBehaviour
{
    float tiempoMin = 1.0f;
    float tiempoMax = 10.0f;
    float tiempoSigAparicion;
    bool visible = false;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = false;
        tiempoSigAparicion = Random.Range(tiempoMin, tiempoMax);
    }

    // Update is called once per frame
    void Update()
    {
        tiempoSigAparicion -= Time.deltaTime;

        if (tiempoSigAparicion <= 0)
        {
            // Cambiar visibilidad
            visible = !visible;
            rend.enabled = visible;

            tiempoSigAparicion = Random.Range(tiempoMin, tiempoMax);
        }
    }
}
