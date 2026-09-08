using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class PuzzlePiece : MonoBehaviour, IBeginDragHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    private bool canManipulate, canMove;
    [SerializeField] private float minSize, maxSize, scale, scaleInterval;
    public int number;
    public float currentSize = 1;
    private bool isBreak;

    public bool dragOnSurfaces = true;
    private RectTransform m_DraggingPlane;

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
            canMove = false;
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

    IEnumerator SizeSound()
    {
        isBreak = true;
        AudioManager.Instance.PlayAudio("scale");
        yield return new WaitForSeconds(scaleInterval);
        isBreak = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        SetDraggedPosition(eventData);
    }
    private void SetDraggedPosition(PointerEventData data)
    {
        if (dragOnSurfaces && data.pointerEnter != null && data.pointerEnter.transform as RectTransform != null)
            m_DraggingPlane = data.pointerEnter.transform as RectTransform;

        var rt = this.GetComponent<RectTransform>();
        Vector3 globalMousePos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(m_DraggingPlane, data.position, data.pressEventCamera, out globalMousePos))
        {
            rt.position = globalMousePos;
            rt.rotation = m_DraggingPlane.rotation;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        SetDraggedPosition(eventData);
    }
}
