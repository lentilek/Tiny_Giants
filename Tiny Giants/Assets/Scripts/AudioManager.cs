using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [HideInInspector] public AudioSource audioSrc;

    [SerializeField] private AudioClip[] steps, collect, npc, click, scale, puzzle, glowstick, alarm, snore;

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
                audioSrc.PlayOneShot(steps[Random.Range(0, steps.Length)], 2f); // done
                break;
            case "collect":
                audioSrc.PlayOneShot(collect[Random.Range(0, collect.Length)], .5f); // done
                break;
            case "npc":
                audioSrc.PlayOneShot(npc[Random.Range(0, npc.Length)]);
                break;
            case "click":
                audioSrc.PlayOneShot(click[Random.Range(0, click.Length)], 0.5f); // done
                break;
            case "scale":
                audioSrc.PlayOneShot(scale[Random.Range(0, scale.Length)], 2f); // done
                break;
            case "puzzle":
                audioSrc.PlayOneShot(puzzle[Random.Range(0, puzzle.Length)]);
                break;
            case "glowstick":
                audioSrc.PlayOneShot(glowstick[Random.Range(0, glowstick.Length)]);
                break;
            case "alarm":
                audioSrc.PlayOneShot(alarm[Random.Range(0, alarm.Length)], .5f); //done
                break;
            case "snore":
                audioSrc.PlayOneShot(snore[Random.Range(0, snore.Length)]);
                break;
            default:
                break;
        }
    }
}
