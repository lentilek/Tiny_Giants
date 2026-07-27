using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private PuzzlePlace[] puzzles;

    [HideInInspector] public bool isActive;
    private bool puzzlesGood;
    public int number;

    private void Awake()
    {
        isActive = true;
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (isActive)
        {
            int i = 0;
            puzzlesGood = true;
            foreach (var puzzle in puzzles)
            {
                if (!puzzle.isCorrect)
                {
                    puzzlesGood = false;
                    break;
                }
                i++;
            }
            if(puzzlesGood) FinishPuzzle();
        }
    }

    private void FinishPuzzle()
    {
        MinigamesManager.Instance.FinishPuzzle(number);
        gameObject.SetActive(false);
    }
}
