using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
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
        SceneManager.LoadScene("CoreLoop");
    }
}
