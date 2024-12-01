using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // buzzing sound effect: https://www.zapsplat.com/music/designed-long-buzzing-and-humming/

    [SerializeField] AudioSource source;
    public AudioClip menu;
    public AudioClip theme;
    public AudioClip buzzing;
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
        source.clip = menu;
        source.Play();
    }

    public void ChangeClip(int clip)
    {
        source.Stop();
        if (clip == 0)
        { source.clip = theme;}
        if (clip == 1)
        { source.clip = buzzing;}
        source.Play();
    }

    public IEnumerator FadeSoundCoroutine(float startVolume, float targetVolume, float duration)
    {
        float elapsedTime = 0;
        float elapsedPercentage = 0;

        while (elapsedPercentage < 1)
        {
            elapsedPercentage = elapsedTime / duration;
            source.volume = Mathf.Lerp(startVolume, targetVolume, elapsedPercentage);
            yield return null;
            elapsedTime += Time.deltaTime;
        }
    }

}
