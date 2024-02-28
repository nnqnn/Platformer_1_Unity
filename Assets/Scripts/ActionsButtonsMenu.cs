using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using JetBrains.Annotations;

public class ActionsButtonsMenu : MonoBehaviour
{
    [SerializeField] private GameObject btnStart;
    [SerializeField] private GameObject btnlvls;
    [SerializeField] private GameObject lvlsbuttons;

    public void ButtonStart(int lvl) {
        PlayerPrefs.SetInt("lvlnmb", lvl);
        SceneManager.LoadScene(1);
    }

    public void ButtonLvls () {
        btnStart.SetActive(false);
        btnlvls.SetActive(false);
        lvlsbuttons.SetActive(true);
    }
}
