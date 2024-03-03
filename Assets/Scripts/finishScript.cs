using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finishScript : MonoBehaviour
{
    public GameObject panel;
    public Text txt;
    public Text txt2;
    public GameObject RestForDie;

    private AudioSource finishSound;
    public static finishScript Instance { get; set; }

    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
        if(Language.Instance.CurrentLanguage == "tr") {
            txt2.text = "Seviye Geçildi!\nKazandın!";
        } else if (Language.Instance.CurrentLanguage == "ru") {
            txt2.text = "Уровень Пройден!\nТы Победил!";
        } else {
            txt2.text = "Level Completed!\nYou Win!";
        }
    }

    public void vvv(bool isLose) {
        finishSound.Play();
        GameMusicScript.Instance.isMusicPlay = false;
        panel.SetActive(true);
        RestForDie.SetActive(false);
        Time.timeScale = 0;
        txt.text = HeroScript.coinsamount.ToString();
        if (isLose)
        {
        if(Language.Instance.CurrentLanguage == "tr") {
            txt2.text = "Kaybettin!";
        } else if (Language.Instance.CurrentLanguage == "ru") {
            txt2.text = "Ты проиграл!";
        } else {
            txt2.text = "You lose!";
        }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (HeroScript.coinsamount < 9)
        {
            vvv(true);
        } else {
            vvv(false);
        }
    }
}
