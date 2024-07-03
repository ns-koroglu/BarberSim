using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void SahneGecis (int scene_Id)
    { 
        SceneManager.LoadScene (scene_Id);
    }
}
