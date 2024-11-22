using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource happyMusic;
    [SerializeField] AudioSource sadMusic;

    public AudioClip happy;
    public AudioClip sad;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null) 
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {Destroy(gameObject);}
    }
    
    void Start()
    {
        happyMusic.clip = happy;
        happyMusic.Play();
        
        sadMusic.clip = sad;
        sadMusic.Play();
    }

    void ChangeValues(float happyChange, float sadChange)
    {
        happyMusic.volume = happyMusic.volume + happyChange;
        sadMusic.volume = sadMusic.volume + sadChange;
    }
}
