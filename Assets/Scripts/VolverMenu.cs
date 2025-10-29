using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class VolverMenu : MonoBehaviour
{
    // Define el tiempo de espera en segundos.
    public float tiempoDeEspera = 3f;


    void Start()
    {
        StartCoroutine(VolverAlMenuDespuesDeTiempo());
    }

    // La Corrutina para esperar y luego cargar la escena.
    IEnumerator VolverAlMenuDespuesDeTiempo()
    {
        // Espera los segundos especificados.
        yield return new WaitForSeconds(tiempoDeEspera);

        // Carga la escena de destino (0 para Menu Inicio).
        SceneManager.LoadScene(0);
    }
}
