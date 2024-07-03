using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicOnOff : MonoBehaviour
{
    public GameObject muzik_acik, muzik_kapali;

    void Start()
    {

    }


    void Update()
    {
        if (PlayerPrefs.GetInt("muzikDurum") == 1)
        {
            muzik_acik.SetActive(true);
            muzik_kapali.SetActive(false);
        }
        else
        {
            muzik_acik.SetActive(false);
            muzik_kapali.SetActive(true);
        }
    }
    public void muzik_durum(string durum)
    {
        if (durum == "acik")
        {
            muzik_acik.SetActive(false);
            muzik_kapali.SetActive(true);
            PlayerPrefs.SetInt("muzikDurum", 0);
        }
        else if (durum == "kapali")
        {
            muzik_acik.SetActive(true);
            muzik_kapali.SetActive(false);
            PlayerPrefs.SetInt("muzikDurum", 1);
        }
    }
}
