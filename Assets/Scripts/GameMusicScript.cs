using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusicScript : MonoBehaviour
{
    public static GameMusicScript Instance { get; set; }
    private AudioSource musicgame;
    public bool isMusicPlay = true;

    void Start()
    {
        Instance = this;
        musicgame = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!isMusicPlay)
        {
            musicgame.Stop();
        }
    }
}
