using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMusicManager : MonoBehaviour
{
    private static MainMusicManager _instance;
    private void Awake()
    {
        CreateInstance();
    }

    private void CreateInstance()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

}
