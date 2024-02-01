using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moneytextscript : MonoBehaviour
{
    public Text txt;
    // Update is called once per frame
    void Update()
    {
        txt.text = HeroScript.coinsamount.ToString();
    }
}
