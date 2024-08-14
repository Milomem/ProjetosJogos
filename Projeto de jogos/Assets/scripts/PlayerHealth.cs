using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    private float currentHealth;

    public Transform respawnPoint;
    private Animator animator;
    private PlayerMovement playerMovement;

    private void Awake()
    {
        currentHealth = startingHealth;
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void TakeDamage(float _damage)
    {
        if (playerMovement.IsDead()) return;

        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            Debug.Log("Player hit, remaining health: " + currentHealth);
        }
        else
        {
            Debug.Log("Player dead");
            playerMovement.Die();
            animator.SetTrigger("Die");
            StartCoroutine(ResetSceneAfterDeath());
        }
    }

    private IEnumerator ResetSceneAfterDeath()
    {
        // Espera a duração da animação de morte
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length+1);
        
        // Reinicia a cena atual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
