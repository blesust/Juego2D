using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void IniciarJuego()
    {
        // Carga la escena principal del juego
        SceneManager.LoadScene("Nivel1");
    }

   
    public void CargarCreditos()
    {
       
        SceneManager.LoadScene("Credito");
    }

    public void SalirDelJuego()
    {
        Application.Quit();
        Debug.Log("Saliendo del juego...");
    }
}
