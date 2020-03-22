using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStartControls : MonoBehaviour
{
    private AudioSource music;
    private bool prev = true;

    void Start()
    {
        music = GetComponent<AudioSource>();
        music.loop = true;
        if(DataHolder.music)
            music.Play();
        else
            prev = false;
    }
    void Update()
    {
        if(prev&&!DataHolder.music)
        {
            DataHolder.stopped = music.time;
            music.Stop();
            prev = false;
        }
        else if(!prev&&DataHolder.music)
        {
            music.time = DataHolder.stopped;
            music.Play();
            prev = true;
        }
    }
    public void SaveMusicStopped()
    {
        DataHolder.stopped = music.time;
        music.Stop();
    }
}
