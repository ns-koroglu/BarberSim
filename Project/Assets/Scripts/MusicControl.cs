using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    AudioSource muzik_kontroll;
    void Start()
    {
        muzik_kontroll = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        if (PlayerPrefs.GetInt("muzikDurum") == 1)
        {
            muzik_kontroll.mute = false;
        }
        else
        {
            muzik_kontroll.mute = true;
        }
    }
}
