using System.Collections;
using TMPro;
using UnityEngine;

public class InteractionField : MonoBehaviour
{
    [SerializeField] private GameObject textWindow;
    [SerializeField] public TextMeshProUGUI windowTXT;

    [SerializeField] private string[] initial, after, other;
    private int state;

    [SerializeField] private bool noChanges = false;

    [SerializeField] private int interactionType = 0;

    private void Awake()
    {
        if (interactionType == 0) textWindow.SetActive(false);
        state = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!noChanges) RandomTXT();
            textWindow.SetActive(true);
            if (interactionType == 2)
            {
                StartCoroutine(End());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            textWindow.SetActive(false);
        }
    }

    public void AfterTXT()
    {
        state = 1;
    }

    public void OtherTXT()
    {
        state = 2;
    }

    public void RandomTXT()
    {
        switch(state)
        {
            case 0:
                windowTXT.text = initial[Random.Range(0, initial.Length)];
                break;
            case 1:
                windowTXT.text = after[Random.Range(0, after.Length)];
                break;
            case 2:
                windowTXT.text = other[Random.Range(0, other.Length)];
                break;
            default:
                break;
        }
    }

    IEnumerator End()
    {
        yield return new WaitForSeconds(3f);
        UIManager.Instance.EndGame();
    }
}
