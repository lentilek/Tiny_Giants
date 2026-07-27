using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeManipulation : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float minSize, maxSize, scale;
    private float currentSize;

    private void Awake()
    {
        //
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.B) && currentSize <= maxSize)
            {
                target.transform.DOScale(currentSize, currentSize + scale);
                currentSize += scale;
                if (currentSize > maxSize) currentSize = maxSize;
            }
            else if (Input.GetKey(KeyCode.N) && currentSize >= minSize)
            {
                target.transform.DOScale(currentSize, currentSize - scale);
                currentSize -= scale;
                if(currentSize < minSize) currentSize = minSize;
            }
        }
    }
}
