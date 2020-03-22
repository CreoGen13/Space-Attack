using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicButton : MonoBehaviour
{
    public Button button;
    public Text text;
    public void ChangeMusic()   
    {
        DataHolder.music = !DataHolder.music;
        if (DataHolder.music)
        {
            button = GetComponent<Button>();
            button.image.color = Color.white;

        }
        else
        {
            button = GetComponent<Button>();
            button.image.color = new Color32(40, 40, 40, 255);
        }
    }
}
