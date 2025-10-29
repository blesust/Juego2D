using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonMenu : MonoBehaviour
{
    // Define el nombre o índice de la escena de destino.
    // el índice 0, que es la posición de "Menu Inicio".
    private const int INDEX_MENU_INICIO = 0;

    // Función pública que será llamada por el evento On Click del botón
    public void VolverAlMenuInicio()
    {
        // Carga la escena del Menú Inicio usando su índice (0).
        SceneManager.LoadScene(INDEX_MENU_INICIO);
    }
}
