using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GnomeManager : MonoBehaviour
{
    public static GnomeManager Instance;

    [SerializeField] private InteractionField gnome, player, endGame;
    private int part;
    [SerializeField] private string[] strings;
    private bool isWaiting;

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
        part = 0;
        isWaiting = false;
        gnome.gameObject.SetActive(false);
        player.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(part > 0)
        {
            if (!isWaiting && InteractionManager.Instance.inDialogue &&
            (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.F)))
            {
                switch (part)
                {
                    case 1:
                        part++;
                        player.gameObject.SetActive(false);
                        gnome.windowTXT.text = strings[1];
                        gnome.gameObject.SetActive(true);
                        break;
                    case 2:
                        part++;
                        gnome.gameObject.SetActive(false);
                        player.windowTXT.text = strings[2];
                        player.gameObject.SetActive(true);
                        break;
                    case 3:
                        part++;
                        player.gameObject.SetActive(false);
                        gnome.windowTXT.text = strings[3];
                        gnome.gameObject.SetActive(true);
                        break;
                    case 4:
                        part++;
                        gnome.gameObject.SetActive(false);
                        player.windowTXT.text = strings[4];
                        player.gameObject.SetActive(true);
                        break;
                    case 5:
                        part++;
                        player.gameObject.SetActive(false);
                        gnome.windowTXT.text = strings[5];
                        gnome.gameObject.SetActive(true);
                        break;
                    case 6:
                        part++;
                        gnome.gameObject.SetActive(false);
                        player.windowTXT.text = strings[6];
                        player.gameObject.SetActive(true);
                        break;
                    case 7:
                        part++;
                        EndDialogue();
                        break;
                    default:
                        break;
                }
                StartCoroutine(Wait());
            }
        }
    }

    public void StartLastDialogue()
    {
        StartCoroutine(Wait());
        InteractionManager.Instance.inDialogue = true;
        part++;
        player.windowTXT.text = strings[0];
        player.gameObject.SetActive(true);
    }

    private void EndDialogue()
    {
        gnome.gameObject.SetActive(false);
        player.gameObject.SetActive(false);
        InteractionManager.Instance.inDialogue = false;
        endGame.gameObject.SetActive(true);
        StartCoroutine(TeleportPlayer());
    }

    IEnumerator TeleportPlayer()
    {
        UIManager.Instance.BlackScreenIn(1f);
        yield return new WaitForSeconds(1f);
        PlayerManager.Instance.gameObject.transform.position = PlayerManager.Instance.playerHomePoint;
    }

    IEnumerator Wait()
    {
        isWaiting = true;
        yield return new WaitForSeconds(1f);
        isWaiting = false;
    }
}
