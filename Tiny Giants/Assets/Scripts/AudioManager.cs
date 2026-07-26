using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [HideInInspector] public AudioSource audioSrc;

    [SerializeField] private AudioClip[] steps, collect, npc, click, scale, puzzle;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(Instance.gameObject);
            Instance = this;
        }
        audioSrc = GetComponent<AudioSource>();
    }

    public void PlayAudio(string clip)
    {
        switch (clip)
        {
            case "steps":
                audioSrc.PlayOneShot(steps[Random.Range(0, steps.Length)]);
                break;
            case "collect":
                audioSrc.PlayOneShot(steps[Random.Range(0, collect.Length)]);
                break;
            case "npc":
                audioSrc.PlayOneShot(steps[Random.Range(0, npc.Length)]);
                break;
            case "click":
                audioSrc.PlayOneShot(steps[Random.Range(0, click.Length)]);
                break;
            case "scale":
                audioSrc.PlayOneShot(steps[Random.Range(0, scale.Length)]);
                break;
            case "puzzle":
                audioSrc.PlayOneShot(steps[Random.Range(0, puzzle.Length)]);
                break;
            default:
                break;
        }
    }
}
