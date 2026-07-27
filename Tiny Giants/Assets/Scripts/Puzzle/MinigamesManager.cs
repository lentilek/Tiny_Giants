using System.Collections;
using System.Collections.Generic;
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
        puzzle1.isActive = true;
        puzzle1.gameObject.SetActive(true);
    }
}
