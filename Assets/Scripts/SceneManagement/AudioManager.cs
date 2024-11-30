using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource backgroundMusic;
    public AudioClip background;
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
        backgroundMusic.clip = background;
        backgroundMusic.Play();
    }

    public IEnumerator FadeSoundOutCoroutine(float duration)
    {
        Debug.Log("in the fade out method");
        float startVolume = 1.0f;
        float targetVolume = 0.01f;
        yield return FadeSoundCoroutine(startVolume, targetVolume, duration);
    }

    private IEnumerator FadeSoundCoroutine(float startVolume, float targetVolume, float duration)
    {
        float elapsedTime = 0;
        float elapsedPercentage = 0;

        while (elapsedPercentage < 1)
        {
            elapsedPercentage = elapsedTime / duration;
            backgroundMusic.volume = Mathf.Lerp(startVolume, targetVolume, elapsedPercentage);
            yield return null;
            elapsedTime += Time.deltaTime;
        }
    }
}
