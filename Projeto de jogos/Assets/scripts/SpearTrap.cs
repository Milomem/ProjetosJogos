using System.Collections;
using UnityEngine;

public class SpearTrap : MonoBehaviour
{
    [SerializeField] private float damage;

    [Header("Speartrap timers")]
    [SerializeField] private float activationDelay;
    [SerializeField] private float activationTime;

    private Animator anim;
    private AudioSource trapSound;

    private bool triggered;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        trapSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "RegionTrigger")
        {
            if (!triggered)
            {
                StartCoroutine(ActivateSpearTrap(collision));
            }
        }
    }

    private IEnumerator ActivateSpearTrap(Collider2D collision)
    {
        triggered = true;
        yield return new WaitForSeconds(activationDelay);

        anim.SetBool("active", true);
        trapSound.Play();

        PlayerHealth playerHealth = collision.GetComponentInParent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }

        yield return new WaitForSeconds(activationTime);
        anim.SetBool("active", false);
        triggered = false;
    }
}
