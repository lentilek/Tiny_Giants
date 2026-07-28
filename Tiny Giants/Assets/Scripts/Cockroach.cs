using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cockroach : MonoBehaviour
{
    [SerializeField] private InteractionField cockroach, player, cockroach2, cup;
    private int part;
    [SerializeField] private string[] strings;
    private bool isWaiting;
    private void Awake()
    {
        part = 0;
        isWaiting = false;
        cockroach.gameObject.SetActive(false);
        cockroach2.gameObject.SetActive(false);
        player.gameObject.SetActive(false);
    }
    private void OnTriggerStay(Collider other)
    {
        if (!isWaiting && part == 0 && other.gameObject.tag == "Player" && Input.GetKey(KeyCode.F))
        {
            StartCoroutine(Wait());
            InteractionManager.Instance.inDialogue = true;
            part++;
            cockroach.gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        if (!isWaiting && InteractionManager.Instance.inDialogue && 
            (Input.GetMouseButton(0) || Input.GetKey(KeyCode.F)))
        {
            switch (part)
            {
                case 1:
                    part++;
                    cockroach.gameObject.SetActive(false);
                    player.gameObject.SetActive(true);
                    break;
                case 2:
                    part++;
                    player.gameObject.SetActive(false);
                    cockroach.windowTXT.text = strings[0];
                    cockroach.gameObject.SetActive(true);
                    break;
                case 3:
                    part++;
                    cockroach.gameObject.SetActive(false);
                    player.windowTXT.text = strings[1];
                    player.gameObject.SetActive(true);
                    break;
                case 4:
                    part++;
                    player.gameObject.SetActive(false);
                    cockroach.windowTXT.text = strings[2];
                    cockroach.gameObject.SetActive(true);
                    break;
                case 5:
                    part++;
                    cockroach.gameObject.SetActive(false);
                    player.windowTXT.text = strings[3];
                    player.gameObject.SetActive(true);
                    break;
                case 6:
                    part++;
                    player.gameObject.SetActive(false);
                    cockroach.windowTXT.text = strings[4];
                    cockroach.gameObject.SetActive(true);
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

    private void EndDialogue()
    {
        InteractionManager.Instance.canManipulate = true;
        cockroach.gameObject.SetActive(false);
        player.gameObject.SetActive(false);
        cockroach2.gameObject.SetActive(true);
        InteractionManager.Instance.inDialogue = false;
        cockroach2.AfterTXT();
        cup.gameObject.SetActive(true);
    }

    IEnumerator Wait()
    {
        isWaiting = true;
        yield return new WaitForSeconds(1f);
        isWaiting = false;
    }
}
