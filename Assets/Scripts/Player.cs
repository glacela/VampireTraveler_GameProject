using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float mvSpeed = 2;
    private float horizontal;
    private Rigidbody2D rb;
    private bool facingRight = true;

    public Animator animator;
    public const string RIGHT = "right";
    public const string LEFT = "left";

    string direction;
    // Start is called before the first frame update
    void Start()
    {
        // rb = GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
        horizontal = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = RIGHT;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = LEFT;
        }
        else
        {
            direction = null;
        }
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(horizontal) > 0.1f)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        if (direction == RIGHT)
        {
            rb.velocity = new Vector2(mvSpeed, 0);
            if (!facingRight)
            {
                transform.Rotate(new Vector3(0, 180, 0));
                facingRight = true;
            }
        }
        else if (direction == LEFT)
        {
            rb.velocity = new Vector2(-mvSpeed, 0);
            if (facingRight)
            {
                transform.Rotate(new Vector3(0, 180, 0));
                facingRight = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }
}
