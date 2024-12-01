using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
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
        audioFade[0].ChangeClip(0);
        audioFade[0].MakeFullVolume();
        yield return sceneFade.FadeInCoroutine(1);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(StartSceneFade());
            StartCoroutine(StartSoundFade());
            StartCoroutine(LoadCutScene());        
        }
    }

    private IEnumerator StartSceneFade()
    {
        yield return sceneFade.FadeOutCoroutine(sceneFadeDuration);
    }

    private IEnumerator StartSoundFade()
    {
        yield return audioFade[0].FadeSoundCoroutine(1.0f, 0.01f, sceneFadeDuration);
    }

    private IEnumerator LoadCutScene()
    {
        yield return new WaitForSeconds(sceneFadeDuration);
        SceneManager.LoadScene("CutScene");
    }
}
