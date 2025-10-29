using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private float movimientoX;
    public float velocidad = 2;
    private Rigidbody2D rb2d;
    private Animator animator;

    public float fuerzaSalto = 2;

    private bool estaEnSuelo;
    public LayerMask layerSuelo;
    private float radioEsferaTocaSuelo = 0.1f;
    public Transform compruebaSuelo;
    private GameManager gameManager;

    public AudioSource audioSource;
    public AudioClip getRecolectar;
    public AudioClip sonidoMuerto;
 
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        gameManager = FindFirstObjectByType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("No se encontró un GameManager en la escena.");
        }
    }

   
    private void Update()
    {
        rb2d.linearVelocity = new Vector2(movimientoX * velocidad, rb2d.linearVelocity.y);
        if (movimientoX == 0)
        {
            animator.SetBool("estaCorriendo", false);
        }
    }

    private void FixedUpdate()
    {
        bool estabaEnSueloAntes = estaEnSuelo;

        
        estaEnSuelo = Physics2D.OverlapCircle(compruebaSuelo.position, radioEsferaTocaSuelo, layerSuelo);

        // Si estaba en el aire y ahora está en el suelo, desactiva la animación de salto.
        if (!estabaEnSueloAntes && estaEnSuelo)
        {
            animator.SetBool("estaSaltando", false);
        }
    }

    private void OnMove(InputValue inputMovimiento)
    {
        movimientoX = inputMovimiento.Get<Vector2>().x;
        animator.SetBool("estaCorriendo", true);
        if(movimientoX != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(movimientoX) * 0.5f, 0.5f, 0.5f);
        }
    }

    private void OnJump(InputValue inputJump)
    {
        rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, fuerzaSalto);

        animator.SetBool("estaSaltando", true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Recolectar"))
        {
            audioSource.PlayOneShot(getRecolectar);
            if (gameManager != null)
            {
                gameManager.SumaPuntos(); // Llama al método para sumar 1 punto
            }
            Destroy(collision.gameObject);
        }

        if (collision.transform.CompareTag("Enemigo")) 
        {
            
            audioSource.PlayOneShot(sonidoMuerto);

         
            SceneManager.LoadScene("Nivel1");
        }
    }

}
