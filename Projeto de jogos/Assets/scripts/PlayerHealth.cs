using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    private float currentHealth;

    public Transform respawnPoint; // Arraste o GameObject "RespawnPoint" aqui no Inspector.
    private Vector3 initialPosition;

    private void Awake()
    {
        initialPosition = transform.position;
        currentHealth = startingHealth;
    }

    public void Respawn()
    {
        // Reposiciona o jogador no ponto de respawn
        transform.position = respawnPoint.position;
        // Se necessário, você pode redefinir outros aspectos do jogador, como saúde, animação, etc.
    }

    public void TakeDamage(float _damage)
    {
        print("Player Hit");
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if( currentHealth > 0)
        {
            print(currentHealth);
            //player hurt
        }
         else
        {
            print("Player Dead");
            Respawn();
            //player dead
        }
    }
}
