using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneController : MonoBehaviour
{

    [SerializeField]
    private float sceneFadeDuration;
    private SceneFade sceneFade;
    private AudioManager[] audioFade;

    private void Awake()
    {
        sceneFade = GetComponentInChildren<SceneFade>();
        audioFade = Object.FindObjectsOfType<AudioManager>();
    }

    private IEnumerator Start()
    {
        // changing audio clip
        audioFade[0].ChangeClip(1);
        // fading buzzing from 0 to .1
        yield return audioFade[0].FadeSoundCoroutine(0.01f, 0.2f, 2);
        // fading scene in 
        yield return sceneFade.FadeInCoroutine(sceneFadeDuration);
        // fading buzzing from .1 to .2
        // holding on cut scene image
        yield return new WaitForSeconds(sceneFadeDuration);
        // fading scene out
        yield return sceneFade.FadeOutCoroutine(sceneFadeDuration);
        // fading buzzing from .2 to 0
        yield return audioFade[0].FadeSoundCoroutine(0.2f, 0.0f, sceneFadeDuration);
    }

}
