using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Velocidade de movimento
    public PlayerAnimationController playerAnim;
    // Variável para controlar a escala do objeto
    private Vector3 scale;
    private string lastMovement = "front";

    // Referência ao Rigidbody2D
    private Rigidbody2D rb;

    void Start()
    {
        // Obtendo a referência ao Rigidbody2D anexado ao objeto
        rb = GetComponent<Rigidbody2D>();
        scale = transform.localScale;
    }

    void Update()
    {
        // Inicializando variáveis de movimento
        float moveX = 0f;
        float moveY = 0f;

        // Verificando entradas de teclas
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            lastMovement = "back";
            moveY = 1f;
            Debug.Log("Movendo para cima");
            playerAnim.PlayAnimation("walk_back");
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            lastMovement = "front";
            moveY = -1f;
            Debug.Log("Movendo para baixo");
            playerAnim.PlayAnimation("walk_front");
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            lastMovement = "side";
            moveX = -1f;
            Debug.Log("Movendo para a esquerda");
            playerAnim.PlayAnimation("walk_side");

            // Virando o objeto para a esquerda
            if (transform.localScale.x > 0) // Se estiver voltado para a direita, inverter
            {
                scale.x *= -1;
                transform.localScale = scale;
            }
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            lastMovement = "side";
            moveX = 1f;
            Debug.Log("Movendo para a direita");
            playerAnim.PlayAnimation("walk_side");

            // Voltando a escala original
            if (transform.localScale.x < 0) // Se estiver invertido, voltar ao normal
            {
                scale.x *= -1;
                transform.localScale = scale;
            }
        }
        else
        {
            // Se não estiver pressionando nenhuma tecla de movimento, definir animação de idle
            moveX = 0f;
            moveY = 0f;
            if(lastMovement == "side"){
                playerAnim.PlayAnimation("idle_side");
            } else if(lastMovement == "front"){
                playerAnim.PlayAnimation("idle_front");
            } else if (lastMovement == "back"){
                playerAnim.PlayAnimation("idle_back");
            }
            
        }

        // Movendo o objeto com base na entrada do jogador
        Vector2 movement = new Vector2(moveX, moveY).normalized;
        rb.velocity = movement * moveSpeed;
    }
}