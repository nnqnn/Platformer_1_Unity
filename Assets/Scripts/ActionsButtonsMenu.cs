using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using System;

public class ActionsButtonsMenu : MonoBehaviour
{
    [SerializeField] private GameObject btnStart;
    [SerializeField] private GameObject btnlvls;
    [SerializeField] private GameObject lvlsbuttons;

    public void ButtonStart(int lvl) {
        PlayerPrefs.SetInt("lvlnmb", lvl);
        PlayerPrefs.SetInt("Hard", 0);
        SceneManager.LoadScene(1);
    }

    public void ButtonLvls () {
        btnStart.SetActive(false);
        btnlvls.SetActive(false);
        lvlsbuttons.SetActive(true);
    }

    public void HardStart() {
        PlayerPrefs.SetInt("lvlnmb", 1);
        PlayerPrefs.SetInt("Hard", 1);
        SceneManager.LoadScene(1);
    }
}
