using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    [SerializeField] private AudioClip music;
    [SerializeField] private float fadeTime;
    [SerializeField] public AudioSource audioSrcAmbient, audioSrcMusic;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(transform.gameObject);
            Instance = this;
            audioSrcAmbient.Play();

            return;
        }
        Destroy(gameObject);
    }

    public void PlayMusic()
    {
        StartCoroutine(FadeOut(audioSrcMusic, fadeTime, music));
    }

    private static IEnumerator FadeOut(AudioSource audioSource, float FadeTime, AudioClip clip)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }
        audioSource.clip = clip;
        audioSource.Play();

        while (audioSource.volume < startVolume)
        {
            audioSource.volume += startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }
    }
}
