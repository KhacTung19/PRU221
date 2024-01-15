using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab_dance : MonoBehaviour
{
    public float jumpForce = 20f;
    public float jumpInterval = 2f;

    private bool isGrounded;
    private Rigidbody2D rb;
    private float lastJumpTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastJumpTime = Time.time;
    }

    void Update()
    {
        if (Time.time - lastJumpTime >= jumpInterval)
        {
            Jump();
            lastJumpTime = Time.time;
        }
    }

    void Jump()
    {
        if (isGrounded)
        {
            
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

           
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
