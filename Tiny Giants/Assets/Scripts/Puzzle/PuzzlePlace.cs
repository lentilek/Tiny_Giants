
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePlace : MonoBehaviour
{
    [HideInInspector] public bool isCorrect;
    [SerializeField] private int number;
    [SerializeField] private float minSize, maxSize;

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PuzzlePiece>() != null)
        {
            PuzzlePiece temp = other.GetComponent<PuzzlePiece>();

            if (temp.number == number && (temp.currentSize <= maxSize && temp.currentSize >= minSize))
            {
                isCorrect = true;
            }
            else
            {
                isCorrect = false;
            }
        }
    }
}
