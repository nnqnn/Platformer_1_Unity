using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForLevelScript : MonoBehaviour
{
    public GameObject restartButton;
    public GameObject nextButton;

    public static TriggerForLevelScript Instance { get; set; }

    void Start() {

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject == HeroScript.Instance.gameObject) {
            HeroScript.Instance.levelNumber = 1;
            PlayerPrefs.SetInt("lvlnmb", 1);
            if(HeroScript.coinsamount < 9) {
                restartButton.SetActive(true);
                nextButton.SetActive(false);
            } else {
                restartButton.SetActive(false);
                nextButton.SetActive(true);
            }
        } else {
            HeroScript.Instance.levelNumber += 1;
            PlayerPrefs.SetInt("lvlnmb", PlayerPrefs.GetInt("lvlnmb") + 1);
            restartButton.SetActive(true);
            nextButton.SetActive(false);
        }
    }
}