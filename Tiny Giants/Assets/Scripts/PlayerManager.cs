using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    private Rigidbody rb;
    [SerializeField] private SpriteRenderer charSprite;
    [SerializeField] private Animator animator;
    [SerializeField] private float playerSpeed, stepsInterval;
    private bool isBreak;
    public Vector3 playerHomePoint;

    [HideInInspector] public int gnomePieces;
    public int allGnomePieces;

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
        isBreak = false;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //gameObject.transform.position = playerHomePoint;
        gnomePieces = 0;
        UIManager.Instance.UpdateGnomePieces();
    }

    private void Update()
    {        
        animator.SetBool("isWalking", false);
        if (!InteractionManager.Instance.inDialogue)
        {
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                transform.position += Vector3.right * playerSpeed * Time.deltaTime;

                charSprite.flipX = true;
                animator.SetBool("isWalking", true);
            }
            else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                transform.position -= Vector3.right * playerSpeed * Time.deltaTime;

                charSprite.flipX = true;
                animator.SetBool("isWalking", true);
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += Vector3.forward * playerSpeed * Time.deltaTime;

                charSprite.flipX = true;
                animator.SetBool("isLeft", false);
                animator.SetBool("isWalking", true);

                // sprite front
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += Vector3.back * playerSpeed * Time.deltaTime;

                charSprite.flipX = true;
                animator.SetBool("isLeft", true);
                animator.SetBool("isWalking", true);

                // sprite back
            }
        }

        // idle state
        if (animator.GetBool("isLeft") && !animator.GetBool("isWalking"))
        {
            charSprite.flipX = false;
        }
        else if (!animator.GetBool("isWalking"))
        {
            charSprite.flipX = true;
        }

        if (animator.GetBool("isWalking"))
        {
            if (!isBreak)
            {
                StartCoroutine(PlaySteps());
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (other.gameObject.tag == "GnomePiece")
            {
                AudioManager.Instance.PlayAudio("collect");
                Destroy(other.gameObject);
                gnomePieces++;
                UIManager.Instance.UpdateGnomePieces();
                if (gnomePieces == 1) InteractionManager.Instance.Interaction0();
            }
            else if (gnomePieces > 0 && other.gameObject.tag == "Gate")
            {
                //other.GetComponent<BoxCollider>().enabled = false;
                InteractionManager.Instance.Interaction1();
                // OpenGate()
            }
        }
    }

    IEnumerator PlaySteps()
    {
        isBreak = true;
        AudioManager.Instance.PlayAudio("steps");
        yield return new WaitForSeconds(stepsInterval);
        isBreak = false;
    }
}
