using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    private void Awake()
    {
        // if more than one music player, Destroy ourselves else dont destory on load

        var numMusicPlayer = FindObjectsOfType<MusicPlayer>().Length;
        if (numMusicPlayer > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
        
    }
}
