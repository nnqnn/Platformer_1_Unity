using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class coinscript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == HeroScript.Instance.gameObject)
        {
            HeroScript.coinsamount += 1;
            Destroy(gameObject);
            Debug.Log(HeroScript.coinsamount.ToString());
        }
    }
}