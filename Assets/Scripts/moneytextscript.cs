using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class moneytextscript : MonoBehaviour
{
    public TMP_Text txt;
    // Update is called once per frame
    void Update()
    {
        if(HeroScript.coinsamount > 9) {
            txt.color = Color.green;
            txt.text = HeroScript.coinsamount.ToString();
        } else {
            txt.text = HeroScript.coinsamount.ToString() + "/10";
        }
    }
}
