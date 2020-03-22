using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicGameControls : MonoBehaviour
{
    private AudioSource music;
    private bool prev = true;

    void Start()
    {
        music = GetComponent<AudioSource>();
        music.loop = true;
        if (DataHolder.music)
        {
            music.time = DataHolder.stopped;
            music.Play();
        }
    }
}
