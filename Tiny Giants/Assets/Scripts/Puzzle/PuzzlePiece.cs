using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class PuzzlePiece : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler//IPointerDownHandler, IPointerUpHandler
{
    private bool canManipulate, canMove;
    [SerializeField] private float minSize, maxSize, scale;
    public int number;
    [HideInInspector] public float currentSize;

    private void Awake()
    {
        canManipulate = false;
        canMove = false;
    }

    private void Update()
    {
        if (canManipulate)
        {
            if (Input.GetKey(KeyCode.B) && currentSize <= maxSize)
            {
                //gameObject.transform.DOScale(currentSize, currentSize + scale);
                gameObject.transform.DOScale(currentSize + scale, .01f);
                currentSize += scale;
                if (currentSize > maxSize) currentSize = maxSize;
            }
            else if (Input.GetKey(KeyCode.N) && currentSize >= minSize)
            {
                //target.transform.DOScale(currentSize, currentSize - scale);
                gameObject.transform.DOScale(currentSize + scale, .01f);
                currentSize -= scale;
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

    /*public void OnPointerDown(PointerEventData eventData)
    {
        canManipulate = false;
        transform.position = Input.mousePosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        canManipulate = false;
    }*/

    public void OnPointerMove(PointerEventData eventData)
    {
        if (canMove) transform.position = Input.mousePosition;
    }
}
