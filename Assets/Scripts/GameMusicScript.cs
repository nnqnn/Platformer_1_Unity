using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusicScript : MonoBehaviour
{
    public static GameMusicScript Instance { get; set; }
    private AudioSource musicgame;
    public bool isMusicPlay = true;

    void OnApplicationFocus(bool hasFocus)
    {
        Silence(!hasFocus);
    }

    void OnApplicationPause(bool isPaused)
    {
        Silence(isPaused);
    }

    private void Silence(bool silence)
    {
        if(silence && musicgame.isPlaying) {
            musicgame.Pause();
        }

        if(!silence && !musicgame.isPlaying) {
            musicgame.Play();
        }
    }
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
