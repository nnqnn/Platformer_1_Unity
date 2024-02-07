using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finishScript : MonoBehaviour
{
    public GameObject panel;
    public Text txt;
    public Text txt2;
    private AudioSource finishSound;
    public static finishScript Instance { get; set; }

    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        finishSound.Play();
        GameMusicScript.Instance.isMusicPlay = false;
        panel.SetActive(true);
        Time.timeScale = 0;
        txt.text = HeroScript.coinsamount.ToString();
        if (HeroScript.coinsamount < 10)
        {
            txt2.text = "You lose!";
        }
    }
}
