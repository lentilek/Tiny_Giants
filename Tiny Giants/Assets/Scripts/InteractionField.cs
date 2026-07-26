using TMPro;
using UnityEngine;

public class InteractionField : MonoBehaviour
{
    [SerializeField] private GameObject textWindow;
    [SerializeField] private TextMeshProUGUI windowTXT;

    [SerializeField] private string initial, after, other;

    private void Awake()
    {
        textWindow.SetActive(false);
        windowTXT.text = initial;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            textWindow.SetActive(true);
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
        windowTXT.text = after;
    }

    public void OtherTXT()
    {
        windowTXT.text = other;
    }
}
