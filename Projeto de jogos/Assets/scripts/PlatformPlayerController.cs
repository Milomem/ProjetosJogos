using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlatformPlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jumpHeight;
    public float velocity;

    bool grounded = false;
    public GameObject groundCheck;
    public LayerMask layerMask;

    public Animator animator;

    public GameControllerScript gameController;

    public AudioSource jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControllerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //rb.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb.velocity = new Vector2(Input.GetAxis("Horizontal")*velocity, rb.velocity.y);

        animator.SetFloat("vel", Mathf.Abs(Input.GetAxis("Horizontal")));

        if (Input.GetAxis("Horizontal") < 0) {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * -1, transform.localScale.y, transform.localScale.z);
        } else if (Input.GetAxis("Horizontal") > 0) {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        
        /*Pulo JETPACK
         * if (Input.GetAxis("Jump") > 0) {
            rb.AddForce(new Vector2(0, jumpHeight));
        }*/

        /*bool grounded = false;
        public GameObject groundCheck;
        public LayerMask layerMask;*/

        grounded = Physics2D.Linecast(transform.position, 
            groundCheck.transform.position, layerMask);

        if (Input.GetAxis("Jump") > 0 && grounded) {
            rb.AddForce(new Vector2(0, jumpHeight));
            jumpSound.Play();
        }

        /*if (Input.GetKeyDown(KeyCode.R)) {

        }*/
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        //Application.LoadLevel(0);
        if (collision.gameObject.name.Equals("LeftBorder")) {
            gameController.levelSucceeded();
        }

        if (collision.gameObject.name.Equals("BottomBorder")) {
            gameController.restartLevel();
        }
    }
}
