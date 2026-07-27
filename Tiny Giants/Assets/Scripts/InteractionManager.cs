using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public static InteractionManager Instance;

    [SerializeField] private InteractionField[] interactionFields;
    [SerializeField] private GameObject gate, hedgehog;

    [HideInInspector] public bool inDialogue, canManipulate;

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
        inDialogue = false;
        canManipulate = false;
    }

    public void Interaction0()
    {
        interactionFields[0].AfterTXT();
        interactionFields[1].gameObject.SetActive(true);
    }
    public void Interaction1()
    {
        gate.transform.DORotate(new Vector3(14,-22,-8), 1f);
        interactionFields[1].AfterTXT();
        interactionFields[1].RandomTXT();
    }
    public void Interaction2()
    {
        interactionFields[2].AfterTXT();
        interactionFields[2].RandomTXT();
        hedgehog.transform.DOMoveZ(-3, 10f);
    }
}
