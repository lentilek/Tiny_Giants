using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigamesManager : MonoBehaviour
{
    [SerializeField] private PuzzleManager puzzle1;

    public void Puzzle1Open()
    {
        puzzle1.isActive = true;
        puzzle1.gameObject.SetActive(true);
    }
}
