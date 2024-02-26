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
            restartButton.SetActive(false);
            nextButton.SetActive(true);
        } else {
            HeroScript.Instance.levelNumber = 2;
            PlayerPrefs.SetInt("lvlnmb", 2);
            restartButton.SetActive(true);
            nextButton.SetActive(false);
        }
    }
}