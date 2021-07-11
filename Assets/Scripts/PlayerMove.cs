using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float mvSpeed;
    public float jumpForce;
    float xIn, yIn, moving;

    Rigidbody2D rb;

    SpriteRenderer sp;

    public Animator animator;
    public GameObject infoMove, infoJump, infoSwitch, dialogueThing, shopObject;
    PlayerSwitch switchScript;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        switchScript = FindObjectOfType<PlayerSwitch>();
        infoMove.gameObject.SetActive (true);
        infoJump.gameObject.SetActive (true);
        infoSwitch.gameObject.SetActive (true);
        dialogueThing.gameObject.SetActive (false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && transform.name == "vampire")
        {
            pcJump();
            infoJump.gameObject.SetActive (false);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            infoSwitch.gameObject.SetActive (false);
            switchScript.SwitchPlayer();
        }
    }

    private void FixedUpdate()
    {
        xIn = Input.GetAxis("Horizontal");
        if (Mathf.Abs(xIn) > 0.1f)
        {
            infoMove.gameObject.SetActive (false);
            animator.SetBool("isWalking", true); // this could be done simply with Play, but don't have time to get into that
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        if (transform.name == "bat")
        {
            yIn = Input.GetAxis("Vertical"); // If you want to fly around
            transform.Translate(xIn * mvSpeed, yIn * mvSpeed, 0);
        }

        pcMove();
        pcTurn();
    }

    private void OnTriggerStay2D(Collider2D shopObject)
    {
        Debug.Log("We are colliding");
        if (Input.GetKeyDown(KeyCode.E))
        {
                dialogueThing.gameObject.SetActive (true);
        }
    }

    void pcJump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }

    void pcMove()
    {
        rb.velocity = new Vector2(mvSpeed * xIn, rb.velocity.y);
    }

    void pcTurn()
    {
        if (rb.velocity.x < 0)
        {
            sp.flipX = true;
        }
        else if (rb.velocity.x > 0)
        {
            sp.flipX = false;
        }
    }
}
