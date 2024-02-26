using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotScript : Entity
{

    private Vector3 dir;
    private SpriteRenderer sprite;
    //private float speed = 3.5f;
    private bool flip;
    public GameObject gg1;
    public GameObject gg2;


    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }


    // Start is called before the first frame update
    void Start()
    {
        dir = transform.right;
        sprite.flipX = true;
        flip = true;
    }

    private void Move()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.1f + transform.right * dir.x * 0.7f, 0.1f);

        if (colliders.Length > 0 && colliders[0].gameObject != gg1 && colliders[0].gameObject != gg2 && colliders[0].gameObject.tag != "Player")
        {
            dir *= -1f;
            flip = !flip;
            sprite.flipX = flip;
        }
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == HeroScript.Instance.gameObject)
        {
            dir *= -1f;
            flip = !flip;
            sprite.flipX = flip;
            HeroScript.Instance.GetDamage();
        }
    }
}
