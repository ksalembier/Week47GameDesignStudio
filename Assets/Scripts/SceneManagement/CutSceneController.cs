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
        yield return sceneFade.FadeInCoroutine(4);
        yield return new WaitForSeconds(4);
        yield return sceneFade.FadeOutCoroutine(sceneFadeDuration);
        yield return audioFade[0].FadeSoundOutCoroutine(4);
    }
}
