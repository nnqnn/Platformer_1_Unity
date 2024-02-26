using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class restartScript : MonoBehaviour
{
    public static restartScript Instance { get; set; }
    public bool bnext;
    public void boolNext(int next)
    {
        if (next == 1) { 
            bnext = true;
        } else { 
            bnext = false;
        }
        if(bnext) {
            Debug.Log("bnext");
            HeroScript.Instance = new HeroScript
            {
                levelNumber = 2
            };
            PlayerPrefs.SetInt("lvlnmb", 2);
        }
    }

    public void next() {
        Debug.Log("rest2");
        HeroScript.coinsamount = 0;
        HeroScript.lives = 5;
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;  
    }
    public void rest()
    {
        Debug.Log("rest1");
        HeroScript.coinsamount = 0;
        HeroScript.lives = 5;
        PlayerPrefs.SetInt("lvlnmb", 1);
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }
}
