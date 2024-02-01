using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class restartScript : MonoBehaviour
{
    public void rest()
    {
        HeroScript.coinsamount = 0;
        HeroScript.lives = 5;
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
