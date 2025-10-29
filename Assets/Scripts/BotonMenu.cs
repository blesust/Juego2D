using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonMenu : MonoBehaviour
{
    // Define el nombre o �ndice de la escena de destino.
    // el �ndice 0, que es la posici�n de "Menu Inicio".
    private const int INDEX_MENU_INICIO = 0;

    // Funci�n p�blica que ser� llamada por el evento On Click del bot�n
    public void VolverAlMenuInicio()
    {
        // Carga la escena del Men� Inicio usando su �ndice (0).
        SceneManager.LoadScene(INDEX_MENU_INICIO);
    }
}
