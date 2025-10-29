using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{
    public TMP_Text textoNumeroPuntos;
    private int puntos;

    // objetivo de puntos
    private const int PUNTOS_VICTORIA = 4; // 4 como límite

    void Start()
    {
        puntos = 0;
        
        textoNumeroPuntos.text = puntos.ToString();
    }

    public void SumaPuntos()
    {
        puntos++;
        textoNumeroPuntos.text = puntos.ToString();

        // COMPROBACIÓN DE VICTORIA
        if (puntos >= PUNTOS_VICTORIA)
        {
            CargarEscenaVictoria();
        }
    }

    // Método para cargar la escena de Victoria
    private void CargarEscenaVictoria()
    {
        
        SceneManager.LoadScene("VictoryScene");
    }
}
