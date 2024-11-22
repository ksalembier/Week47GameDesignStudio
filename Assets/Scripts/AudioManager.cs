using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource mainTheme;

    public AudioClip theme;

    // public static AudioManager instance;

    // private void Awake()
    // {
    //     if (instance == null) 
    //     {
    //         instance = this;
    //         DontDestroyOnLoad(gameObject);
    //     }
    //     else {Destroy(gameObject);}
    // }
    
    void Start()
    {
        mainTheme.clip = theme;
        mainTheme.Play();
        //36.805
    }

    void ChangeValues(float change)
    {
        mainTheme.volume = mainTheme.volume + change;
    }
}
