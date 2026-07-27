using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MinigamesManager : MonoBehaviour
{
    public static MinigamesManager Instance;

    [SerializeField] private PuzzleManager puzzle1;
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

    public void FinishPuzzle(int number)
    {
        InteractionManager.Instance.inDialogue = false;
        switch (number)
        {
            case 1:
                InteractionManager.Instance.Interaction2();
                AudioManager.Instance.PlayAudio("alarm");
                break;
            default:
                break;
        }
    }
}
