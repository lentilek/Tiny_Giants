using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private TextMeshProUGUI gnomeCounter;

    [SerializeField] private GameObject pauseUI, endingUI;
    [SerializeField] private Image bs;
    [SerializeField] private float bsTime, bTime;

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
        endingUI.SetActive(false);
        Time.timeScale = 1f;
        BlackScreenOut(bsTime);
    }

    private void Update()
    {
        if (!bs.gameObject.activeSelf && Input.GetKeyDown(KeyCode.Escape))
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

    public void BlackScreenOut(float time)
    {
        StartCoroutine(BlackScreenRoutineOut(time));
    }

    private IEnumerator BlackScreenRoutineOut(float time)
    {
        bs.DOFade(1, 0.01f);
        bs.gameObject.SetActive(true);
        yield return new WaitForSeconds(bTime);
        bs.DOFade(0, time);
        yield return new WaitForSeconds(time);
        bs.gameObject.SetActive(false);
    }

    public void BlackScreenIn(float time)
    {
        StartCoroutine(BlackScreenRoutineIn(time));
    }

    private IEnumerator BlackScreenRoutineIn(float time)
    {
        bs.gameObject.SetActive(true);
        bs.DOFade(1, time);
        yield return new WaitForSeconds(time);
        BlackScreenOut(time);
    }

    public void EndGame()
    {
        Time.timeScale = 0f;
        endingUI.SetActive(true);
    }

    public void Resume()
    {
        AudioManager.Instance.PlayAudio("click");
        Time.timeScale = 1f;
        pauseUI.SetActive(false);
    }

    public void Menu()
    {
        AudioManager.Instance.PlayAudio("click");
        SceneManager.LoadScene(0);
    }

    public void UpdateGnomePieces()
    {
        gnomeCounter.text = $"{PlayerManager.Instance.gnomePieces}/{PlayerManager.Instance.allGnomePieces}";
    }
}
