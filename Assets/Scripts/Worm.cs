using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : Entity
{
    [SerializeField] private int lives = 1;
    public GameObject object1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == HeroScript.Instance.gameObject)
        {
            HeroScript.Instance.iswalljump = true;
            Instantiate(object1, transform.position, Quaternion.identity);
            HeroScript.Instance.GetDamage();
            lives--;
            Debug.Log("у червяка " + lives);
            if (!HeroScript.Instance.isGrounded)
            {
                HeroScript.Instance.Jump();
            }
        }

        if (lives < 1)
            Die();
        }
}
