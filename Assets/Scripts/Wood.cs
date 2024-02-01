using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == HeroScript.Instance.gameObject)
        {
            HeroScript.Instance.iswalljump = true;
            HeroScript.Instance.GetDamage();
            HeroScript.Instance.Jump();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
