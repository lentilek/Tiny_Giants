using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class PuzzlePiece : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler
{
    private bool canManipulate, canMove;
    [SerializeField] private float minSize, maxSize, scale, scaleInterval;
    public int number;
    public float currentSize = 1;
    private bool isBreak;

    private void Awake()
    {
        canManipulate = false;
        canMove = false;
    }

    private void Update()
    {
        if (canManipulate)
        {
            if (Input.GetKey(KeyCode.E) && currentSize <= maxSize)
            {
                gameObject.transform.DOScale(currentSize + scale, .01f);
                currentSize += scale;
                if (!isBreak) StartCoroutine(SizeSound());
                if (currentSize > maxSize) currentSize = maxSize;
            }
            else if (Input.GetKey(KeyCode.Q) && currentSize >= minSize)
            {
                gameObject.transform.DOScale(currentSize + scale, .01f);
                currentSize -= scale;
                if (!isBreak) StartCoroutine(SizeSound());
                if (currentSize < minSize) currentSize = minSize;
            }
        }

        if (Input.GetMouseButton(0))
        {
            canMove = true;
        }
        else
        {
            canMove= false;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        canManipulate = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        canManipulate = false;
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        if (canMove) transform.position = Input.mousePosition;
    }

    IEnumerator SizeSound()
    {
        isBreak = true;
        AudioManager.Instance.PlayAudio("scale");
        yield return new WaitForSeconds(scaleInterval);
        isBreak = false;
    }
}
