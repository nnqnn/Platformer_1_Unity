using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finishScript : MonoBehaviour
{
    public GameObject panel;
    public Text txt;
    public Text txt2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        panel.SetActive(true);
        Time.timeScale = 0;
        txt.text = HeroScript.coinsamount.ToString();
        if (HeroScript.coinsamount < 10)
        {
            txt2.text = "You lose!";
        }
    }
}
