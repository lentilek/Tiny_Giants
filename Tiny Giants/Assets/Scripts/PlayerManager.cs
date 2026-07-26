using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    private Rigidbody rb;
    //[SerializeField] private SpriteRenderer charSprite;
    //[SerializeField] private Animator animator;
    [SerializeField] private float playerSpeed;
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
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.forward * playerSpeed * Time.deltaTime;

            // sprite front
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.back * playerSpeed * Time.deltaTime;

            // sprite back
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.right * playerSpeed * Time.deltaTime;

            //charSprite.flipX = false;
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.position -= Vector3.right * playerSpeed * Time.deltaTime;

            //charSprite.flipX = true;
        }

        // idle state
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (other.gameObject.tag == "GnomePiece")
            {
                Destroy(other.gameObject);
                gnomePieces++;
                UIManager.Instance.UpdateGnomePieces();
            }
            else if (gnomePieces > 0 && other.gameObject.tag == "Gate")
            {
                other.GetComponent<BoxCollider>().enabled = false;
                // OpenGate()
            }
        }
    }
}
