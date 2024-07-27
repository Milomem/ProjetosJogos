using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileScript : MonoBehaviour
{
    public float moveSpeed = 5f;

    public float lifeTime = 5f;

    private float timeAlive = 0f;

    [SerializeField] private float damage;
    private bool active;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
            collision.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}
