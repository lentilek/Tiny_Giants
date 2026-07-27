using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeManipulation : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float minSize, maxSize, currentSize, scale, scaleInterval;

    private bool isBreak;

    private void Awake()
    {
        isBreak = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (InteractionManager.Instance.canManipulate && other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E) && currentSize <= maxSize)
            {
                target.transform.DOScale(currentSize, currentSize + scale);
                currentSize += scale;
                if(!isBreak) StartCoroutine(SizeSound());
                if (currentSize > maxSize) currentSize = maxSize;
            }
            else if (Input.GetKey(KeyCode.Q) && currentSize >= minSize)
            {
                target.transform.DOScale(currentSize, currentSize - scale);
                currentSize -= scale;
                if (!isBreak) StartCoroutine(SizeSound());
                if (currentSize < minSize) currentSize = minSize;
            }
        }
    }

    IEnumerator SizeSound()
    {
        isBreak = true;
        AudioManager.Instance.PlayAudio("scale");
        yield return new WaitForSeconds(scaleInterval);
        isBreak = false;
    }
}
