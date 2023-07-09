using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameData : MonoBehaviour
{
    //Variable instance membuat sebuah kelas dpt dipanggil oleh kelas lainnya scr mudah
    public static GameData instance;

    public float gameTimer;
    public bool isMute;
  

    private void Awake()
    {
        if(instance != null)
            Destroy(gameObject);
        else
            instance = this;

        DontDestroyOnLoad(gameObject); // menyimpan variable walau berbeda scene
    }
}
