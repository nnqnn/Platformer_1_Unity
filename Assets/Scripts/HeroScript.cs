using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeroScript : MonoBehaviour
{
    
    [SerializeField] private float speed = 3f;
    [SerializeField] public static int lives = 5;
    [SerializeField] private float jumpForce = 8f;
    public bool isGrounded = false;
    public bool iswalljump = false;
    public static int coinsamount = 0;

    [SerializeField] private AudioSource _ascoin;

    public GameObject h1;
    public GameObject h2;
    public GameObject h3;
    public GameObject h4;
    public GameObject h5;

    public Sprite sh;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    private AudioSource audioJump;
    [SerializeField] private GameObject mcamera;

    float currentSpeed;
    bool noJumpEnemy = false;

    public int levelNumber;

    public GameObject ya;

    public static HeroScript Instance { get; set; }

    void Start()
    {
        if(default == PlayerPrefs.GetInt("lvlnmb")) {
            PlayerPrefs.SetInt("lvlnmb", 1);
            levelNumber = 1;
        } else {
            if(PlayerPrefs.GetInt("lvlnmb") == 2) {
                //PlayerPrefs.SetInt("lvlnmb", 1);
                ya.transform.position = new Vector3(56, 1.2f, 0);
                mcamera.transform.position = new Vector3(56, 1.2f, 0);
            }
        }
    }

    private void Awake()
    {   
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>();
        audioJump = GetComponent<AudioSource>();
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
    
 
    public void Jump(bool n)
    {
        audioJump.Play();
        iswalljump = false;
        if(n) {
            if(currentSpeed < 3) {
                rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            }
        }
        else {
            if(!noJumpEnemy) {
                rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            } else {
                rb.AddForce(transform.up * jumpForce / 2, ForceMode2D.Impulse);
            }
        }
    }

    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.8f);

        int j = 0;
        for (int i = 0; i < collider.Length; i++) {
            if (collider[i].gameObject.tag == "Enemy") {
                j++;
            }
        }

        if(j == 2) {
            noJumpEnemy = true;
        } else {
            noJumpEnemy = false;
        }

        if (collider[0].gameObject.tag != "Enemy")
        {
            isGrounded = collider.Length > 1;
        } else {
            //isGrounded = false;
        }

        //Debug.Log(isGrounded);
        if (collider[0].gameObject.tag == "wall"){
            iswalljump = true;
        } else {
            iswalljump = false;
        }

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
            iswalljump = true;
            Jump(true);
        }
    }

    private void FixedUpdate()
    {
        CheckGround();
        currentSpeed = rb.velocity.magnitude;
    }

    private void OnApplicationQuit() {
        Debug.Log("onApplicationQuit");
        PlayerPrefs.SetInt("lvlnmb", 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "tile")
        {
            isGrounded = true;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coin")
        {
            _ascoin.Play();
        }
    }
}
public enum States
{
    animHeroPlatformer,
    animRun,
    animJump
}