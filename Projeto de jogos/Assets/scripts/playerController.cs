using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Velocidade de movimento

    // Variáveis para armazenar a entrada do jogador
    private float moveX;
    private float moveY;

    // Referência ao Rigidbody2D
    private Rigidbody2D rb;

    void Start()
    {
        // Obtendo a referência ao Rigidbody2D anexado ao objeto
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Obtendo entrada do jogador
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        // Movendo o objeto com base na entrada do jogador
        Vector2 movement = new Vector2(moveX, moveY);
        rb.velocity = movement * moveSpeed;
    }
}