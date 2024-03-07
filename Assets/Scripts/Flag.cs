using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{

    public GameObject gm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == HeroScript.Instance.gameObject)
        {
            Destroy(gameObject);
            Destroy(gm);
        }

    }
}
