using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private TextMeshProUGUI gnomeCounter;

    [SerializeField] private GameObject pauseUI;

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
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseUI.activeSelf)
            {
                pauseUI.SetActive(false);
            }
            else
            {
                Time.timeScale = 0f;
                pauseUI.SetActive(true);
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseUI.SetActive(false);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void UpdateGnomePieces()
    {
        gnomeCounter.text = $"{PlayerManager.Instance.gnomePieces}/{PlayerManager.Instance.allGnomePieces}";
    }
}
