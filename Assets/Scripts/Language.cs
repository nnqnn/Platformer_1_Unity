using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using YG;

public class Language : MonoBehaviour
{

    public string CurrentLanguage;

    public static Language Instance { get; set; }

    private void Start() {
        GetLangVoid();
    }

    public void GetLangVoid() {
        CurrentLanguage = YandexGame.EnvironmentData.language;
        Debug.Log("===================YA LANG UNITY===========");
        Debug.Log(CurrentLanguage);
    }

    private void Awake() {
        Instance = this;
        GetLangVoid();
    }
}
