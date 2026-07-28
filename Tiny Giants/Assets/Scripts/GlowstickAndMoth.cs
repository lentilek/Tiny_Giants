using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowstickAndMoth : MonoBehaviour
{
    public static GlowstickAndMoth Instance;

    [SerializeField] private GameObject moth;
    [SerializeField] private Transform mothPoint;
    [SerializeField] private InteractionField iMoth, iStick;

    [SerializeField] float smallSize, largeSize;
    private SizeManipulation mothSize;
    [SerializeField] private Sprite glowing;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [HideInInspector] public bool isBroken;

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
        mothSize = GetComponent<SizeManipulation>();
        isBroken = false;
    }
    private void Update()
    {
        if (IsSizeGood(true))
        {
            iStick.AfterTXT();
        }
        else
        {
            iStick.InitialTXT();
        }

        if(IsSizeGood(false))
        {
            iMoth.AfterTXT();
            moth.transform.DOMove(mothPoint.position, 8f);
            this.enabled = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.F))
        {
            BreakStick();
        }
    }
    public void BreakStick()
    {
        spriteRenderer.sprite = glowing;
        isBroken = true;
        iStick.gameObject.SetActive(false);
    }
    public bool IsSizeGood(bool small)
    {
        if ((small && mothSize.currentSize <= smallSize) || 
            (!small && mothSize.currentSize >= largeSize && isBroken))
        {
            return true;
        }
        return false;
    }
}
