using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tr2scr : MonoBehaviour
{
    public GameObject h1;
    public GameObject h2;
    public GameObject h3;
    public GameObject h4;
    public GameObject h5;
    public GameObject h6;
    public GameObject h7;
    public GameObject h8;
    public GameObject h9;
    public GameObject h10;
    public GameObject h11;
    public GameObject h12;
    public GameObject h13;
    public GameObject h14;
    public GameObject h15;
    public GameObject h16;
    public GameObject h17;
    public GameObject h18;
    public GameObject h19;
    public GameObject h20;
    public GameObject h21;
    public GameObject h22;
    public GameObject h23;
    public GameObject h24;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == HeroScript.Instance.gameObject)
        {
            Destroy(h1);
            Destroy(h2);
            Destroy(h3);
            Destroy(h4);
            Destroy(h5);
            Destroy(h6);
            Destroy(h7);
            Destroy(h8);
            Destroy(h9);
            Destroy(h10);
            Destroy(h11);
            Destroy(h12);
            Destroy(h13);
            Destroy(h14);
            Destroy(h15);
            Destroy(h16);
            Destroy(h17);
            Destroy(h18);
            Destroy(h19);
            Destroy(h20);
            Destroy(h21);
            Destroy(h22);
            Destroy(h23);
            Destroy(h24);
        }
    }
}