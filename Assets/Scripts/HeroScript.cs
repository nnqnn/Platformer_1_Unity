using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeroScript : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] public static int lives = 5;
    [SerializeField] private float jumpForce = 10f;
    private bool isGrounded = false;
    private bool iswalljump = false;
    public static int coinsamount = 0;

    public GameObject h1;
    public GameObject h2;
    public GameObject h3;
    public GameObject h4;
    public GameObject h5;

    public Sprite sh;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;

    public GameObject ya;

    public static HeroScript Instance { get; set; }

    void Start()
    {
        
    }

        private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }

    private void Run()
    {
        if (isGrounded) State = States.animRun;

        Vector3 dir = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);

        sprite.flipX = dir.x < 0.0f;
    }
    
 
    public void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.8f);
        isGrounded = collider.Length > 1;

        if (!isGrounded) State = States.animJump;

    }


    public void GetDamage()
    {
        lives -= 1;
        Debug.Log(lives);
        if (lives < 1)
        {
            DieHero();
        } else if (lives == 4)
        {
            h5.GetComponent<Image>().sprite = sh;
        }
        else if (lives == 3)
        {
            h4.GetComponent<Image>().sprite = sh;
        }
        else if (lives == 2)
        {
            h3.GetComponent<Image>().sprite = sh;
        }
        else if (lives == 1)
        {
            h2.GetComponent<Image>().sprite = sh;
        }
        else if (lives == 0)
        {
            h1.GetComponent<Image>().sprite = sh;
        }
    }

    public void DieHero()
    {
        lives = 5;
        coinsamount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
  
    // Update is called once per frame
    void Update()
    {
        if (isGrounded) State = States.animHeroPlatformer;

        if (Input.GetButton("Horizontal"))
            Run();
        if (!iswalljump && isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            iswalljump = true;
        }

        if (collision.gameObject.tag == "tile")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            iswalljump = false;
        }
    }
}

public enum States
{
    animHeroPlatformer,
    animRun,
    animJump
}