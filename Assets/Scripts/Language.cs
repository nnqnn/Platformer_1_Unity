using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Language : MonoBehaviour
{
    [DllImport("_Internal")]
    private static extern string GetLang();

    public string CurrentLanguage;

    public static Language Instance;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            CurrentLanguage = GetLang();
        } else {
            Destroy(gameObject);
        }
    }
}
