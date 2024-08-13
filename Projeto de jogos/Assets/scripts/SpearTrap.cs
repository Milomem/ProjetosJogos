using System.Collections;
using UnityEngine;

public class SpearTrap : MonoBehaviour
{
    [SerializeField] private float damage;

    [Header("Speartrap timers")]
    [SerializeField] private float activationDelay;
    [SerializeField] private float activationTime;

    private Animator anim;
    private SpriteRenderer spriteRend;
    private AudioSource trapSound;

    private bool triggered;
    private bool active;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        trapSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.gameObject.name == "RegionTrigger")
    {
        if (!triggered)
        {
            PlayerMovement playerMovement = collision.GetComponentInParent<PlayerMovement>();
            if (playerMovement != null)
            {
                Debug.Log("Trigger Die activated");
                playerMovement.Die();
            }
            StartCoroutine(ActivateSpearTrap());
        }

        if (active)
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}


    private IEnumerator ActivateSpearTrap()
    {
        triggered = true;
        yield return new WaitForSeconds(activationDelay);
        active = true;
        anim.SetBool("active", true);
        trapSound.Play();
        yield return new WaitForSeconds(activationTime);
        active = false;
        triggered = false;
        anim.SetBool("active", false);
    }
}
