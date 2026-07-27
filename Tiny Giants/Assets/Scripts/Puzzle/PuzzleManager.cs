using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private PuzzlePlace[] puzzles;

    [HideInInspector] public bool isActive;
    private bool puzzlesGood;

    private void Awake()
    {
        isActive = false;
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (isActive)
        {
            puzzlesGood = true;
            foreach (var puzzle in puzzles)
            {
                if (!puzzle.isCorrect)
                {
                    puzzlesGood = false;
                    break;
                }
            }
            if(puzzlesGood) FinishPuzzle();
        }
    }

    private void FinishPuzzle()
    {
        gameObject.SetActive(false);
    }
}
