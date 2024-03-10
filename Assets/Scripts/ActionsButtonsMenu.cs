using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using System;
using TMPro;
using UnityEditor.SearchService;

public class ActionsButtonsMenu : MonoBehaviour
{
    [Header("ButtonsInStart")]
    [SerializeField] private GameObject btnStart;
    [SerializeField] private TMP_Text HardButton;
    [SerializeField] private GameObject ButtonsStart;

    [Header("StartButtons")]
    [SerializeField] private GameObject StartMenu;
    [SerializeField] private TMP_Text NewGameText;
    [SerializeField] private TMP_Text ContinueText;

    void Start() {
        SetLangHard();
        PlayerPrefs.SetInt("Hard", 0);
    }
    private void SetLangHard() {
        if(Language.Instance.CurrentLanguage != null) {
            HardButton.text = Language.Instance.CurrentLanguage switch
            {
                "tr" => "Sert",
                "ru" => "Сложно",
                _ => "Hard",
            };
            NewGameText.text = Language.Instance.CurrentLanguage switch
            {
                "tr" => "Yeni Oyun",
                "ru" => "Новая Игра",
                _ => "New Game",
            };
            ContinueText.text = Language.Instance.CurrentLanguage switch
            {
                "tr" => "Devam et",
                "ru" => "Продолжить",
                _ => "Continue",
            };
        } else {
            SetLangHard();
        }
    }

    public void ActivateMenu() {
        if(PlayerPrefs.GetInt("lvlnmb") != default) {
            StartMenu.SetActive(true);
            ButtonsStart.SetActive(false);
        } else {
            PlayerPrefs.SetInt("lvlnmb", 1);
            SceneManager.LoadScene(1);
        }
    }

    public void StartGame(bool isNewGame) {
        if(isNewGame) {
            PlayerPrefs.SetInt("lvlnmb", 1);
            SceneManager.LoadScene(1);
        } else {
            int v = PlayerPrefs.GetInt("lvlnmb");
            switch(v) {
                case 1 or 2:
                    SceneManager.LoadScene(1);
                    break;
                case 3 or 4:
                    SceneManager.LoadScene(2);
                    break;
            }
        }
    }
    public void HardStart() {
        PlayerPrefs.SetInt("Hard", 1);
    }
}
