using System.Collections;
using UnityEngine;

public class projectileScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float lifeTime = 5f;
    private float timeAlive = 0f;
    [SerializeField] private float damage;
    private AudioSource hitSound;

    private void Start()
    {
        hitSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        transform.position -= transform.up * moveSpeed * Time.deltaTime;
        timeAlive += Time.deltaTime;

        if (timeAlive >= lifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se o objeto colidido tem o componente PlayerHealth
        PlayerHealth playerHealth = collision.GetComponentInParent<PlayerHealth>();

        if (playerHealth != null)
        {
            Debug.Log("Projectile hit player - applying damage");

            // Aplica dano ao jogador
            playerHealth.TakeDamage(damage);

            // Move a flecha para longe da cena (para fora do viewport)
            transform.position = new Vector3(transform.position.x, transform.position.y, -100f);

            // Reproduz o som do impacto e destrói a flecha
            if (hitSound != null)
            {
                StartCoroutine(PlayHitSoundAndDestroy());
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    private IEnumerator PlayHitSoundAndDestroy()
    {
        hitSound.Play();
        yield return new WaitForSeconds(hitSound.clip.length);
        Destroy(gameObject);
    }
}
