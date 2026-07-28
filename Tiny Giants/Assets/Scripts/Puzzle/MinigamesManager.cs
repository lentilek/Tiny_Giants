using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MinigamesManager : MonoBehaviour
{
    public static MinigamesManager Instance;

    [SerializeField] private PuzzleManager puzzle1, puzzle2;
    [SerializeField] private Sprite goodClock;
    [SerializeField] private SpriteRenderer clock;
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
    }

    public void Puzzle1Open()
    {
        InteractionManager.Instance.inDialogue = true;
        puzzle1.isActive = true;
        puzzle1.gameObject.SetActive(true);
    }

    public void Puzzle2Open()
    {
        InteractionManager.Instance.inDialogue = true;
        puzzle2.isActive = true;
        puzzle2.gameObject.SetActive(true);
    }

    public void FinishPuzzle(int number)
    {
        InteractionManager.Instance.inDialogue = false;
        switch (number)
        {
            case 1:
                InteractionManager.Instance.Interaction2();
                AudioManager.Instance.PlayAudio("alarm");
                clock.sprite = goodClock;
                AudioManager.Instance.audioSnore.Stop();
                AudioManager.Instance.audioSnore.enabled = false;
                break;
            case 2:
                PlayerManager.Instance.gnomePieces = 0;
                AudioManager.Instance.PlayAudio("puzzle");
                InteractionManager.Instance.inDialogue = true;
                GnomeManager.Instance.StartLastDialogue();
                break;
            default:
                break;
        }
    }
}
