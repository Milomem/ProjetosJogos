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
        if (collision.tag == "Player")
        {
            PlayerMovement playerMovement = collision.GetComponentInParent<PlayerMovement>();
            if (playerMovement != null && !playerMovement.IsDead())
            {
                Debug.Log("Projectile hit player - trigger Die");
                playerMovement.Die();

                // Move the projectile far back on the Z axis
                transform.position = new Vector3(transform.position.x, transform.position.y, -100f);

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
    }

    private IEnumerator PlayHitSoundAndDestroy()
    {
        hitSound.Play();
        yield return new WaitForSeconds(hitSound.clip.length);
        Destroy(gameObject);
    }
}
