using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private TextMeshProUGUI gnomeCounter;

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
    }

    public void UpdateGnomePieces()
    {
        gnomeCounter.text = $"{PlayerManager.Instance.gnomePieces}/{PlayerManager.Instance.allGnomePieces}";
    }
}
