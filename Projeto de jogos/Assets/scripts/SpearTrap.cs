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

    private bool triggered;
    private bool active;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if(!triggered)
                StartCoroutine(ActivateSpearTrap());
         
            if (active)
                collision.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }

    private IEnumerator ActivateSpearTrap()
    {
        triggered = true;
        yield return new WaitForSeconds(activationDelay);
        active = true;
        anim.SetBool("active", true);
        yield return new WaitForSeconds(activationTime);
        active = false;
        triggered = false;
        anim.SetBool("active", false);
    }
}
