using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class finishScript : MonoBehaviour
{
    public GameObject panel;
    public TMP_Text winorlosetxt;
    public TMP_Text cointxt;
    public GameObject RestForDie;

    private AudioSource finishSound;
    public static finishScript Instance { get; set; }

    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

    public void vvv(bool isLose) {
        finishSound.Play();
        GameMusicScript.Instance.isMusicPlay = false;
        panel.SetActive(true);
        RestForDie.SetActive(false);
        cointxt.text = HeroScript.coinsamount.ToString();
        if (isLose)
        {
        winorlosetxt.text = Language.Instance.CurrentLanguage switch
        {
            "tr" => "Kaybettin!",
            "ru" => "Ты проиграл!",
            _ => "You lose!",
        };
        }
        Time.timeScale = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        winorlosetxt.text = Language.Instance.CurrentLanguage switch
        {
            "tr" => "Seviye Geçildi!\nKazandın!",
            "ru" => "Уровень Пройден!\nТы Победил!",
            _ => "Level Completed!\nYou Win!",
        };
        if (HeroScript.coinsamount < 9)
        {
            vvv(true);
        } else {
            vvv(false);
        }
    }
}
