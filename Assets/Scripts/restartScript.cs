using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class restartScript : MonoBehaviour
{
    public static restartScript Instance { get; set; }
    private bool bnext;
    public void boolNext(int next)
    {
        if (next == 1) { 
            bnext = true;
        } else { 
            bnext = false;
        }
        if(bnext) {
            Debug.Log("bnext");
            HeroScript.Instance.levelNumber += 1;
            PlayerPrefs.SetInt("lvlnmb", PlayerPrefs.GetInt("lvlnmb") + 1);
        }
    }

    public void next() {
        HeroScript.coinsamount = 0;
        HeroScript.lives = 5;
        if(PlayerPrefs.GetInt("lvlnmb") < 3) {
            SceneManager.LoadScene(1);
        } else {
            SceneManager.LoadScene(2);
        }
        Time.timeScale = 1f;  
    }
    public void rest()
    {
        HeroScript.coinsamount = 0;
        HeroScript.lives = 5;
        if(PlayerPrefs.GetInt("lvlnmb") == finishScript.Instance.finishLevel) {
            PlayerPrefs.SetInt("lvlnmb", 1);
            SceneManager.LoadScene(0);
        } else {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        Time.timeScale = 1f;
    }
    public void DieHeroRestart() {
        HeroScript.coinsamount = 0;
        HeroScript.lives = 5;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}
