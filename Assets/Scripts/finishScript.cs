using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class finishScript : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TMP_Text winOrLoseTxt;
    [SerializeField] private TMP_Text cointxt;
    [SerializeField] private GameObject RestForDie;

    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject nextButton;

    public int finishLevel = 4;

    private AudioSource finishSound;
    public static finishScript Instance { get; set; }

    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

    void Awake() {
        Instance = this;
    }

    public void vvv(bool isLose) {
        if(PlayerPrefs.GetInt("lvlnmb") == finishLevel) {
            restartButton.SetActive(true);
            nextButton.SetActive(false);
        }
        finishSound.Play();
        GameMusicScript.Instance.isMusicPlay = false;
        panel.SetActive(true);
        RestForDie.SetActive(false);
        cointxt.text = HeroScript.coinsamount.ToString();
        if (isLose) {
            winOrLoseTxt.text = Language.Instance.CurrentLanguage switch
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
        winOrLoseTxt.text = Language.Instance.CurrentLanguage switch
        {
            "tr" => "Seviye Geçildi!\nKazandın!",
            "ru" => "Уровень Пройден!\nТы Победил!",
            _ => "Level Completed!\nYou Win!",
        };
        if (HeroScript.coinsamount < 9)
        {
            restartButton.SetActive(true);
            nextButton.SetActive(false);

            vvv(true);
        } else {
            restartButton.SetActive(false);
            nextButton.SetActive(true);

            vvv(false);
        }
    }
}
